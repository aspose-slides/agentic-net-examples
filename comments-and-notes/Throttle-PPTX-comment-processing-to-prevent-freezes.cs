// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Throttle PPTX comment processing to prevent freezes using C#

//

// Description:

// Demonstrates how to throttle PPTX comment processing to prevent freezes 

// using C# and Aspose.Slides for .NET. The example adds comment authors, 

// comments, and replies to a presentation, processes them with a delay to 

// avoid UI freezes, and saves the resulting file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Throttle, Pptx, Comment, 

// Processing, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate throttle PPTX comment processing to prevent freezes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Threading;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Load existing presentation if it exists, otherwise create a new one

        Aspose.Slides.Presentation presentation;

        if (File.Exists(inputPath))

        {

            try

            {

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // format not supported

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }

        }

        else

        {

            presentation = new Aspose.Slides.Presentation();

            // Add an empty slide to the new presentation

            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        }



        // Add comment authors and comments

        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "AU");

        System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

        Aspose.Slides.IComment comment1 = author.Comments.AddComment("First comment", presentation.Slides[0], position, DateTime.Now);

        Aspose.Slides.IComment comment2 = author.Comments.AddComment("Second comment", presentation.Slides[0], position, DateTime.Now);



        Aspose.Slides.ICommentAuthor responder = presentation.CommentAuthors.AddAuthor("Responder", "RS");

        Aspose.Slides.IComment reply = responder.Comments.AddComment("Reply to first", presentation.Slides[0], position, DateTime.Now);

        reply.ParentComment = comment1;



        // Throttle comment processing to avoid UI freezes

        Aspose.Slides.IComment[] allComments = presentation.Slides[0].GetSlideComments(null);

        for (int i = 0; i < allComments.Length; i++)

        {

            Aspose.Slides.IComment current = allComments[i];

            Console.WriteLine("Processing comment by " + current.Author.Name + ": " + current.Text);

            // Introduce a small delay between processing each comment

            Thread.Sleep(200);

        }



        // Save the presentation

        try

        {

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Failed to save presentation: " + ex.Message);

        }



        presentation.Dispose();

    }

}

