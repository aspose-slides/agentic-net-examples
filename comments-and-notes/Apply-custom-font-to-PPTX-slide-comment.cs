// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply custom font to PPTX slide comment using C#

//

// Description:

// Demonstrates how to apply a custom font (bold, italic, size, and color) to a

// slide comment in a PPTX file using C# and Aspose.Slides for .NET. The example

// creates a presentation, adds a modern comment, modifies the comment's text

// formatting, and saves the result. This pattern can be used to automate

// comment styling in PowerPoint presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Custom, Font, Comment,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate applying custom font styles to PPTX slide comments.

// - Build C# tools for PowerPoint comment formatting.

// - Generate or transform PPTX files with styled comments in .NET applications.

// - Validate comment appearance before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.Drawing;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        var pres = new Aspose.Slides.Presentation();



        // Ensure at least one slide exists

        var slide = pres.Slides[0];



        // Add comment author

        var author = pres.CommentAuthors.AddAuthor("John Doe", "JD");



        // Add modern comment

        var comment = author.Comments.AddModernComment("Custom styled comment", slide, null, new PointF(100, 100), DateTime.Now);



        // Get the shape associated with the comment

        var shape = comment.Shape as Aspose.Slides.IAutoShape;

        if (shape != null && shape.TextFrame != null)

        {

            var portion = shape.TextFrame.Paragraphs[0].Portions[0];

            // Apply custom font style

            portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;

            portion.PortionFormat.FontHeight = 24f;

            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;

            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

        }



        // Save presentation

        var outPath = "CommentStyled.pptx";

        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        pres.Dispose();

    }

}

