using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output HTML file path
            string outputPath = "output.html";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Create HTML export options (default options include notes)
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

            // Save the presentation as HTML with notes
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, htmlOptions);

            // Ensure the presentation is saved before exiting
            presentation.Dispose();
        }
    }
}