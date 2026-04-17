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

        // Add an empty slide
        presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("AuthorName", "AN");

        // Define comment position
        System.Drawing.PointF position = new System.Drawing.PointF(10f, 10f);

        // Counter for unique identifiers
        int commentId = 1;

        // Add first comment with unique ID
        Aspose.Slides.IComment comment1 = author.Comments.AddComment(
            $"ID:{commentId} - First comment", presentation.Slides[0], position, DateTime.Now);
        commentId++;

        // Add a reply to the first comment with unique ID
        Aspose.Slides.IComment reply1 = author.Comments.AddComment(
            $"ID:{commentId} - Reply to first comment", presentation.Slides[0], position, DateTime.Now);
        reply1.ParentComment = comment1;
        commentId++;

        // Add second top-level comment with unique ID
        Aspose.Slides.IComment comment2 = author.Comments.AddComment(
            $"ID:{commentId} - Second comment", presentation.Slides[0], position, DateTime.Now);
        commentId++;

        // Save the presentation with exception handling
        try
        {
            presentation.Save("CommentsWithIds.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}