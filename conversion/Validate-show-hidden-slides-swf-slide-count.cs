using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
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
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Record total slide count before export
                int totalSlidesBefore = pres.Slides.Count;

                // Hide the first slide (if at least one slide exists)
                if (pres.Slides.Count > 0)
                {
                    pres.Slides[0].Hidden = true;
                }

                // Get hidden slide count from document properties
                int hiddenSlides = pres.DocumentProperties.HiddenSlides;
                Console.WriteLine("Hidden slides count: " + hiddenSlides);

                // Configure SWF export options to include hidden slides
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ShowHiddenSlides = true;

                // Save the presentation as SWF with the specified options
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Verify that total slide count remains unchanged after export
                int totalSlidesAfter = pres.Slides.Count;
                Console.WriteLine("Total slides before export: " + totalSlidesBefore);
                Console.WriteLine("Total slides after export: " + totalSlidesAfter);
                Console.WriteLine("Slide count unchanged: " + (totalSlidesBefore == totalSlidesAfter));

                // Save the presentation before exit (as per requirement)
                string finalPath = Path.Combine(Environment.CurrentDirectory, "final_output.pptx");
                pres.Save(finalPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}