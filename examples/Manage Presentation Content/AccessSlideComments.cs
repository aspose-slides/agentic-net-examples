using System;
using System.Drawing;
using Aspose.Slides;

namespace SlideCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing PPT presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.ppt");

            // Iterate through all comment authors
            foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
            {
                // Iterate through each comment of the current author
                foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)
                {
                    Aspose.Slides.ISlide slide = comment.Slide;
                    Console.WriteLine("Slide " + slide.SlideNumber + ": \"" + comment.Text + "\" by " + comment.Author.Name + " at " + comment.CreatedTime);
                }
            }

            // Add a new comment author
            Aspose.Slides.ICommentAuthor newAuthor = presentation.CommentAuthors.AddAuthor("New Author", "NA");

            // Define position for the new comment
            System.Drawing.PointF position = new System.Drawing.PointF();
            position.X = 0.5f;
            position.Y = 0.5f;

            // Add a comment to the first slide
            Aspose.Slides.IComment newComment = newAuthor.Comments.AddComment("This is a new comment.", presentation.Slides[0], position, DateTime.Now);

            // Optionally modify comment properties
            newComment.Text = "Updated comment text.";
            newComment.CreatedTime = DateTime.Now;

            // Save the presentation in PPT format
            presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}