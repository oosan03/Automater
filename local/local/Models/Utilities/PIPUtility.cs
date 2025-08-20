using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace local.Models.Utilities
{
    public static class LightdeckFileUtils
    {
        /// <summary>
        /// End-to-end: find all "sampleResults" folders under sourceRoot, copy files, then rename folders.
        /// </summary>
        public static Task RunAsync(
            string sourceRoot,
            string destRoot,
            IProgress<string>? log = null,
            CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();
                log?.Report("Scanning for 'sampleResults' folders...");

                var sampleResults = FindSampleResultsPaths(sourceRoot);
                log?.Report($"Found {sampleResults.Count} folder(s).");

                foreach (var item in sampleResults)
                {
                    ct.ThrowIfCancellationRequested();

                    log?.Report($"> Copying from: {item}");
                    CopyOnly(item, destRoot, log);

                    log?.Report($"> Renaming payload folders in: {item}");
                    RenameFolders(item, destRoot, log);
                }

                log?.Report("Done.");
            }, ct);
        }

        public static void CopyOnly(string sourcePath, string destRoot, IProgress<string>? log = null)
        {
            var destinationPath = Path.Combine(destRoot, "!Lightdeck Studio");
            var imageInspectionPath = Path.Combine(destRoot, "!Image Inspection");

            Directory.CreateDirectory(destinationPath);
            Directory.CreateDirectory(imageInspectionPath);

            if (!CopyFiles(sourcePath, destinationPath, imageInspectionPath, log))
            {
                log?.Report("Copy failed; please try again.");
            }
        }

        private static bool CopyFiles(string sourcePath, string destinationPath, string imageInspectionPath, IProgress<string>? log)
        {
            try
            {
                var payloadFolders = Directory.EnumerateDirectories(sourcePath);

                var folderPattern = new Regex(@"^\d{8}-\d{6}$|^(?:[A-Za-z0-9%_-]+-)?[A-Z]{2}-\d{5}-[0-9A-Z]{3}$",
                    RegexOptions.Compiled);

                foreach (var folder in payloadFolders)
                {
                    var name = Path.GetFileName(folder);
                    if (!folderPattern.IsMatch(name)) continue;

                    foreach (var file in Directory.EnumerateFiles(folder))
                    {
                        var fileName = Path.GetFileName(file);
                        var destFilePath = Path.Combine(destinationPath, fileName);
                        var imgInspectPath = Path.Combine(imageInspectionPath, fileName);

                        // Skip Thumbs.db in destination (delete if present)
                        if (fileName.Equals("Thumbs.db", StringComparison.OrdinalIgnoreCase)
                            && File.Exists(destFilePath))
                        {
                            try { File.Delete(destFilePath); } catch { /* ignore */ }
                        }

                        // If same name exists at destination and file is "...00420_750ms.png"
                        if (File.Exists(destFilePath) && fileName.EndsWith("00420_750ms.png", StringComparison.OrdinalIgnoreCase))
                        {
                            // Always copy this PNG to image inspection folder
                            Directory.CreateDirectory(imageInspectionPath);
                            File.Copy(file, imgInspectPath, overwrite: true);

                            var sameSize = new FileInfo(file).Length == new FileInfo(destFilePath).Length;
                            if (sameSize)
                            {
                                log?.Report($"Skipping identical file: {fileName}");
                                continue;
                            }
                        }

                        // Always copy special PNG to image inspection folder
                        if (fileName.EndsWith("00420_750ms.png", StringComparison.OrdinalIgnoreCase))
                        {
                            Directory.CreateDirectory(imageInspectionPath);
                            File.Copy(file, imgInspectPath, overwrite: true);
                        }

                        // Copy to destination (overwrite=false like shutil.copy2 default)
                        // If you want overwrite, set overwrite:true
                        if (!File.Exists(destFilePath))
                        {
                            File.Copy(file, destFilePath, overwrite: false);
                        }
                        else
                        {
                            // If different size, keep both by uniquifying name
                            if (new FileInfo(file).Length != new FileInfo(destFilePath).Length)
                            {
                                var unique = GetUniqueFilePath(destinationPath, fileName);
                                File.Copy(file, unique, overwrite: false);
                            }
                            // else identical -> skip (already reported above for special PNG)
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                log?.Report($"An error occurred during copy: {ex.Message}");
                return false;
            }
        }
 
        public static void RenameFolders(string sourcePath, string destRoot, IProgress<string>? log = null)
        {
            var dcuMap = FolderToDcuFileMap(sourcePath, destRoot, log);
            foreach (var kvp in dcuMap)
            {
                var payloadFolder = kvp.Key;
                var dcuFile = kvp.Value;

                var meta = ReadMetaData(dcuFile);
                meta.TryGetValue("CartridgeId", out var cartridgeId);
                meta.TryGetValue("TestTime", out var testTime);
                meta.TryGetValue("SampleId", out var sampleId);
                meta.TryGetValue("SerialNumber", out var serialNum);


                // -------Configure Folder Renaming String--------
                var parts = new List<string>();
                // if (!string.IsNullOrWhiteSpace(sampleId)) parts.Add(sampleId!);
                if (!string.IsNullOrWhiteSpace(cartridgeId)) parts.Add(cartridgeId!);
                // If you later want serial: parts.Add(serialNum);

                var newFolderName = parts.Count > 0 ? string.Join("_", parts) : "UNNAMED";
                // -----------------------------------------------

                var newFolderPath = Path.Combine(destRoot, newFolderName);

                if (Path.GetFullPath(payloadFolder)
                    .TrimEnd(Path.DirectorySeparatorChar)
                    .Equals(Path.GetFullPath(newFolderPath).TrimEnd(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase))
                {
                    log?.Report("Skipping identical folder name");
                    continue;
                }

                if (Directory.Exists(newFolderPath))
                {
                    var duplicates = Path.Combine(newFolderPath, "duplicates");
                    Directory.CreateDirectory(duplicates);
                    var target = UniqueSubfolderPath(duplicates, Path.GetFileName(payloadFolder));
                    log?.Report($"Destination exists. Moving payload to duplicates: {target}");
                    Directory.Move(payloadFolder, target);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFolderPath)!);
                    log?.Report($"Renaming: {payloadFolder} -> {newFolderPath}");
                    Directory.Move(payloadFolder, newFolderPath);
                }
            }
        }
        private static string FormatErrors(IEnumerable<string> errors)
        {
            // Build acronym of each error and join with " & "
            var tokens = new List<string>();
            foreach (var e in errors)
            {
                var trimmed = e.Replace("Error -", "", StringComparison.OrdinalIgnoreCase).Trim();
                var acr = string.Concat(trimmed
                    .Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => char.ToUpperInvariant(w[0])));
                if (!string.IsNullOrEmpty(acr))
                    tokens.Add(acr);
            }
            return string.Join(" & ", tokens);
        }

        private static (string resFolder, string folderName) BuildResFolderName(string resFile, string resFolder, string destPath)
        {
            // Parse errors & cartridge name; build new folder path
            var doc = XDocument.Load(resFile);
            var root = doc.Root ?? throw new InvalidDataException("Invalid .res.xml (no root).");

            var imageDataset = root.Descendants("ImageDataset").FirstOrDefault();
            var cartridge = imageDataset?.Element("Cartridge")?.Value ?? string.Empty;
            cartridge = string.Join(" ", cartridge.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries))
                               .Replace(":", "");

            var errorLogs = root.Descendants("LogMessages").Descendants("LogMessage");
            var re = new Regex(@"ProcessControlCheckTask\.cpp:72:\s*(.*?)(?=\s*\[)", RegexOptions.Compiled);

            var errors = new List<string>();
            foreach (var log in errorLogs)
            {
                var text = log.Value ?? "";
                var m = re.Match(text);
                if (m.Success)
                {
                    var msg = m.Groups[1].Value;
                    errors.Add(msg);
                }
            }

            var formattedErrors = FormatErrors(errors);
            var folderName = cartridge + "_" + formattedErrors;
            var newFolderPath = Path.Combine(destPath, folderName);

            return (resFolder, newFolderPath);
        }
        private static Dictionary<string, string> FolderToDcuFileMap(string sourcePath, string destPath, IProgress<string>? log)
        {
            // Returns: map of payloadFolder -> dcuFile
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var payloadFolders = Directory.EnumerateDirectories(sourcePath);

            // Matches either: 20240101-123456  OR  CC-12345-ABC (optionally with prefix "prefix-CC-12345-ABC")
            var folderPattern = new Regex(@"^\d{8}-\d{6}$|^(?:[A-Za-z0-9%_-]+-)?[A-Z]{2}-\d{5}-[0-9A-Z]{3}$",
                RegexOptions.Compiled);

            foreach (var folder in payloadFolders)
            {
                var name = Path.GetFileName(folder);
                if (!folderPattern.IsMatch(name)) continue;

                var files = Directory.EnumerateFiles(folder).ToList();
                var foundDcu = false;
                var foundRes = false;
                string? resFile = null;

                // If .success present, look for .dcu.xml
                if (files.Any(f => f.EndsWith(".success", StringComparison.OrdinalIgnoreCase)))
                {
                    var dcu = files.FirstOrDefault(f => f.EndsWith(".dcu.xml", StringComparison.OrdinalIgnoreCase));
                    if (dcu != null)
                    {
                        map[folder] = dcu;
                        foundDcu = true;
                    }
                }
                // If .fail present, look for .res.xml
                if (files.Any(f => f.EndsWith(".fail", StringComparison.OrdinalIgnoreCase)))
                {
                    resFile = files.FirstOrDefault(f => f.EndsWith(".res.xml", StringComparison.OrdinalIgnoreCase));
                    if (resFile != null) foundRes = true;
                }

                if (!foundDcu && foundRes && resFile != null)
                {
                    // Rename res folders immediately to Cartridge_ABC (acronyms)
                    var (resFolder, newFolder) = BuildResFolderName(resFile, folder, destPath);
                    RenameResFolders(resFolder, newFolder, log);
                }
                else if (!foundDcu && !foundRes)
                {
                    log?.Report($"Could not find XML file for {name}");
                }
            }

            return map;
        }

        private static Dictionary<string, string> ReadMetaData(string dcuFile)
        {
            var meta = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var doc = XDocument.Load(dcuFile);
            var root = doc.Root ?? throw new InvalidDataException("Invalid .dcu.xml (no root).");

            // Top-level elements
            foreach (var el in root.Elements())
            {
                // Store the text of top-level nodes
                if (!string.IsNullOrEmpty(el.Value))
                {
                    meta[el.Name.LocalName] = el.Value;
                }

                // Special handling for TestResults/TestResult/* similar to Python
                if (el.Name.LocalName.Equals("TestResults", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (var tr in el.Elements("TestResult"))
                    {
                        foreach (var r in tr.Elements())
                        {
                            meta[r.Name.LocalName] = r.Value ?? string.Empty;
                        }
                    }
                }
            }

            return meta;
        }

        private static void RenameResFolders(string resFolder, string newFolderPath, IProgress<string>? log)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(newFolderPath)!);

            if (Directory.Exists(newFolderPath))
            {
                var target = UniqueSubfolderPath(Path.GetDirectoryName(newFolderPath)!, Path.GetFileName(newFolderPath));
                log?.Report($"RES destination exists; moving to: {target}");
                Directory.Move(resFolder, target);
            }
            else
            {
                log?.Report($"Renaming (RES fail): {resFolder} -> {newFolderPath}");
                Directory.Move(resFolder, newFolderPath);
            }
        }

        private static string UniqueSubfolderPath(string parent, string desiredName)
        {
            var basePath = Path.Combine(parent, desiredName);
            if (!Directory.Exists(basePath)) return basePath;

            int i = 2;
            while (true)
            {
                var candidate = $"{basePath} ({i})";
                if (!Directory.Exists(candidate)) return candidate;
                i++;
            }
        }

        private static string GetUniqueFilePath(string folder, string fileName)
        {
            var name = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            var path = Path.Combine(folder, fileName);

            if (!File.Exists(path)) return path;

            int i = 2;
            while (true)
            {
                var candidate = Path.Combine(folder, $"{name} ({i}){ext}");
                if (!File.Exists(candidate)) return candidate;
                i++;
            }
        }

        private static List<string> FindSampleResultsPaths(string rootDir)
        {
            var results = new List<string>();
            try
            {
                foreach (var dir in Directory.EnumerateDirectories(rootDir, "*", SearchOption.AllDirectories))
                {
                    var name = Path.GetFileName(dir);
                    if (string.Equals(name, "sampleResults", StringComparison.OrdinalIgnoreCase))
                    {
                        results.Add(dir);
                    }
                }
            }
            catch (Exception)
            {
                // ignore partial traversal errors (e.g., access denied)
            }
            return results;
        }
    }
}
