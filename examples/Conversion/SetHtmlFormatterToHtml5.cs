using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create HtmlOptions and set HtmlFormatter (using a simple document formatter)
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
            htmlOptions.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("", false);

            // Save the presentation as HTML5 using the HtmlOptions
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
    }
}