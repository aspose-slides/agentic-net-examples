// -----------------------------------------------------------------------------
// Example: Load presentation from stream verify slide count using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation from a file stream, 
// verify the number of slides, and save the presentation using Aspose.Slides 
// for .NET. The example includes error handling for missing files, unsupported 
// formats, and I/O exceptions, and shows proper resource cleanup.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Stream, 
// Verify, Slide Count, Presentation Processing, Office Automation
//
// Use Cases:
// - Load a presentation from a stream and validate its slide count.
// - Build .NET utilities that process PowerPoint files without loading them 
//   entirely into memory.
// - Automate validation of presentation content before further processing.
// - Ensure proper resource management when handling file streams in 
//   presentation workflows.
// -----------------------------------------------------------------------------
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
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            FileStream fileStream = null;
            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Open the presentation file as a stream
                fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Load the presentation from the stream
                presentation = new Aspose.Slides.Presentation(fileStream);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred while loading the presentation: " + ex.Message);
                return;
            }
            finally
            {
                // Close the file stream if it was opened
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            // Verify slide count
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Slide count: " + slideCount);

            try
            {
                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
