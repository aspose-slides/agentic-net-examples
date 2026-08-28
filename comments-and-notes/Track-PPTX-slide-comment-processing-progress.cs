// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Track PPTX slide comment processing progress using C#

//

// Description:

// Demonstrates how to track the processing progress of slide comments in a PPTX

// file using C# and Aspose.Slides for .NET. The example loads a presentation,

// counts all comments, iterates through them while reporting progress, and

// saves the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Track, Pptx, Slide, Comment,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Monitor comment processing progress in automated PowerPoint workflows.

// - Build tools that need to report status while handling slide comments.

// - Integrate comment analysis or transformation into .NET applications.

// - Validate and log comment handling before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentProgressDemo

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

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // First pass: count total comments for progress calculation

                    int totalComments = 0;

                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)

                    {

                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                        totalComments += comments.Length;

                    }



                    if (totalComments == 0)

                    {

                        Console.WriteLine("No comments found in the presentation.");

                    }

                    else

                    {

                        // Second pass: iterate comments and report progress

                        int processedComments = 0;

                        foreach (Aspose.Slides.ISlide slide in presentation.Slides)

                        {

                            Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                            foreach (Aspose.Slides.IComment comment in comments)

                            {

                                // Example processing: output comment details

                                Console.WriteLine($"Slide {slide.SlideNumber} - Author: {comment.Author.Name} - Text: {comment.Text}");



                                // Update progress

                                processedComments++;

                                double progress = (double)processedComments / totalComments * 100;

                                Console.WriteLine($"Processing progress: {progress:F2}%");

                            }

                        }

                    }



                    // Save the presentation before exiting

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    Console.WriteLine("Presentation saved to: " + outputPath);

                }

            }

            // Handle unsupported file format exceptions

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported (PPTX)

                Console.WriteLine("The presentation format is not supported (PPTX).");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported (PPT)

                Console.WriteLine("The presentation format is not supported (PPT).");

            }

            // General exception handling

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

