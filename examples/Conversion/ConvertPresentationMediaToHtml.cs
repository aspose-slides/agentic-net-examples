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
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create HTML export options (default options)
                HtmlOptions htmlOptions = new HtmlOptions();

                // Save the presentation as HTML
                presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
            }

            // Indicate completion
            Console.WriteLine("Presentation has been converted to HTML successfully.");
        }
    }
}