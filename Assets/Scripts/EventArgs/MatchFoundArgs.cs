using System;
using System.Collections.Generic;

namespace MatchThree.Core
{
    public class MatchFoundArgs : EventArgs
    {
        public List<CellController> MatchedCells { get; private set; }
        public MatchFoundArgs(List<CellController> matchedCells)
        {
            MatchedCells = matchedCells;
        }
    }
}
