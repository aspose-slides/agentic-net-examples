// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log detailed exception for PPTX comment failure using C#

//

// Description:

// Demonstrates how to add a comment author and comment to a PPTX presentation,

// iterate through slide comments, and log detailed exception information when

// comment processing fails. The example uses Aspose.Slides for .NET and shows

// saving the presentation and handling Aspose.Slides.PptxEditException.

//

// Keywords:

// C#, Aspose.Slides, PPTX, Comment, Exception handling, PptxEditException,

// Presentation processing, PowerPoint automation, .NET

//

// Use Cases:

// - Capture and log detailed errors during PPTX comment processing.

// - Build utilities that add and read comments in PowerPoint files.

// - Ensure robust exception handling in presentation automation scripts.

// - Save and dispose presentations after processing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentProcessingExample

{

    class Program

    {

        static void Main(string[] args)

        {

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CommentsOutput.pptx");

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



            // Add a slide and a comment author

            Aspose.Slides.ISlide slide = presentation.Slides[0];

            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

            author.Comments.AddComment("Sample comment", slide, position, DateTime.Now);



            try

            {

                ProcessComments(presentation);

            }

            catch (Aspose.Slides.PptxEditException ex)

            {

                Console.WriteLine("Custom exception caught:");

                Console.WriteLine("Message: " + ex.Message);

                Console.WriteLine("Inner Exception: " + (ex.InnerException != null ? ex.InnerException.ToString() : "None"));

            }

            finally

            {

                // Save the presentation before exiting

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();

            }

        }



        static void ProcessComments(Aspose.Slides.Presentation pres)

        {

            try

            {

                foreach (Aspose.Slides.ISlide sld in pres.Slides)

                {

                    Aspose.Slides.IComment[] comments = sld.GetSlideComments(null);

                    for (int i = 0; i < comments.Length; i++)

                    {

                        Aspose.Slides.IComment comment = comments[i];

                        Console.WriteLine("Slide " + sld.SlideNumber + " Comment: " + comment.Text);

                    }

                }

            }

            catch (Exception e)

            {

                // Wrap any exception in a custom Aspose.Slides exception with detailed info

                throw new Aspose.Slides.PptxEditException("Failed to process slide comments.", e);

            }

        }

    }

}

