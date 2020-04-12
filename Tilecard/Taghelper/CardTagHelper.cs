using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Web.UI.TagHelpers.Card;

namespace IPTS.Web.UI.TagHelpers
{
    [HtmlTargetElement("ipts-cardtile")]
    public class IptsCardTagHelper : TagHelper
    {
        [HtmlAttributeName("HeaderTitle")]
        public string HeaderTitle { get; set; }

        [HtmlAttributeName("TextDescription")]
        public string TextDescription { get; set; }

        [HtmlAttributeName("CardSourceList")]
        public List<string> CardSourceList { get; set; }

        [HtmlAttributeName("ButtonType")]
        public string ButtonType { get; set; }

        [HtmlAttributeName("CardWidth")]
        public int CardWidth { get; set; }

        private TagBuilder card;
        private TagBuilder accordian;
        private TagBuilder cardHeader;
        private TagBuilder accordianToggle;
        private TagBuilder gridContainer;
        private TagBuilder checkBox;
        private TagBuilder image;
        private TagBuilder collapse;
        private TagBuilder cardBody;
        private TagBuilder toolset;

        private string htmlUniqueId = "2";

        public int cardCount => CardSourceList.Count();

        public int CardColumnCount => CardDimensionRequirementSpecs.cardDimensionRequirementData[cardCount]._cardColumnCount;

        public int CardRowCount => CardDimensionRequirementSpecs.cardDimensionRequirementData[cardCount]._cardRowCount;

        public IptsCardTagHelper()
        {
            card = new TagBuilder("div");
            accordian = new TagBuilder("div");
            cardHeader = new TagBuilder("div");
            accordianToggle = new TagBuilder("cardheadertext");
            gridContainer = new TagBuilder("div");
            checkBox = new TagBuilder("label");
            collapse = new TagBuilder("div");
            cardBody = new TagBuilder("div");
            image = new TagBuilder("img");
            toolset = new TagBuilder("span");
        }

        public static string GetString(IHtmlContent content)
        {
            using (var writer = new System.IO.StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {



            if (cardCount > CardDimensionRequirementSpecs.cardDimensionRequirementData.GetMaxKey())
            {
                throw new ArgumentException("Card Count exceeds maximum in requirement specs");
            }


            //Default value specified per UX specs, will be determined later
            if (CardWidth == 0)
            {
                CardWidth = 140;
            }


            TagBuilder cardouterspan = new TagBuilder("span");
            cardouterspan.AddCssClass("cardcontainer");

            CreateCard();
            CreateAccordian();
            CreateCardHeader();
            CreateAccordianToggle();
            CreateGridContainer();
            CreateImage();
            CreateCollapse();
            CreateCardBody();
            CreateToolset();

            /*
             Dom Tree

             Card Outer Span
                 Card
                    Accordian md-accordian
                        GridContainer
                            Checkbox (optional)
                            Images
                        Card Header
                            AccordianToggleCollapsed
                        Collapse
                            CardBody
            Toolset (optional)
            */

            gridContainer.InnerHtml.AppendHtml(image);

            cardHeader.InnerHtml.AppendHtml(accordianToggle);

            collapse.InnerHtml.AppendHtml(cardBody);

            accordian.InnerHtml.AppendHtml(gridContainer);
            accordian.InnerHtml.AppendHtml(cardHeader);
            accordian.InnerHtml.AppendHtml(collapse);

            card.InnerHtml.AppendHtml(accordian);


            cardouterspan.InnerHtml.AppendHtml(card);




            string CardHtmlString = GetString(cardouterspan);

            output.Content.SetHtmlContent(CardHtmlString);
        }

        private void CreateCard()
        {
            int cardCount = CardSourceList.Count();

            var CardRequirementLine = CardDimensionRequirementSpecs.cardDimensionRequirementData[cardCount];
            int cardColumnCount = CardRequirementLine._cardColumnCount;
            int cardRowCount = CardRequirementLine._cardRowCount;

            string CardWidthString = (CardWidth * cardColumnCount).ToString("N");
            card.AddCssClass("card");
            card.MergeAttribute("style", "width: " + CardWidthString + "px");
        }

        private void CreateAccordian()
        {

            accordian.AddCssClass("accordian md-accordion");
            accordian.MergeAttribute("id", "accordionEx");
            accordian.MergeAttribute("role", "tablist");
            accordian.MergeAttribute("aria-multiselectable", "true");
        }

        private void CreateCardHeader()
        {
            // TagBuilder cardheader = new TagBuilder("div");
            cardHeader.AddCssClass("card-header");
            cardHeader.MergeAttribute("role", "tab");
            cardHeader.MergeAttribute("id", "headingOne1");
        }

        private void CreateAccordianToggle()
        {
            accordianToggle.AddCssClass("accordion-toggle collapsed");
            accordianToggle.MergeAttribute("data-toggle", "collapse");
            accordianToggle.MergeAttribute("data-parent", "#accordionEx");
            accordianToggle.MergeAttribute("href", "#" + htmlUniqueId);
            accordianToggle.MergeAttribute("aria-expanded", "true");
            accordianToggle.MergeAttribute("aria-controls", htmlUniqueId);
            accordianToggle.InnerHtml.AppendHtml(this.HeaderTitle);
        }

        private void CreateGridContainer()
        {
            gridContainer.AddCssClass("grid-container");
            gridContainer.MergeAttribute("id", "grid" + htmlUniqueId);
            gridContainer.MergeAttribute("style",
                @"  display: grid;
                    grid-template-columns: repeat(" + CardColumnCount + @", " + CardWidth + @"px);
                    grid-template-rows: repeat(" + CardRowCount + @", " + CardWidth + @"px);
                    grid-gap: 1px;
                    padding: 0px;
                    align-items: stretch;
                    position: relative; ");
        }



        private void CreateImage()
        {

            int cardCounter = 0;
            image.AddCssClass("imgcard");
            image.MergeAttribute("src", CardSourceList[cardCounter]);
            image.MergeAttribute("id", "img" + htmlUniqueId + cardCounter.ToString());
            cardCounter = cardCounter + 1;

            while (cardCounter <= (cardCount - 1))
            {
                TagBuilder newimage = new TagBuilder("img");
                newimage.AddCssClass("imgcard");
                newimage.MergeAttribute("src", CardSourceList[cardCounter]);
                newimage.MergeAttribute("id", "img" + htmlUniqueId + cardCounter.ToString());

                cardCounter = cardCounter + 1;
                image.InnerHtml.AppendHtml(newimage);
            }
        }

        private void CreateCollapse()
        {
            collapse.AddCssClass("collapse");
            collapse.MergeAttribute("id", htmlUniqueId);
            collapse.MergeAttribute("role", "tabpanel");
            collapse.MergeAttribute("aria-labelledby", "headingOne1");
            collapse.MergeAttribute("data-parent", "#accordionEx");
        }

        private void CreateCardBody()
        {
            cardBody.AddCssClass("card-body");
            cardBody.InnerHtml.AppendHtml(this.TextDescription);
        }


        private void CreateToolset()
        {
            TagBuilder deleteicon = new TagBuilder("div");
            deleteicon.AddCssClass("cardtoolsetdelete");
            deleteicon.InnerHtml.AppendHtml("delete");

            TagBuilder notificationicon = new TagBuilder("div");
            notificationicon.AddCssClass("cardtoolsetnotification");
            notificationicon.InnerHtml.AppendHtml("notifications");

            toolset.InnerHtml.AppendHtml(deleteicon);
            toolset.InnerHtml.AppendHtml(notificationicon);

        }


    }
}




