#region Information

// AdventOfCode: Day4_SecurityThroughObscurity
// Created: 2016-12-04
// Modified: 2016-12-04 9:46 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace Day4_SecurityThroughObscurity
{
    /// <summary>
    ///     Represents a Room, with encrypted name.
    /// </summary>
    public class Room
    {
        #region  Fields
        private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        #endregion

        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Room" /> class.
        /// </summary>
        /// <param name="data">The data containing room name, sector ID and checksum.</param>
        public Room(string data)
        {
            // Match characters between [ and ]
            var checksumRegex = new Regex(@"(?<=\[)\w+(?=\])");

            // Match numerical digits
            var sectorIdRegex = new Regex(@"\d+");

            // Get room name (no sector ID or checksum)
            var roomNameRegex = new Regex(@"^[A-z-]+");

            CheckSum = checksumRegex.Match(data).Value;
            SectorId = Convert.ToInt32(sectorIdRegex.Match(data).Value);
            RoomName = roomNameRegex.Match(data).Value;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the check sum.
        /// </summary>
        /// <value>
        ///     The check sum.
        /// </value>
        public string CheckSum { get; set; }

        /// <summary>
        ///     Gets or sets the decrypted Room name.
        /// </summary>
        /// <value>
        ///     The decrypted name of the Room.
        /// </value>
        public string DecryptedRoomName
            => new string(RoomName.Select(c => c.Equals('-') ? ' ' : RotateLetter(c, SectorId)).ToArray());

        /// <summary>
        ///     Gets or sets a value indicating whether this Room is real.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is real; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        ///     From puzzle.txt:
        ///     A room is real (not a decoy) if the checksum is the five most common letters in the encrypted name, in order,
        ///     with ties broken by alphabetization
        /// </remarks>
        public bool IsReal => CheckSum.Equals(MostCommonLetters);

        /// <summary>
        ///     Gets the most common letters.
        /// </summary>
        /// <value>
        ///     The most common letters.
        /// </value>
        /// <remarks>
        ///     Letters are sorted by most frequent -> least frequent,
        ///     ordered alphabetically in the event of a tie.
        ///     Only the 5 most frequently-used characters are returned.
        /// </remarks>
        public string MostCommonLetters
        {
            get
            {
                char[] roomChars = RoomName.ToCharArray();
                List<char> distinctChars = roomChars.Distinct().Except(new[] {'-'}).ToList();
                Dictionary<char, int> occurrences = distinctChars.ToDictionary(c => c,
                                                                               c => roomChars.Count(x => x.Equals(c)));
                return new string(
                           occurrences.OrderByDescending(x => x.Value)
                                      .ThenBy(x => x.Key)
                                      .Select(x => x.Key)
                                      .Take(5)
                                      .ToArray());
            }
        }

        /// <summary>
        ///     Gets or sets the name of the room.
        /// </summary>
        /// <value>
        ///     The name of the room.
        /// </value>
        public string RoomName { get; set; }

        /// <summary>
        ///     Gets or sets the sector identifier.
        /// </summary>
        /// <value>
        ///     The sector identifier.
        /// </value>
        public int SectorId { get; set; }
        #endregion

        /// <summary>
        ///     Rotate through the alphabet a number of times, rolling from z -> a.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="sectorId">The sector identifier.</param>
        /// <returns></returns>
        private static char RotateLetter(char c, int sectorId)
        {
            int index = Array.IndexOf(Alphabet, c);
            for (var i = 0; i < sectorId; i++)
            {
                index++;
                if (index == Alphabet.Length)
                {
                    index = 0;
                }
            }
            return Alphabet[index];
        }

        #region Overrides of Object
        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
            =>
            $"{DecryptedRoomName} {SectorId}, checksum {CheckSum}, calculated checksum {MostCommonLetters}. {(IsReal ? "Real" : "Decoy")}";
        #endregion
    }
}