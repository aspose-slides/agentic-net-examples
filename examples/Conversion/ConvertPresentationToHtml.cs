using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PowerPoint file
            string inputPath = "input.pptx";

            // Path to the output HTML file
            string outputPath = "output.html";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Create HtmlOptions to preserve slide dimensions (default behavior)
                Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

                // Save the presentation as HTML
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
            }
        }
    }
}