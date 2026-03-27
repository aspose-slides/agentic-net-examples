using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AddTipExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "TipPresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Tip Author", "TA");

            // Add a modern comment as a tip on the first slide
            Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(
                "Tip: Use the navigation pane to quickly jump between sections.",
                presentation.Slides[0],
                null,
                new System.Drawing.PointF(100, 100),
                System.DateTime.Now);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}