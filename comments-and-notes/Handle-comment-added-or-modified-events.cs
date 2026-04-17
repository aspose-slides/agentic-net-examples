using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace CommentEventDemo
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define event handlers for comment added and modified
            Action<Aspose.Slides.IComment> commentAdded = delegate (Aspose.Slides.IComment c)
            {
                Console.WriteLine("Comment added: " + c.Text);
            };

            Action<Aspose.Slides.IComment> commentModified = delegate (Aspose.Slides.IComment c)
            {
                Console.WriteLine("Comment modified: " + c.Text);
            };

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define comment position
            System.Drawing.PointF position = new System.Drawing.PointF(100f, 100f);

            // Add a comment to the first slide
            Aspose.Slides.IComment comment = author.Comments.AddComment(
                "Initial comment",
                presentation.Slides[0],
                position,
                System.DateTime.Now);

            // Trigger the added event
            commentAdded(comment);

            // Modify the comment text
            comment.Text = "Modified comment";

            // Trigger the modified event
            commentModified(comment);

            // Save the presentation before exiting
            presentation.Save("CommentEvents.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}