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