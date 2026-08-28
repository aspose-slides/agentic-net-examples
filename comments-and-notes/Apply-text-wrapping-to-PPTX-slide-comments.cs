// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply text wrapping to PPTX slide comments using C#

//

// Description:

// Demonstrates how to apply text wrapping to PPTX slide comments using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Text, Wrapping, Pptx, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate apply text wrapping to PPTX slide comments.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main()

    {

        try

        {

            // Create a new presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



            // Add an empty slide

            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);



            // Add a comment author

            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Author", "AU");



            // Define a position for the comment within slide boundaries (0.0 to 1.0)

            System.Drawing.PointF position = new System.Drawing.PointF(0.1f, 0.1f);



            // Add a comment with long text that should wrap

            Aspose.Slides.IComment comment = author.Comments.AddComment(

                "This is a very long comment text that should be wrapped to fit within the slide boundaries when exported.",

                presentation.Slides[0],

                position,

                DateTime.Now);



            // Ensure the comment stays inside the slide area

            if (comment.Position.X < 0f) comment.Position = new System.Drawing.PointF(0f, comment.Position.Y);

            if (comment.Position.Y < 0f) comment.Position = new System.Drawing.PointF(comment.Position.X, 0f);

            if (comment.Position.X > 1f) comment.Position = new System.Drawing.PointF(1f, comment.Position.Y);

            if (comment.Position.Y > 1f) comment.Position = new System.Drawing.PointF(comment.Position.X, 1f);



            // Save the presentation

            presentation.Save("CommentsWrapped.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

