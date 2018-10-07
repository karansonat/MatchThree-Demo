using System;
using System.Collections.Generic;

namespace MatchThree.Core
{
    public class MatchCheckCompletedArgs : EventArgs
    {
        public List<CellController> MatchedCells { get; private set; }
        public MatchCheckCompletedArgs(List<CellController> matchedCells)
        {
            MatchedCells = matchedCells;
        }
    }
}
