using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Security;
using System.Text.RegularExpressions;
using System.Collections;

namespace Zeje.Utils
{

    /// <summary>
    /// �ַ���ʵ����
    /// </summary>
    public sealed class String_
    {
        private String_()
        {
        }
        /// <summary>ɾ���ַ���β���Ļس�/����/�ո�
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                if (str[i].Equals(" ") || str[i].Equals("\r") || str[i].Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }
        /// <summary>�ض�
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Truncation(string str, int len)
        {
            if (str == null || str.Length == 0 || len <= 0)
            {
                return string.Empty;
            }

            int l = str.Length;

            #region ���㳤��
            int clen = 0;
            while (clen < len && clen < l)
            {
                //ÿ����һ�����ģ���Ŀ�곤�ȼ�һ�� 
                if ((int)str[clen] > 128) { len--; }
                clen++;
            }
            #endregion

            if (clen < l)
            {
                return str.Substring(0, clen) + "...";
            }
            else
            {
                return str;
            }
        }
        /// <summary>���ַ�����ָ��λ�ý�ȡָ�����ȵ����ַ���
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="startIndex">���ַ�������ʼλ��</param>
        /// <param name="length">���ַ����ĳ���</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (str == null)
            {
                str = "";
            }
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }
                if (startIndex > str.Length)
                {
                    return "";
                }
            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }
            return str.Substring(startIndex, length);
        }
        /// <summary>���ַ����Ŀ�ʼλ�ý�ȡ���ַ���ָ��λ��
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="length">�ַ���ָ��λ��</param>
        /// <param name="endstr">�ַ���ĩβ�滻���ַ���</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int length, string endstr)
        {
            if (str.Length > length)
            {
                return str.Substring(0, length) + endstr;
            }
            else
            {
                return str;
            }
        }
        /// <summary>���ַ�����ָ��λ�ÿ�ʼ��ȡ���ַ�����β���˷���
        /// </summary>
        /// <param name="str">ԭ�ַ���</param>
        /// <param name="startIndex">���ַ�������ʼλ��</param>
        /// <returns>���ַ���</returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }
        /// <summary>�ָ��ַ���
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                string[] tmp = { strContent };
                return tmp;
            }
            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }
        /// <summary>���� HTML �ַ����ı�����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
        public static string HtmlEncode(string str)
        {
            if (str == null)
                return null;
            return str.Replace(" ", "&nbsp;").Replace("\r\n", "<br />");
        }
        /// <summary>���� HTML �ַ����Ľ�����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
        public static string HtmlDecode(string str)
        {
            if (str == null)
                return null;
            return str.Replace("&nbsp;", " ").Replace("<br />", "\r\n");
        }
        /// <summary>���� URL �ַ����ı�����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        /// <summary>���� URL �ַ����ı�����
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }
        /// <summary>ɾ�����һ���ַ�
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearLastChar(string str)
        {
            if (str == "")
                return "";
            else
                return str.Substring(0, str.Length - 1);
        }
        /// <summary>���ƴ��
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        /// <summary>��õ������ĵ�ƴ��
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        public static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
        /// <summary>�ַ�������ٹ�ָ�������򽫳����Ĳ�����ָ���ַ�������
        /// </summary>
        /// <param name="p_SrcString">Ҫ�����ַ���</param>
        /// <param name="p_Length">ָ������</param>
        /// <param name="p_TailString">�����滻���ַ���</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }
        /// <summary>
        /// ȡָ�����ȵ��ַ���
        /// </summary>
        /// <param name="p_SrcString">Ҫ�����ַ���</param>
        /// <param name="p_StartIndex">��ʼλ��</param>
        /// <param name="p_Length">ָ������</param>
        /// <param name="p_TailString">�����滻���ַ���</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;

            //�������Ļ���ʱ(ע:���ĵķ�Χ:\u4e00 - \u9fa5, ������\u0800 - \u4e00, ����Ϊ\xAC00-\xD7A3)
            if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") ||
                System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
            {
                //����ȡ����ʼλ�ó����ֶδ�����ʱ
                if (p_StartIndex >= p_SrcString.Length)
                {
                    return "";
                }
                else
                {
                    return p_SrcString.Substring(p_StartIndex,
                                                   ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }


            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //���ַ������ȴ�����ʼλ��
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //��Ҫ��ȡ�ĳ������ַ�������Ч���ȷ�Χ��
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //��������Ч��Χ��ʱ,ֻȡ���ַ����Ľ�β

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }



                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {

                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                            {
                                nFlag = 1;
                            }
                        }
                        else
                        {
                            nFlag = 0;
                        }

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                    {
                        nRealLength = p_Length + 1;
                    }

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);

                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }
    }
}
