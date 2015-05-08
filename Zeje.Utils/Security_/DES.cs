using System;
using System.Text;
using System.Security.Cryptography;
namespace Zeje.Utils
{
    /// <summary>���븨����
    /// </summary>
    public partial class Encrypt_
    {
        /// <summary>
        /// </summary>
        private const string DESKey = "Zeje";

        #region DES����
        /// <summary>DES����
        /// </summary>
        /// <param name="strSource">�������ִ�</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESEncrypt(string strSource)
        {
            return DESEncrypt(strSource, DESKey);
        }
        /// <summary>DES����
        /// </summary>
        /// <param name="strSource">�������ִ�</param>
        /// <param name="key">Keyֵ</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESEncrypt(string strSource, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(strSource);
            des.Key = ASCIIEncoding.ASCII.GetBytes(MD5(key).Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(MD5(key).Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }
        #endregion

        #region DES����
        /// <summary>DES����
        /// </summary>
        /// <param name="strSource">�����ܵ��ִ�</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESDecrypt(string strSource)
        {
            return DESDecrypt(strSource, DESKey);
        }
        /// <summary>DES����
        /// </summary>
        /// <param name="strSource">�����ܵ��ִ�</param>
        /// <param name="key"></param>
        /// <returns>���ܺ���ַ���</returns>
        public static string DESDecrypt(string strSource, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = strSource.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(strSource.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(MD5(key).Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(MD5(key).Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

    }
}