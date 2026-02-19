using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputFile = "input.pptx";
        // Path for the generated HTML file
        string outputFile = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // List of fonts to exclude from embedding (empty in this example)
        string[] excludeList = new string[] { };

        // Controller that embeds all fonts in the HTML output
        Aspose.Slides.Export.EmbedAllFontsHtmlController embedController = new Aspose.Slides.Export.EmbedAllFontsHtmlController(excludeList);

        // Set up HTML export options with a custom formatter using the embed controller
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions
        {
            HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateCustomFormatter(embedController)
        };

        // Save the presentation as HTML while preserving original fonts
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

        // Release resources
        presentation.Dispose();
    }
}