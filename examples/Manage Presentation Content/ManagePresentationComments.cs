using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationComments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add an empty slide (the default presentation already contains one, this ensures a second slide if needed)
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define the position for the comment on the slide
            System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);

            // Add a modern comment to the first slide
            Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(
                "This is a modern comment.",
                presentation.Slides[0],
                null,
                position,
                System.DateTime.Now);

            // Save the presentation in PPT format
            presentation.Save("ManagedComments.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}