
using local.Models.utilities;
using local.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace local.Models
{
    internal class FileUtility
    {
        //private static bool loggedIn = false;
        //private const string pinFilePath = "user_data.txt";
        //private const string gaFilePath = "ga_user_data.txt";

        public static string? user;
        private static string usersPath = PathHelper.UserFolderPath;
        // folder named with the user login
        private static string? userPath;

        private static string credentialsFilename = "credentials.txt";
        private static string tooltrackFilename = "tooltrack.txt";
        private static string grandavenueFilename = "grandavenue.txt";
        private static string netsuiteFilename = "netsuite.txt";

        public static void SetCurrentUser(string username)
        {
            user = username;

        }
        public static string? FindUser()
        {
            userPath = Path.Combine(usersPath, user);
            if (!Directory.Exists(userPath))
            {
                return null;
            }

            return userPath;
        }
        public static bool ValidUserPin(string pin)
        {
            if (user == null) { return false; }

            string credentialsFile = Path.Combine(userPath, credentialsFilename);
            if (!File.Exists(credentialsFile)) { return false; }
            string storePin = File.ReadAllText(credentialsFile).Trim();
            string decryptedPin = EncryptionUtility.Decrypt(storePin);

            if (decryptedPin == pin) { return true; }
            return false;

        }
        public static string ReturnUserPin()
        {
            if (user == null) { return "false"; }

            string credentialsFile = Path.Combine(userPath, credentialsFilename);
            if (!File.Exists(credentialsFile)) { return  "false"; }
            string storedPin = File.ReadAllText(credentialsFile).Trim();
            return EncryptionUtility.Decrypt(storedPin);

        }
        public static string[] GetAllUsers()
        {
            string[] users = Directory.GetDirectories(usersPath);
            users = users.Select(path => Path.GetFileName(path)).ToArray();
            return users;
        }
        public static bool CreateUser(string username, string pin, bool updatePinOnly)
        {
            if (!updatePinOnly)
            {
                if (userPath != null) { return false; }

                string encryptedPin = EncryptionUtility.Encrypt(pin);

                string userFolder = Path.Combine(usersPath, username);
                string userCredentials = Path.Combine(userFolder, credentialsFilename);

                Directory.CreateDirectory(userFolder);
                File.WriteAllText(userCredentials, encryptedPin);

                return true;
            }

            string updatedEncryptedPin = EncryptionUtility.Encrypt(pin);
            string updatedUserFolder = Path.Combine(usersPath, username);
            string updatedUserCredentials = Path.Combine(updatedUserFolder, credentialsFilename);

            File.WriteAllText(updatedUserCredentials, updatedEncryptedPin);
            return true;
        }
        public static string GetTooltrack()
        {
            if (user == null) { return "false"; }

            string file = Path.Combine(userPath, tooltrackFilename);
            if (!File.Exists(file)) { return "false"; }

            string text = File.ReadAllText(file);

            return text;

        }

        public static string GetGrandAvenue()
        {
            if (user == null) { return "false"; }

            string file = Path.Combine(userPath, grandavenueFilename);
            if (!File.Exists(file)) { return "false"; }

            string text = File.ReadAllText(file);

            return text;

        }

        public static string GetNetsuite()
        {
            if (user == null) { return "false"; }

            string file = Path.Combine(userPath, netsuiteFilename);
            if (!File.Exists(file)) { return "false"; }

            string text = File.ReadAllText(file);

            return text;

        }
 
        public static bool SetToolTrack(string username, string password)
        {
            if (user == null) { return false; }

            string text = $"username: {username}\npassword: {EncryptionUtility.Encrypt(password)}";

            string file = Path.Combine(userPath, tooltrackFilename);
            File.WriteAllText(file, text);

            return true;
        }

        public static bool SetGrandAvenue(string username, string password)
        {
            if (user == null) { return false; }

            string text = $"username: {username}\npassword: {EncryptionUtility.Encrypt(password)}";

            string file = Path.Combine(userPath, grandavenueFilename);
            File.WriteAllText(file, text);

            return true;
        }

        public static bool SetNetsuite(string username, string password)
        {
            if (user == null) { return false; }

            string text = $"username: {username}\npassword: {EncryptionUtility.Encrypt(password)}";

            string file = Path.Combine(userPath, netsuiteFilename);
            File.WriteAllText(file, text);

            return true;
        }


        //public static void SetLoginMethod(bool usingPin)
        //{
        //    loggedIn = usingPin;
        //}
        //public static void SaveUser(string username, string password)
        //{
        //    string encryptedPassword = EncryptionUtility.Encrypt(password);
        //    string line = $"{username}: {encryptedPassword}";
        //    File.AppendAllLines(GetFilePath(), new[] { line });
        //}
        //public static string? GetPassword(string username)
        //{
        //    var filePath = GetFilePath();
        //    if (!File.Exists(filePath)) return null;

        //    foreach (var line in File.ReadAllLines(filePath))
        //    {
        //        var parts = line.Split(':');
        //        if (parts.Length == 2 && parts[0] == username)
        //        {
        //            return EncryptionUtility.Decrypt(parts[1]);
        //        }
        //    }

        //    return null;
        //}
        //public static string[] GetUsers()
        //{
        //    List<string> users = new List<String>();
        //    var filePath = GetFilePath();
        //    if (!File.Exists(filePath)) return null;

        //    foreach (var line in File.ReadAllLines(filePath))
        //    {
        //        var parts = line.Split(":");
        //        if (parts.Length > 0 && !string.IsNullOrWhiteSpace(parts[0]))
        //        {
        //            users.Add(parts[0].Trim());
        //        }
        //    }
        //    return users.ToArray();
        //}
        //public static bool FindAndDelete(string user)
        //{
        //    string[] filePath = { pinFilePath, gaFilePath };
        //    bool anyFound = false;

        //    for (int i = 0; i < filePath.Length; i++)
        //    {
        //        if (!File.Exists(filePath[i]))
        //            continue;

        //        var lines = File.ReadAllLines(filePath[i]).ToList();
        //        bool found = false;

        //        for (int j = 0; j < lines.Count; j++)
        //        {
        //            var parts = lines[j].Split(':');
        //            if (parts.Length > 0 && parts[0].Trim() == user.Trim())
        //            {
        //                lines.RemoveAt(j);
        //                found = true;
        //                break;
        //            }
        //        }

        //        if (found)
        //        {
        //            File.WriteAllLines(filePath[i], lines);
        //            anyFound = true;
        //        }
        //    }

        //    return anyFound;
        //}
    }
}
