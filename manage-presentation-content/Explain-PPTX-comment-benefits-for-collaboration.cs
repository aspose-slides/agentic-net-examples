using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation. Adding comments helps team members discuss specific slides.
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a comment author. Authors identify who made each remark.
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("Alice", "A.A.");

            // Define where the comment will appear on the slide.
            PointF position = new PointF(0.2f, 0.2f);

            // Add a comment to the first slide to request review and track revisions.
            Aspose.Slides.IComment comment = author.Comments.AddComment(
                "Initial draft: please review the content and suggest changes.",
                presentation.Slides[0],
                position,
                DateTime.Now);

            // Set a document‑level comment describing the purpose of the slide comments.
            presentation.DocumentProperties.Comments = "Comments added to support collaboration and revision tracking.";

            // Save the presentation before exiting.
            presentation.Save("CollaborationComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}