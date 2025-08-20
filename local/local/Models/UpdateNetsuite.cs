using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local.Models
{
    internal class UpdateNetsuite
    {
        private User _user;
        private IPage? page;
        private IBrowser browser;
        private IPlaywright playwright;

        public UpdateNetsuite(User user)
        {
            _user = user;
        }

        private string T4PN = "90-00019";
        private string CortisolPN = "90-00020";
        private string PrgPN = "90-00058";
        private string cCRPpn = "90-00107";
        private string NuQPN = "90-00111";

        public async Task<bool> UpdateNetsuiteStatus(string lotNumber)
        {
            if (!_user.NetsuiteExists)
            {
                throw new Exception("Error: Netsuite credentials not set.");
            }

            string partNumber = lotNumber.Substring(0, 2);
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



            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://6788613.app.netsuite.com/app/accounting/transactions/statchng.nl?whence=", new PageGotoOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });

            //await page.GotoAsync("https://6788613.app.netsuite.com/app/login/secure/enterpriselogin.nl?c=6788613&redirect=%2Fapp%2Fcenter%2Fcard.nl%3Fsc%3D-29%26whence%3D&whence=", new PageGotoOptions
            //{
            //    WaitUntil = WaitUntilState.NetworkIdle
            //});

            await page.FillAsync("input[id='email']", _user.GetNetsuiteUsername());
            await page.FillAsync("input[id='password']", _user.GetNetsuitePassword());

            await page.ClickAsync("button[type='submit']");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var securityPassword = await page.QuerySelectorAsync("input[type='password']");
            if (securityPassword != null)
            {
                await page.FillAsync("input[type='password']", "firestone");
                await page.ClickAsync("input[type='submit']");
                await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            }

            await page.Keyboard.PressAsync("Tab");
            await page.Keyboard.PressAsync("ArrowDown");

            await page.Keyboard.PressAsync("Tab");
            for (var i = 0; i < 13; i++)
            {
                await page.Keyboard.PressAsync("ArrowDown");
            }

            await page.Keyboard.PressAsync("Tab");
            for (var i = 0; i < 4; i++)
            {
                await page.Keyboard.PressAsync("ArrowDown");
            }

            await page.FillAsync("input[id='inventory_item_display']", partNumber);
            await page.Keyboard.PressAsync("Enter");

            await page.Keyboard.PressAsync("Tab");
            await page.Keyboard.PressAsync("Tab");

            // Does not type yet TODO 
            await page.Keyboard.TypeAsync("1");

            await page.DblClickAsync("td[data-ns-tooltip='Inventory Detail']");

            return true;
        }






    }
}
