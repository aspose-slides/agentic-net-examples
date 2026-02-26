using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";
            // Path for the generated HTML file
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create HTML export options (default does not embed fonts)
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Save the presentation as HTML
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Release resources
            presentation.Dispose();
        }
    }
}