using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToSwf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure SWF export options
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    // Example: exclude the integrated viewer
                    swfOptions.ViewerIncluded = false;

                    // Save the presentation as SWF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation successfully converted to SWF.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}