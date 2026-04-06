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