using System;

namespace MatchThree.Core
{
    public class CellButtonPressedArgs : EventArgs
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
