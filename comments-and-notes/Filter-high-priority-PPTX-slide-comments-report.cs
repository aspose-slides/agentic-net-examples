// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Filter high priority PPTX slide comments report using C#

//

// Description:

// Demonstrates how to filter high‑priority PPTX slide comments and generate a

// console report using C# and Aspose.Slides for .NET. The example loads a

// presentation, scans comment authors for comments containing a high‑priority

// marker, outputs the matching comments, and saves the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Filter, High, Priority, Comments,

// Report, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate a report of high‑priority comments in a PowerPoint file.

// - Automate comment analysis for review or quality‑control processes.

// - Build C# tools that process PPTX files and extract specific annotation data.

// - Integrate comment filtering into .NET applications that manage presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentFilterApp

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

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Iterate through all comment authors

                foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)

                {

                    // Iterate through each comment of the current author

                    foreach (Aspose.Slides.IComment comment in author.Comments)

                    {

                        // Filter high‑priority comments (example: text contains "[High]")

                        if (comment.Text != null && comment.Text.Contains("[High]"))

                        {

                            // Generate report entry

                            Console.WriteLine("Slide {0}: {1} (Author: {2})",

                                comment.Slide.SlideNumber,

                                comment.Text,

                                author.Name);

                        }

                    }

                }



                // Save the presentation before exiting

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

