using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportCommentsToSwf
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF export options with notes and comments layout
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
                    {
                        // Position comments on the right side of the slide
                        CommentsPosition = CommentsPositions.Right
                    };

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation exported successfully to: " + outputPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported comment
                Console.WriteLine("The presentation format is not supported for SWF export.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}