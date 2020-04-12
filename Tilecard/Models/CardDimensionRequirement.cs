using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTS.Web.UI.TagHelpers.Card
{

    public class CardDimensionRequirement : Dictionary<int, CardDimensionRequirementLine>
    {
        public void AddItem(int PictureCount, int Length, int Height, int BootstrapDimension)
        {
            base.Add(PictureCount, new CardDimensionRequirementLine(PictureCount, Length, Height, BootstrapDimension));
        }

        public int GetMaxKey()
        {
            return base.Keys.Max();
        }
    }
}
