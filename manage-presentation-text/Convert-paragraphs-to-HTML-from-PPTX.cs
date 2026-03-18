using System;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source PPTX file
                string inputPath = "input.pptx";
                // Path for the generated HTML file
                string outputPath = "output.html";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                // Save the presentation as HTML preserving formatting
                presentation.Save(outputPath, SaveFormat.Html);
                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}