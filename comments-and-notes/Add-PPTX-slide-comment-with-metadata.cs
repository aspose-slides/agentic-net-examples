// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add PPTX slide comment with metadata using C#

//

// Description:

// Demonstrates how to add a modern comment with metadata (author, position,

// and timestamp) to a specific slide in a PPTX file using C# and Aspose.Slides

// for .NET. The example creates a presentation, ensures three slides exist,

// adds a custom comment author, places a comment on the third slide, and

// saves the result as a PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Modern Comment, Metadata,

// Slide Comment, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding modern comments with metadata to PowerPoint slides.

// - Build C# tools for annotating PPTX presentations.

// - Generate or modify PPTX files with author and timestamp information.

// - Validate comment handling in presentation workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



        // Ensure there are at least three slides

        Aspose.Slides.ISlide slide1 = presentation.Slides[0];

        Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);



        // Add a custom author

        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Custom Author", "CA");



        // Define position for the comment

        System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);



        // Add modern comment to the third slide (index 2)

        Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(

            "This is a modern comment on the third slide",

            slide3,

            null,

            position,

            System.DateTime.Now);



        // Save the presentation

        string outputPath = "AddModernCommentThirdSlide.pptx";

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



        // Dispose presentation

        presentation.Dispose();

    }

}

