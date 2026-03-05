using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create HTML export options
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Create a formatting controller that embeds all fonts
            Aspose.Slides.Export.EmbedAllFontsHtmlController embedController = new Aspose.Slides.Export.EmbedAllFontsHtmlController();

            // Assign a custom HTML formatter that uses the embed controller
            htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController);

            // Save the presentation as HTML with embedded fonts
            presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}