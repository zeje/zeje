using System.Security.Cryptography;

namespace Zeje.Utils
{
    public partial class Encrypt_
    {
        #region MD5����
        /// <summary>
        /// MD5����,�����ã�using System.Security.Cryptography;
        /// </summary>
        /// <param name="str">ԭʼ�ַ���</param>
        /// <returns>MD5���</returns>
        public static string MD5(string str)
        {
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(str);//Encoding.Default.GetBytes(str);
            bs = new MD5CryptoServiceProvider().ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToUpper());
            }
            return s.ToString();
        }
        #endregion
    }
}
