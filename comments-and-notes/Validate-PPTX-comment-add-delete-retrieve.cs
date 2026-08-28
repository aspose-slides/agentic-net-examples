// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate PPTX comment add, retrieve, and delete using C#

//

// Description:

// Demonstrates how to add a comment author, insert a comment, retrieve it for

// verification, delete the comment, and verify its removal using Aspose.Slides

// for .NET. The example creates a presentation, performs comment operations on

// the first slide, and saves the presentation after each step. This pattern

// helps developers automate PPTX comment validation workflows in .NET.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Comment Add, Comment Retrieve,

// Comment Delete, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate testing of comment addition, retrieval, and deletion in PPTX files.

// - Build C# utilities for managing comments in PowerPoint presentations.

// - Validate presentation content before publishing or integration.

// - Demonstrate Aspose.Slides comment API usage in console applications.

// -----------------------------------------------------------------------------

using System;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentTests

{

    class Program

    {

        static void Main(string[] args)

        {

            try

            {

                RunCommentAddDeleteRetrieveTests();

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }



        private static void RunCommentAddDeleteRetrieveTests()

        {

            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                // Ensure there is at least one slide

                ISlide slide = presentation.Slides[0];



                // Add a comment author

                ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Test Author", "TA");



                // Define comment position

                PointF position = new PointF(0.2f, 0.2f);



                // Add a comment to the first slide

                IComment addedComment = author.Comments.AddComment("This is a test comment", slide, position, DateTime.Now);



                // Save after addition

                presentation.Save("CommentAdded.pptx", SaveFormat.Pptx);



                // Retrieve comments from the slide

                IComment[] comments = slide.GetSlideComments(null);

                if (comments.Length != 1)

                {

                    throw new Exception("Comment addition verification failed.");

                }

                if (comments[0].Text != "This is a test comment")

                {

                    throw new Exception("Comment text does not match expected value.");

                }



                // Delete the comment

                comments[0].Remove();



                // Verify deletion

                IComment[] commentsAfterDeletion = slide.GetSlideComments(null);

                if (commentsAfterDeletion.Length != 0)

                {

                    throw new Exception("Comment deletion verification failed.");

                }



                // Save after deletion

                presentation.Save("CommentDeleted.pptx", SaveFormat.Pptx);

            }

        }

    }

}

