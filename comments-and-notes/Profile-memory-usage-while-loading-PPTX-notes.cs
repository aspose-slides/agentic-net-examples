using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationMemoryProfiler
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Record memory usage before loading
                long memoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Record memory usage after loading
                long memoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;
                Console.WriteLine("Memory used to load presentation: {0} bytes", memoryAfter - memoryBefore);

                // Access comments to ensure they are loaded (optional profiling)
                foreach (ICommentAuthor author in presentation.CommentAuthors)
                {
                    int commentCount = 0;
                    foreach (IComment comment in author.Comments)
                    {
                        commentCount++;
                    }
                    // Output comment count per author (can be removed in production)
                    Console.WriteLine("Author '{0}' has {1} comments.", author.Name, commentCount);
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., loading errors)
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
            }
        }
    }
}