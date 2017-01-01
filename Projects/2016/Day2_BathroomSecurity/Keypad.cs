#region Information

// AdventOfCode: Day2_BathroomSecurity
// Created: 2016-12-02
// Modified: 2016-12-03 5:50 PM
#endregion

#region Using Directives
#endregion

#region Using Directives
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day2_BathroomSecurity
{
    public static partial class Program
    {
        /// <summary>
        ///     Generates a standard 3x3 key pad with numbers 1-9.
        /// </summary>
        private static void GenerateKeyPadSquare()
        {
            var k = 1;
            for (int i = _padMax; i >= 0; i--)
            {
                for (var j = 0; j <= _padMax; j++)
                {
                    _keyPad.Add(new Button(j, i, k.ToString()));
                    k++;
                }
            }
        }

        /// <summary>
        ///     Generates the key pad.
        /// </summary>
        private static void GenerateKeyPad()
        {
            _keyPad = new List<Button>();
            if (_squareKeypad)
            {
                GenerateKeyPadSquare();
            }
            else
            {
                GenerateKeyPadPoly();
            }
            Button startButton = _keyPad.First(x => x.Value.Equals("5"));
            _padX = startButton.ButtonCoordinates.X;
            _padY = startButton.ButtonCoordinates.Y;
        }

        /// <summary>
        ///     Generates a non-standard 4x4 key pad with 1-9 and A-D in a diamond formation.
        /// </summary>
        private static void GenerateKeyPadPoly()
        {
            _keyPad.Add(new Button(2, 4, 1));
            _keyPad.Add(new Button(1, 3, 2));
            _keyPad.Add(new Button(2, 3, 3));
            _keyPad.Add(new Button(3, 3, 4));
            _keyPad.Add(new Button(0, 2, 5));
            _keyPad.Add(new Button(1, 2, 6));
            _keyPad.Add(new Button(2, 2, 7));
            _keyPad.Add(new Button(3, 2, 8));
            _keyPad.Add(new Button(4, 2, 9));
            _keyPad.Add(new Button(1, 1, "A"));
            _keyPad.Add(new Button(2, 1, "B"));
            _keyPad.Add(new Button(3, 1, "C"));
            _keyPad.Add(new Button(2, 0, "D"));
        }
    }
}