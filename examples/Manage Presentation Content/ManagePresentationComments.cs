using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (a new presentation contains one empty slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a comment author
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

        // Define the position for the comment
        System.Drawing.PointF position = new System.Drawing.PointF();
        position.X = 0.2f;
        position.Y = 0.2f;

        // Add a comment to the slide
        Aspose.Slides.IComment comment = author.Comments.AddComment("This is a comment on slide 1", slide, position, DateTime.Now);

        // Add a reply to the comment
        Aspose.Slides.ICommentAuthor replyAuthor = presentation.CommentAuthors.AddAuthor("Jane Smith", "JS");
        Aspose.Slides.IComment reply = replyAuthor.Comments.AddComment("Reply to the first comment", slide, position, DateTime.Now);
        reply.ParentComment = comment;

        // Retrieve and display all comments on the slide
        Aspose.Slides.IComment[] allComments = slide.GetSlideComments(null);
        foreach (Aspose.Slides.IComment c in allComments)
        {
            Console.WriteLine("Slide " + c.Slide.SlideNumber + " Comment: " + c.Text + " Author: " + c.Author.Name);
        }

        // Set a document-level comment property
        presentation.DocumentProperties.Comments = "Presentation level comment";

        // Save the presentation
        presentation.Save("ManagedComments.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}