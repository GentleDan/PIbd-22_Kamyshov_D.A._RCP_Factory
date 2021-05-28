using System;
using System.Collections.Generic;
using System.Text;

namespace ReinforcedConcreteFactoryBusinessLogic.Attributes
{
    public enum GridViewAutoSize
    {
        NotSet = 0,
        None = 1,
        ColumnHeader = 2,
        AllCellsExceptHeader = 4,
        AllCells = 6,
        DisplayedCellsExceptHeader = 8,
        DisplayedCells = 10,
        Fill = 16
    }
}
