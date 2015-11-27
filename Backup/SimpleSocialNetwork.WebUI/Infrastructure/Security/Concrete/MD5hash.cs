using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace SimpleSocialNetwork.WebUI.Security.Concrete
{
    public class MD5Hash : IHash
    {
        public System.Guid HashString(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] byteArr = md5.ComputeHash(Encoding.Default.GetBytes(text));
                Guid hashedString = new Guid(byteArr);
                return hashedString;
            }
        }
    }
}