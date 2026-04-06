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