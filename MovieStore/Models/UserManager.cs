using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStore.Models;
using System.Text;
using System.Security.Cryptography;
namespace MovieStore.Models
{
    public class UserManager
    {
        public bool CheckUsername(string username) {
            //Xuong database check trung username
            //neu co ton tai trong DB --> true
            Model1 db = new Model1();
            khachhang kh = db.khachhangs.Where(x => x.username.Equals(username)).SingleOrDefault();
            if (kh == null)
            { return true; }
            return false;
        }
        public bool CheckEmail(string email)
        {
            //Xuong database check trung email
            //neu co ton tai trong DB --> true
            Model1 db = new Model1();
            khachhang kh = db.khachhangs.Where(x => x.email.Equals(email)).SingleOrDefault();
            if (kh == null)
            { return true; }
            return false;
        }
        public static string PasswordEncryption(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();
            return result;
        }
        //public bool CheckLogin(string username, string password)
        //{
        //    //Xuong database check trung email
        //    //neu co ton tai trong DB --> true
        //    Model1 db = new Model1();
        //    khachhang kh = db.khachhangs.Where(u => u.username.Equals(username) && u.password.Equals(password)).SingleOrDefault();
        //    if (kh != null)
        //    { return true; }
        //    return false;
        //}
    }
}