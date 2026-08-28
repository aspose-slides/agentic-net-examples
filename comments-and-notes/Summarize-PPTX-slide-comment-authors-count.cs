// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Summarize PPTX slide comment authors count using C#

//

// Description:

// Demonstrates how to load a PPTX file, enumerate its comment authors, 

// display each author's name together with the number of comments they have 

// made, and finally save the presentation. The example uses Aspose.Slides for 

// .NET and can serve as a basis for automating comment analysis in PowerPoint 

// files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Comment Authors, Summarize, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Generate reports of comment activity per author in a presentation.

// - Build tools that validate or audit comments before publishing.

// - Integrate comment summarization into larger .NET PowerPoint workflows.

// - Automate saving of presentations after analysis.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentSummaryApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            Aspose.Slides.Presentation presentation = null;

            try

            {

                // Load the presentation

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other loading errors

                Console.WriteLine("Failed to load presentation. Possible unsupported format.");

                Console.WriteLine("Error: " + ex.Message);

                return;

            }



            // Iterate through comment authors and display comment counts

            foreach (object authorObj in presentation.CommentAuthors)

            {

                Aspose.Slides.ICommentAuthor author = (Aspose.Slides.ICommentAuthor)authorObj;

                int commentCount = author.Comments.Count;

                Console.WriteLine("Author: " + author.Name + " | Comments: " + commentCount);

            }



            try

            {

                // Save the presentation before exiting

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle save errors (e.g., unsupported format)

                Console.WriteLine("Failed to save presentation. Possible unsupported format.");

                Console.WriteLine("Error: " + ex.Message);

            }

            finally

            {

                // Release resources

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}

