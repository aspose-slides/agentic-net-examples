// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove PPTX slide comments by a specific author using C#

//

// Description:

// Demonstrates how to delete all slide comments authored by a given user from a

// PowerPoint presentation using Aspose.Slides for .NET. The example loads a PPTX

// file, locates the comment author by name, removes each of their comments from

// every slide, optionally removes the author from the presentation, and saves the

// modified file. This pattern can be used in console utilities or integrated into

// larger .NET applications for automated presentation cleanup.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Slide, Comments, Author, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Clean up or redact comments from a specific user in PPTX files.

// - Build C# tools for managing PowerPoint comment metadata.

// - Automate preparation of presentations before distribution.

// - Integrate comment removal into document workflow pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DeleteCommentsByAuthor

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Author name whose comments should be deleted

            string targetAuthorName = "John Doe";



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Find the author object matching the target name

                CommentAuthor targetAuthor = null;

                foreach (object authorObj in presentation.CommentAuthors)

                {

                    CommentAuthor author = (CommentAuthor)authorObj;

                    if (author.Name == targetAuthorName)

                    {

                        targetAuthor = author;

                        break;

                    }

                }



                if (targetAuthor != null)

                {

                    // Iterate through all slides and remove comments by the target author

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                    {

                        ISlide slide = presentation.Slides[slideIndex];

                        IComment[] comments = slide.GetSlideComments(targetAuthor);

                        for (int commentIndex = 0; commentIndex < comments.Length; commentIndex++)

                        {

                            comments[commentIndex].Remove();

                        }

                    }



                    // Optionally remove the author from the collection

                    targetAuthor.Remove();

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);



                // Dispose the presentation object

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle format not supported or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // If the exception is due to an unsupported format, comment accordingly

                // Format not supported.

            }

        }

    }

}

