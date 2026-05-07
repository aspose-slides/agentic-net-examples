using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.swf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Create SWF options and disable hidden slide export
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ShowHiddenSlides = false;

                // Save presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Verify slide counts
                int totalSlides = presentation.Slides.Count;
                int hiddenSlides = presentation.DocumentProperties.HiddenSlides;
                int visibleSlides = totalSlides - hiddenSlides;

                // Since hidden slides are excluded, exported SWF should contain only visible slides
                Console.WriteLine("Total slides: " + totalSlides);
                Console.WriteLine("Hidden slides: " + hiddenSlides);
                Console.WriteLine("Visible slides (expected in SWF): " + visibleSlides);
                Console.WriteLine("SWF saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}