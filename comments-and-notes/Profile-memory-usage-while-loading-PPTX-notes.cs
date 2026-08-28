// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Profile memory usage while loading PPTX presentation using C#

//

// Description:

// Demonstrates how to profile memory usage when loading a PPTX file with

// Aspose.Slides for .NET. The example measures the process private memory

// before and after creating a Presentation object, optionally iterates over

// comment authors to ensure comments are loaded, and saves the presentation.

// This pattern helps developers assess memory impact of loading PowerPoint

// files in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Memory Profiling, Presentation Loading, Comments, Office Automation

//

// Use Cases:

// - Measure memory consumption of loading PPTX files in .NET.

// - Validate memory usage for large presentations.

// - Build tools that need to monitor resource usage during PowerPoint processing.

// - Ensure comment data is loaded correctly when profiling.

// -----------------------------------------------------------------------------

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

