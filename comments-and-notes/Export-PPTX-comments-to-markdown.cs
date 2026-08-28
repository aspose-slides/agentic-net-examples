// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX comments to markdown using C#

//

// Description:

// Demonstrates how to extract comments from a PowerPoint (.pptx) file and

// export them to a markdown file using Aspose.Slides for .NET. The example

// loads a presentation, iterates through comment authors and their comments,

// writes each comment as a blockquote in markdown, and optionally saves the

// presentation back to the original file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Comments, Markdown,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of presentation comments for documentation.

// - Build tools that convert PPTX comment threads to markdown format.

// - Integrate comment export functionality into .NET applications.

// - Validate or review comments in PowerPoint files programmatically.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentExport

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "Comments1.pptx";

            string outputPath = "Comments.md";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            Presentation pres = null;

            try

            {

                pres = new Presentation(inputPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            try

            {

                using (StreamWriter writer = new StreamWriter(outputPath))

                {

                    foreach (ICommentAuthor author in pres.CommentAuthors)

                    {

                        foreach (IComment comment in author.Comments)

                        {

                            writer.WriteLine("> " + comment.Text);

                        }

                    }

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error writing markdown file: " + ex.Message);

            }



            // Save presentation before exit

            try

            {

                pres.Save(inputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error saving presentation: " + ex.Message);

            }



            pres.Dispose();

        }

    }

}

