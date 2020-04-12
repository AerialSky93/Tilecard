using IPTS.Web.UI.TagHelpers.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.TagHelpers.Card
{
    //Row and height configuration given in UI specs, seeding initial data
    static class CardDimensionRequirementSpecs
    {
        public static CardDimensionRequirement cardDimensionRequirementData;

        static CardDimensionRequirementSpecs()
        {
            //int PictureCount, int Length, int Height, int BootstrapDimension
            cardDimensionRequirementData = new CardDimensionRequirement();
            cardDimensionRequirementData.AddItem(1, 1, 1, 1);
            cardDimensionRequirementData.AddItem(2, 2, 1, 6);
            cardDimensionRequirementData.AddItem(3, 3, 1, 4);
            cardDimensionRequirementData.AddItem(4, 2, 2, 6);
            cardDimensionRequirementData.AddItem(5, 3, 2, 4);
            cardDimensionRequirementData.AddItem(6, 3, 2, 4);
        }
    }
}
