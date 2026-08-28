// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create PPTX template with standard comments using C#

//

// Description:

// Demonstrates how to create a PowerPoint presentation template that includes

// standard modern comments using Aspose.Slides for .NET. The example creates a

// new presentation, clones the first slide, adds a comment author, inserts

// modern comments on each slide at a specified position, and saves the file as

// a PPTX document. This pattern can be used to generate templates with

// predefined comments for review or collaboration workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Modern Comments, Comment Author,

// Presentation Template, Slide Cloning, Office Automation

//

// Use Cases:

// - Generate PPTX templates pre-populated with standard comments for reviewers.

// - Automate insertion of modern comments into presentations via .NET.

// - Build tools that prepare PowerPoint files with author metadata and notes.

// - Streamline collaborative presentation workflows in enterprise environments.

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



        // Add an additional slide (clone of the first) to demonstrate multiple slides

        presentation.Slides.AddClone(presentation.Slides[0]);



        // Add a comment author

        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Standard Author", "SA");



        // Define comment position on the slide

        System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);



        // Add a modern comment to the first slide

        Aspose.Slides.IModernComment comment1 = author.Comments.AddModernComment(

            "Standard comment for slide 1",

            presentation.Slides[0],

            null,

            position,

            DateTime.Now);



        // Add a modern comment to the second slide

        Aspose.Slides.IModernComment comment2 = author.Comments.AddModernComment(

            "Standard comment for slide 2",

            presentation.Slides[1],

            null,

            position,

            DateTime.Now);



        // Save the presentation

        presentation.Save("TemplateWithComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);



        // Dispose the presentation object

        presentation.Dispose();

    }

}

