using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTS.Web.UI.TagHelpers.Card
{
    // Exhibits the row and height configuration for number of cards
    public class CardDimensionRequirementLine
    {
        public int _pictureCount;
        public int _cardColumnCount;
        public int _cardRowCount;
        public int? _bootstrapDimension;

        public CardDimensionRequirementLine(int PictureCount, int CardColumnCount, int CardRowCount, int BootstrapDimension)
        {
            _pictureCount = PictureCount;
            _cardColumnCount = CardColumnCount;
            _cardRowCount = CardRowCount;
            _bootstrapDimension = BootstrapDimension;
        }

    }
}


