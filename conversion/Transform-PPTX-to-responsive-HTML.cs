using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToResponsiveHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input PowerPoint file path
                string inputPath = "input.pptx";
                // Output HTML file path
                string outputPath = "output.html";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure HTML options for responsive layout
                    HtmlOptions options = new HtmlOptions();
                    options.SvgResponsiveLayout = true;

                    // Save the presentation as responsive HTML
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
                }

                Console.WriteLine("Presentation converted to responsive HTML successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}