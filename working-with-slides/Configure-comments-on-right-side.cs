using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesCommentsLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a try-catch to handle unsupported formats
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Configure SlidesLayoutOptions to place comments on the right side
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            layoutOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;
            swfOptions.SlidesLayoutOptions = layoutOptions;

            // Save the presentation with the configured options
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}