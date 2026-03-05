using System;
using System.Drawing;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation. Comments allow reviewers to give feedback without changing slide content.
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a comment author who will be associated with the comments.
        Aspose.Slides.ICommentAuthor commentAuthor = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define the position where the comment will appear on the slide (relative coordinates).
        System.Drawing.PointF commentPosition = new System.Drawing.PointF();
        commentPosition.X = 0.5f;
        commentPosition.Y = 0.5f;

        // Add a comment to the first slide. This helps collaborators discuss specific parts of the slide.
        commentAuthor.Comments.AddComment(
            "Please verify the data in this chart.",
            presentation.Slides[0],
            commentPosition,
            DateTime.Now);

        // Set the presentation's built‑in Comments property to provide an overall remark.
        presentation.DocumentProperties.Comments = "Presentation includes reviewer comments for collaborative editing.";

        // Save the presentation in PPTX format before exiting.
        presentation.Save("CommentsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}