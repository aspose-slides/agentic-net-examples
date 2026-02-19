using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export;
using Aspose.Slides.Export;
using Aspose.Slides.Export;

namespace PowerPointToHtml
{
    class CustomHtmlController : IHtmlFormattingController
    {
        public void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
        {
            // Insert custom CSS into the HTML header
            generator.AddHtml("<style>body { font-family: Arial, sans-serif; background-color: #f0f0f0; }</style>");
        }

        public void WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
        {
            // No custom footer needed
        }

        public void WriteShapeStart(IHtmlGenerator generator, IShape shape)
        {
            // No custom shape handling
        }

        public void WriteShapeEnd(IHtmlGenerator generator, IShape shape)
        {
            // No custom shape handling
        }

        public void WriteSlideStart(IHtmlGenerator generator, ISlide slide)
        {
            // No custom slide handling
        }

        public void WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
        {
            // No custom slide handling
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            Presentation presentation = new Presentation(inputPath);
            HtmlOptions htmlOptions = new HtmlOptions();

            // Use custom formatter with our controller to inject CSS
            htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomHtmlController());

            // Save as HTML
            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
            presentation.Dispose();
        }
    }
}