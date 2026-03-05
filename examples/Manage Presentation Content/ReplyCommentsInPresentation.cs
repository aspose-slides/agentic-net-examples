using System;
using System.Drawing;

namespace ReplyCommentsInPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add first comment author
            Aspose.Slides.ICommentAuthor author1 = presentation.CommentAuthors.AddAuthor("Author One", "A1");

            // Add a comment on the first slide
            Aspose.Slides.IComment comment1 = author1.Comments.AddComment(
                "This is the original comment.",
                presentation.Slides[0],
                new PointF(100f, 100f),
                DateTime.Now);

            // Add second comment author (the replier)
            Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Author Two", "A2");

            // Add a reply comment on the same slide
            Aspose.Slides.IComment reply1 = author2.Comments.AddComment(
                "This is a reply to the original comment.",
                presentation.Slides[0],
                new PointF(120f, 120f),
                DateTime.Now);

            // Set the parent comment to create a reply hierarchy
            reply1.ParentComment = comment1;

            // Add another reply from the first author
            Aspose.Slides.IComment reply2 = author1.Comments.AddComment(
                "Another reply from the original author.",
                presentation.Slides[0],
                new PointF(140f, 140f),
                DateTime.Now);
            reply2.ParentComment = comment1;

            // Save the presentation in PPTX format
            presentation.Save("ReplyComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}