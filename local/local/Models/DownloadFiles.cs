using Microsoft.Playwright;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace local.Models
{
    internal class DownloadFiles
    {
        private IPage? page;
        private IBrowser? browser;
        private IPlaywright? playwright;

        private User _user;
        public DownloadFiles(User user)
        {
            _user = user;
        }

        public string download_path = string.Empty;
        public async Task<bool> RunDownloadAsync(string product)
        {
            try
            {
                string productType = product.Substring(0, 2).ToUpper();

                var playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = true
                });

                var context = await browser.NewContextAsync(new BrowserNewContextOptions
                {
                    AcceptDownloads = true
                });

                var page = await browser.NewPageAsync();
                await page.GotoAsync("https://mbiodx.grandavenue.com", new PageGotoOptions
                {
                    WaitUntil = WaitUntilState.NetworkIdle
                });

                // Enter username and password by name attribute
                await page.FillAsync("input[name='ctl52$5369676E496E5472616E73666F726D5F557365724944']", _user.GetGrandavenueUsername());
                await page.FillAsync("input[name='ctl52$6761735F63757272656E7450617373776F72644669656C64']", _user.GetGrandavenuePassword());

                await page.ClickAsync("input[type='submit']");

                // Wait for login
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                // Toggle search/chart tab
                await page.Keyboard.PressAsync("Tab");
                await page.Keyboard.PressAsync("Tab");
                await page.Keyboard.PressAsync("Tab");
                await page.Keyboard.PressAsync("Enter");

                // Call the download function for each form
                if (productType == "HT")
                {
                    // parrallel arrays in this order QC Form, SS, Prism File, SW Intensity, and SW Product
                    string[] go_to_link = { "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E313030323126436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E313030303426436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3737363126436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E313030383826436C6F736557696E646F773D596573" };
                    string[] click_link = { "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E3130303231']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E3130303034']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E37373631']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E3130303838']" };

                    for (int i = 0; i < go_to_link.Length; i++)
                    {
                        int index = i;
                        await DownloadForm(productType, page, browser, go_to_link[i], click_link[i], index);
                    }

                }
                if (productType == "HC")
                {
                    string[] go_to_link = { "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3932393526436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3932393626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3932393426436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3833373626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3836343826436C6F736557696E646F773D596573" };
                    string[] click_link = { "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfq2E3130353838']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39323936']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39323934']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38333736']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38363438']" };

                    for (int i = 0; i < go_to_link.Length; i++)
                    {
                        int index = i;
                        await DownloadForm(productType, page, browser, go_to_link[i], click_link[i], index);
                    }
                }
                if (productType == "HP")
                {
                    string[] go_to_link = { "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3937373626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3937373826436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3738303226436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3832313126436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3836343426436C6F736557696E646F773D596573" };
                    string[] click_link = { "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfq2E3130393038']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39373738']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E37383032']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38323131']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38363434']" };

                    for (int i = 0; i < go_to_link.Length; i++)
                    {
                        int index = i;
                        await DownloadForm(productType, page, browser, go_to_link[i], click_link[i], index);
                    }

                }
                if (productType == "HS")
                {
                    string[] go_to_link = { "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3937303526436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3937303626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3531333626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3836353026436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3836343526436C6F736557696E646F773D596573" };
                    string[] click_link = { "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfq2E3130383438']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39373036']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E35313336']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38363530']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38363435']" };

                    for (int i = 0; i < go_to_link.Length; i++)
                    {
                        int index = i;
                        await DownloadForm(productType, page, browser, go_to_link[i], click_link[i], index);
                    }
                }
                if (productType == "HR")
                {
                    string[] go_to_link = { "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3939373726436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3939373626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3939373826436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3834353626436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3836343926436C6F736557696E646F773D596573"
 };
                    string[] click_link = { "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfq2E3131303431']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39393736']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39393738']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38343536']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38363439']" };

                    for (int i = 0; i < go_to_link.Length; i++)
                    {
                        int index = i;
                        await DownloadForm(productType, page, browser, go_to_link[i], click_link[i], index);
                    }
                }
                if (productType == "HN")
                {
                    string[] go_to_link = { "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3932353526436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3933383926436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3839383526436C6F736557696E646F773D596573", "https://mbiodx.grandavenue.com/GrandAvenue/Core/Info/ViewEntity.aspx?Params=ab3Dfg2E3839383426436C6F736557696E646F773D596573"
 };
                    string[] click_link = { "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfq2E3130353336']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E39333839']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38393835']", "a[href='/GrandAvenue/Core/Info/ViewFileContent.aspx?Params=46696C65436F6E74656E74ab3Dfg2E38393834']" };

                    for (int i = 0; i < go_to_link.Length; i++)
                    {
                        int index = i;
                        await DownloadForm(productType, page, browser, go_to_link[i], click_link[i], index);
                    }
                }

                await browser.DisposeAsync();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex}");
                return false;
            }

        }
        private async Task<bool> DownloadForm(string productType, IPage page, IBrowser browser, string go_to_link, string click_link, int index)
        {
            string[] fileKey = { "QC Form", "Spreadsheet", "Prism File", "SW Intensity", "SW Product" };
            try
            {
                var downloadTask = page.WaitForDownloadAsync();
                await page.GotoAsync(go_to_link);

                var element = await page.QuerySelectorAllAsync(".WarningText");

                if (element.Count > 0)
                {
                    DialogResult result = MessageBox.Show(
                            "DEVIATION IN EFFECT\n Does deviation apply?",
                            "Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                     );

                    if (result == DialogResult.Yes) { MessageBox.Show("Please go download deviated file"); return true; }
                }

                await page.ClickAsync(click_link);
                var download = await downloadTask;
                //System.Windows.Forms.MessageBox.Show($"Download started: URL={download.Url}, Suggested filename={download.SuggestedFilename}");

                string savePath = Path.Combine(download_path, download.SuggestedFilename);
                //await Task.Delay(500);
                if (!File.Exists(savePath))
                {
                    await download.SaveAsAsync(savePath);
                    return true;
                }
                MessageBox.Show("File already exists!");
                return false;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }

        static void RenameFirstFileWithExtension(string directory, string extension, string newFileName)
        {
            var file = Directory.GetFiles(directory, "*" + extension).FirstOrDefault();
            if (file != null)
            {
                string newPath = Path.Combine(directory, newFileName);

                if (File.Exists(newPath))
                {
                    Console.WriteLine($"Cannot rename {Path.GetFileName(file)} to {newFileName} because the target file already exists.");
                    return;
                }

                File.Move(file, newPath);
                Console.WriteLine($"Renamed {Path.GetFileName(file)} to {newFileName}");
            }
            else
            {
                Console.WriteLine($"No file with extension {extension} found to rename.");
            }

        }

        public void RenameFolders(string folder_path, string lot_number)
        {
            string cdfFolder_name = "CAL and Product CDFs";
            string full_cdfFolder_path = Path.Combine(folder_path, cdfFolder_name);

            if (!Directory.Exists(full_cdfFolder_path))
            {
                Directory.CreateDirectory(full_cdfFolder_path);
            }

            var xmlFiles = Directory.GetFiles(folder_path, "*.xml").Take(2);

            foreach (var xmlFile in xmlFiles)
            {
                string fileName = Path.GetFileName(xmlFile);
                string destPath = Path.Combine(full_cdfFolder_path, fileName);
                File.Move(xmlFile, destPath);
            }

            string doc = $"{lot_number} QC Form";
            RenameFirstFileWithExtension(folder_path, ".docx", $"{doc}.docx");

            string ss = $"{lot_number} Data Sheet";
            RenameFirstFileWithExtension(folder_path, ".xlsx", $"{ss}.xlsx");

            string prism = $"{DateTime.Today.ToString("ddMMMyyyy").ToUpper()} {lot_number} Prism File";
            RenameFirstFileWithExtension(folder_path, ".prism", $"{prism}.prism");
            string pzfx = $"{DateTime.Today.ToString("ddMMMyyyy").ToUpper()} {lot_number} Prism File";
            RenameFirstFileWithExtension(folder_path, ".pzfx", $"{prism}.pzfx");


        }

        public string lotNumberValidation(string lotNumber, ref bool validLotNumber)
        {
            string pattern = @"^(HT|HR|HS|HC|HN|HP)-\d{5}$";
            string validatedLotNumber = lotNumber.Trim().Replace(" ", "").ToUpper();

            bool isMatch = Regex.IsMatch(validatedLotNumber, pattern);

            if (!isMatch)
            {
                validLotNumber = false;
            }
            else
            {
                validLotNumber = true;
            }
            return validatedLotNumber;
        }

    }
}
