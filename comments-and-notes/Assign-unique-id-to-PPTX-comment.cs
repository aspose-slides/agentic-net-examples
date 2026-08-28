// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Assign unique id to PPTX comment using C#

//

// Description:

// Demonstrates how to assign unique id to PPTX comment using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Unique, Pptx, Comment, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate assign unique id to PPTX comment.

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

        // Create a new presentation

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



        // Add an empty slide

        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);



        // Add a comment author

        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("AuthorName", "AN");



        // Define comment position

        System.Drawing.PointF position = new System.Drawing.PointF(10f, 10f);



        // Counter for unique identifiers

        int commentId = 1;



        // Add first comment with unique ID

        Aspose.Slides.IComment comment1 = author.Comments.AddComment(

            $"ID:{commentId} - First comment", presentation.Slides[0], position, DateTime.Now);

        commentId++;



        // Add a reply to the first comment with unique ID

        Aspose.Slides.IComment reply1 = author.Comments.AddComment(

            $"ID:{commentId} - Reply to first comment", presentation.Slides[0], position, DateTime.Now);

        reply1.ParentComment = comment1;

        commentId++;



        // Add second top-level comment with unique ID

        Aspose.Slides.IComment comment2 = author.Comments.AddComment(

            $"ID:{commentId} - Second comment", presentation.Slides[0], position, DateTime.Now);

        commentId++;



        // Save the presentation with exception handling

        try

        {

            presentation.Save("CommentsWithIds.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception)

        {

            // Format not supported

        }



        // Dispose the presentation

        presentation.Dispose();

    }

}

