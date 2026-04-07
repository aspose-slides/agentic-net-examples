using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Html5Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Set HTML5 export options
                Aspose.Slides.Export.Html5Options htmlOptions = new Aspose.Slides.Export.Html5Options();
                htmlOptions.AnimateShapes = true;          // Enable shape animations
                htmlOptions.AnimateTransitions = true;    // Enable slide transition animations
                htmlOptions.SkipJavaScriptLinks = false;  // Ensure JavaScript for navigation is included

                // Save the presentation as HTML5
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Conversion to HTML5 completed successfully.");
            }
            catch (Exception ex)
            {
                // If the exception is due to an unsupported format, handle it accordingly
                Console.WriteLine("Error: " + ex.Message);
                // Format not supported
            }
        }
    }
}