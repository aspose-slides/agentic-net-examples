using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a comment author
            Aspose.Slides.ICommentAuthor commentAuthor = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define comment position on the slide
            PointF commentPosition = new PointF();
            commentPosition.X = 0.2f;
            commentPosition.Y = 0.2f;

            // Add a comment to the first slide
            Aspose.Slides.IComment slideComment = commentAuthor.Comments.AddComment(
                "This is a comment on the first slide",
                presentation.Slides[0],
                commentPosition,
                DateTime.Now);

            // Set a presentation-level comment using document properties
            presentation.DocumentProperties.Comments = "Overall presentation comment.";

            // Save the presentation in PPT format
            presentation.Save("PresentationWithComments.ppt", SaveFormat.Ppt);
        }
    }
}