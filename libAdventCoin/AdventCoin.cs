#region Information

// AdventOfCode: libAdventCoin
// Created: 2015-12-04
// Modified: 2015-12-04 11:24 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Security.Cryptography;
using System.Text;

#endregion

namespace libAdventCoin
{
    public class AdventCoin
    {
        #region Constructors
        public AdventCoin() : this(null) {}
        public AdventCoin(string key) : this(key, null) {}

        public AdventCoin(string key, int? val)
        {
            Key = key;
            Value = val;
        }
        #endregion

        #region Properties
        public string Key { get; set; }
        public string Md5Hash => CalculateMD5Hash($"{Key}{Value}");
        public int? Value { get; set; }
        #endregion

        public bool Match(string start) => Md5Hash.StartsWith(start);

        /// <summary>
        ///     Calculate MD5H hash
        /// </summary>
        /// <param name="input">String to Hahs</param>
        /// <returns>MD5 hash in Hex string</returns>
        /// <remarks>http://blogs.msdn.com/b/csharpfaq/archive/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string_3f00_.aspx</remarks>
        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}