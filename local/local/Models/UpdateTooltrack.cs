using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace local.Models
{
    internal class UpdateTooltrack
    {
        private User _user;
        private IPage? page;
        private IBrowser? browser;
        private IPlaywright? playwright;

        private string pin = "99474";

        public UpdateTooltrack(User user)
        {
            _user = user;
        }

        private string T4PN = "90-00019";
        private string CortisolPN = "90-00020";
        private string PrgPN = "90-00058";
        private string cCRPpn = "90-00107";
        private string NuQPN = "90-00111";

        public async Task<bool> UpdateToolTrackStatus(string LN, string calibrator, string qc, string pass, string failureMode)
        {

                if (!_user.TooltrackExists)
                {
                    throw new Exception("Error: ToolTrack credentials not set.");
                }
                var playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });

                var page = await browser.NewPageAsync();
                await page.GotoAsync("https://app.itrackware.com/apex/f?p=970:LOGIN_DESKTOP:16407640746170:::::&tz=-6:00", new PageGotoOptions
                {
                    WaitUntil = WaitUntilState.NetworkIdle
                });

                await page.FillAsync("input[name='P101_USERNAME']", _user.GetTooltrackUsername());
                await page.FillAsync("input[name='P101_PASSWORD']", _user.GetTooltrackPassword());

                await page.ClickAsync("button[id='P101_LOGIN']");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                await page.ClickAsync("li[id='t_TreeNav_2']");

                for (int i = 0; i < 10; i++)
                {
                    await page.EvaluateAsync("window.scrollBy(0, window.innerHeight);");
                    await Task.Delay(500);
                }


                var selector = $"tr:has(td:text('{LN}')) a:has-text('MOVE IN')";
                var moveInLink = await page.QuerySelectorAsync(selector);

                if (moveInLink == null)
                {
                    await browser.DisposeAsync();
                    throw new TimeoutException($"Error: {LN} not found.");
                }
                else
                {
                    await moveInLink.ClickAsync();
                    await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

                    await page.FillAsync("input[id='P11_USER_PIN']", pin);
                    await page.ClickAsync($"button:has-text('Start Process')");
                    await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
                }


                await page.ClickAsync("label[for='P11_PROC_FINISHED_0']");
                await page.FillAsync("input[id='P11_WAFER_QTY_OUT']", "1");
                await page.FillAsync("input[id='P11_USER_PIN']", pin);

                for (int i = 0; i < 10; i++)
                {
                    await page.EvaluateAsync("window.scrollBy(0, window.innerHeight);");
                    await Task.Delay(500);
                }

                var saveBtn = await page.QuerySelectorAsync("span:has-text('Save')");


                //var cell = await page.QuerySelectorAsync("tbody > tr:nth-child(1) > td:nth-child(8)");
                //if (cell != null)
                //{
                //    await cell.HoverAsync();
                //    await Task.Delay(100); // Give time for hover effect
                //    await cell.DblClickAsync();
                //    await Task.Delay(150); // Wait for grid to enter edit mode
                //    await page.Keyboard.TypeAsync("90-00019");

                //}

                // Determine part number based on substring 0,2 of ln
                string partNumber = LN.Substring(0,2);
                if (partNumber == "HT") 
                {
                    partNumber = T4PN;
                }
                else if (partNumber == "HC") 
                {
                    partNumber = CortisolPN;
                }
                else if (partNumber == "HP")
                {
                    partNumber = PrgPN;
                }
                else if (partNumber == "HR")
                {
                    partNumber = cCRPpn;
                }
                else if (partNumber == "HN")
                {
                    partNumber = NuQPN;
                }
                else
                {
                    throw new Exception("Error: part number does not match any of the configured ones.");
                }

            // Part number
            var pnCell = await page.QuerySelectorAsync("tbody > tr:nth-child(1) > td:nth-child(8)");
                if (pnCell != null)
                {
                    await pnCell.HoverAsync();
                    await Task.Delay(100); // Give time for hover effect
                    await pnCell.DblClickAsync();
                    await Task.Delay(150); // Wait for grid to enter edit mode
                    await page.Keyboard.TypeAsync($"{partNumber}");
                }
                // Lot number
                var LNCell = await page.QuerySelectorAsync("tbody > tr:nth-child(2) > td:nth-child(8)");
                if (LNCell != null)
                {
                    await LNCell.HoverAsync();
                    await Task.Delay(100); // Give time for hover effect
                    await LNCell.DblClickAsync();
                    await Task.Delay(150); // Wait for grid to enter edit mode
                    await page.Keyboard.TypeAsync($"{LN}");
                }
                // Calibrator lot number
                var calCell = await page.QuerySelectorAsync("tbody > tr:nth-child(3) > td:nth-child(8)");
                if (calCell != null)
                {
                    await calCell.HoverAsync();
                    await Task.Delay(100); // Give time for hover effect
                    await calCell.DblClickAsync();
                    await Task.Delay(150); // Wait for grid to enter edit mode
                    await page.Keyboard.TypeAsync($"{calibrator}");
                }
                // QC Sample lot number
                var QcCell = await page.QuerySelectorAsync("tbody > tr:nth-child(4) > td:nth-child(8)");
                if (QcCell != null)
                {
                    await QcCell.HoverAsync();
                    await Task.Delay(100); // Give time for hover effect
                    await QcCell.DblClickAsync();
                    await Task.Delay(150); // Wait for grid to enter edit mode
                    await page.Keyboard.TypeAsync($"{qc}");
                }
                // Pass - Fail
                var pCell = await page.QuerySelectorAsync("tbody > tr:nth-child(5) > td:nth-child(7)");
                if (pCell != null)
                {
                    await pCell.HoverAsync();
                    await Task.Delay(100); // Give time for hover effect
                    await pCell.DblClickAsync();
                    await Task.Delay(150); // Wait for grid to enter edit mode
                    await page.Keyboard.TypeAsync($"{pass}");
                }
                // Failure Reason
                var failureCell = await page.QuerySelectorAsync("tbody > tr:nth-child(6) > td:nth-child(6)");
                if (failureCell != null)
                {
                    await failureCell.HoverAsync();
                    await Task.Delay(100); // Give time for hover effect
                    await failureCell.DblClickAsync();
                    await Task.Delay(150); // Wait for grid to enter edit mode
                    await page.Keyboard.TypeAsync($"{failureMode}");
                }

                await saveBtn.ClickAsync();
                await Task.Delay(100);
                var submitBtn = await page.QuerySelectorAsync("button:has-text('Apply Changes')");
                await submitBtn.ClickAsync();
                await Task.Delay(1000);
                await browser.DisposeAsync();

                return true;

        }


    }
}
