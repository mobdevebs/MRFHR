using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Application.DataAccess.Utility
{
    public static class CommonUtility
    {
        public static DataTable ToDataTable<T>(List<T> items)        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static string EncodePassword(string pass, string salt)
        {
            string EncodePass = "";
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(pass);
                byte[] src = Encoding.Unicode.GetBytes(salt);
                byte[] dst = new byte[src.Length + bytes.Length];
                System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
                System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
                HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
                byte[] inArray = algorithm.ComputeHash(dst);
                EncodePass = EncodePasswordMd5(Convert.ToBase64String(inArray));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return EncodePass;
        }
        //Encrypt using MD5
        public static string EncodePasswordMd5(string pass)
        {
            string MD5Str = "";
            try
            {
                Byte[] originalBytes;
                Byte[] encodedBytes;
                MD5 md5;
                md5 = new MD5CryptoServiceProvider();
                originalBytes = ASCIIEncoding.Default.GetBytes(pass);
                encodedBytes = md5.ComputeHash(originalBytes);
                MD5Str = BitConverter.ToString(encodedBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return MD5Str;
        }
    }

    
}
