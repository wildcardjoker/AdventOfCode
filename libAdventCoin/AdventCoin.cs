#region Information

// AdventOfCode: libAdventCoin
// Created: 2015-12-04
// Modified: 2015-12-04 9:46 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Security.Cryptography;

#endregion

namespace libAdventCoin
{
    public class AdventCoin
    {
        #region Constructors
        public AdventCoin() : this(null) {}

        public AdventCoin(string key)
        {
            Key = key;
        }
        #endregion

        #region Properties
        public string Key { get; set; }
        public string Md5Hash => MD5.Create($"{Key}{Value}").ToString();
        public int Value { get; set; }
        #endregion
    }
}