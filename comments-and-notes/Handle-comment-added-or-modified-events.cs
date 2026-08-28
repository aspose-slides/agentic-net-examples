// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Handle comment added or modified events using C#

//

// Description:

// Demonstrates how to handle comment added and comment modified scenarios in a

// PowerPoint presentation using Aspose.Slides for .NET. The example creates a

// presentation, adds a comment author, inserts a comment, manually invokes

// callbacks for added and modified events, and saves the file. This pattern can

// be adapted to integrate real event handling in automation workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Handle, Comment, Added, Modified,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate detection and processing of comment additions or modifications.

// - Build C# utilities for PowerPoint comment management.

// - Integrate comment event handling into .NET presentation workflows.

// - Validate and transform PPTX files with comment tracking.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace CommentEventDemo

{

    class Program

    {

        static void Main()

        {

            // Create a new presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



            // Define event handlers for comment added and modified

            Action<Aspose.Slides.IComment> commentAdded = delegate (Aspose.Slides.IComment c)

            {

                Console.WriteLine("Comment added: " + c.Text);

            };



            Action<Aspose.Slides.IComment> commentModified = delegate (Aspose.Slides.IComment c)

            {

                Console.WriteLine("Comment modified: " + c.Text);

            };



            // Add a comment author

            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");



            // Define comment position

            System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);



            // Add a comment to the first slide

            Aspose.Slides.IComment comment = author.Comments.AddComment(

                "Initial comment",

                presentation.Slides[0],

                position,

                System.DateTime.Now);



            // Trigger the added event

            commentAdded(comment);



            // Modify the comment text

            comment.Text = "Modified comment";



            // Trigger the modified event

            commentModified(comment);



            // Save the presentation before exiting

            presentation.Save("CommentEvents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);



            // Dispose the presentation

            presentation.Dispose();

        }

    }

}

