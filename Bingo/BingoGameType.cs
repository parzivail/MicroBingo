using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bingo
{
    public interface IBingoGameType
    {
        List<int> GetLegalCategories();

        string GetName();
    }
}
