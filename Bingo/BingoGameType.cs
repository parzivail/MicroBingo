using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bingo
{
    interface IBingoGameType
    {
        bool IsCategoryLegal(int category);

        string GetName();
    }
}
