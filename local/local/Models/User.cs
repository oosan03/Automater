using local.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace local.Models
{
    public class User
    {
        // App credentials
        private string _username;
        private string _password;

        // Tooltrack credentials
        private string _usernameTooltrack;
        private string _passwordTooltrack;

        // Grand avenue credentials
        private string _usernameGrandavenue;
        private string _passwordGrandavenue;

        // NetSuite credentials
        private string _usernameNetsuite;
        private string _passwordNetsuite;

        public bool TooltrackExists;
        public bool GrandavenueExists;
        public bool NetsuiteExists;

        public User()
        {
            SetTooltrack();
            SetGrandAvenue();
            SetNetsuite();
            SetAppCredentials();
        }


        public string GetAppUsername()
        {
            return _username;
        }
        public string GetAppPassword()
        {
            return _password;
        }
        public string GetTooltrackUsername()
        {
            return _usernameTooltrack;
        }
        public string GetTooltrackPassword()
        {
            return _passwordTooltrack;
        }
        public string GetGrandavenueUsername()
        {
            return _usernameGrandavenue;
        }
        public string GetGrandavenuePassword()
        {
            return _passwordGrandavenue;
        }

        public string GetNetsuiteUsername()
        {
            return _usernameNetsuite;
        }
        public string GetNetsuitePassword()
        {
            return _passwordNetsuite;
        }

        public void SetAppCredentials()
        {
            _username = FileUtility.user;
            _password = FileUtility.ReturnUserPin();
        }
        public void SetTooltrack()
        {
            string text = FileUtility.GetTooltrack();

            if (text is null or "false") { TooltrackExists = false; return; }

            _usernameTooltrack = Regex.Match(text, @"username:\s*([^\r\n]+)").Groups[1].Value.Trim();
            string password = Regex.Match(text, @"password:\s*([^\r\n]+)").Groups[1].Value.Trim();
            _passwordTooltrack = EncryptionUtility.Decrypt(password);


            TooltrackExists = true;
        }
        public void SetGrandAvenue()
        {
            string text = FileUtility.GetGrandAvenue();

            if (text is null or "" or "false") { GrandavenueExists = false; return; }

            _usernameGrandavenue = Regex.Match(text, @"username:\s*([^\r\n]+)").Groups[1].Value.Trim();
            string password = Regex.Match(text, @"password:\s*([^\r\n]+)").Groups[1].Value.Trim();
            _passwordGrandavenue = EncryptionUtility.Decrypt(password);

            GrandavenueExists = true;

        }
        public void SetNetsuite()
        {
            string text = FileUtility.GetNetsuite();

            if (text is null or "" or "false") { NetsuiteExists = false; return; }
            
            _usernameNetsuite = Regex.Match(text, @"username:\s*([^\r\n]+)").Groups[1].Value.Trim();
            string password = Regex.Match(text, @"password:\s*([^\r\n]+)").Groups[1].Value.Trim();
            _passwordNetsuite = EncryptionUtility.Decrypt(password);

            NetsuiteExists = true;

        }
    }
}
