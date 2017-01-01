#region Information

// AdventOfCode: Day19_AnElephantNamedJoseph
// Created: 2016-12-19
// Modified: 2016-12-19 8:14 PM
#endregion

namespace Day19_AnElephantNamedJoseph
{
    /// <summary>
    ///     Elf participating in the White Elephant party.
    /// </summary>
    public class Elf
    {
        #region Constructors
        /// <summary>
        ///     Initializes a new instance of the <see cref="Elf" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Elf(int id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the next elf.
        /// </summary>
        /// <value>
        ///     The next elf.
        /// </value>
        public Elf NextElf { get; set; }

        /// <summary>
        ///     Gets or sets the previous elf.
        /// </summary>
        /// <value>
        ///     The previous elf.
        /// </value>
        public Elf PreviousElf { get; set; }
        #endregion
    }
}