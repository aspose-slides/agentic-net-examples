using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSwfComments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string inputPath = "input.pptx";
            // Path where the SWF file will be saved
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
                    // Configure SWF export options to include comments on the right side
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
                    {
                        CommentsPosition = CommentsPositions.Right
                    };

                    // Save the presentation as SWF with the specified options
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                // Simple validation: ensure the SWF file was created and is not empty
                if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
                {
                    Console.WriteLine("SWF file saved successfully with embedded comments.");
                }
                else
                {
                    Console.WriteLine("SWF file was not created correctly.");
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}