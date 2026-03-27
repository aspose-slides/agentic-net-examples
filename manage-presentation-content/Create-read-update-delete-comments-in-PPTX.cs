using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "Comments1.pptx";
        string outputPath = "CommentsResult.pptx";

        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
        }

        // Add a new author and a comment to the first slide
        Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");
        System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);
        Aspose.Slides.IComment comment = author.Comments.AddComment("Initial comment", presentation.Slides[0], position, DateTime.Now);

        // Add a reply comment (parent comment)
        Aspose.Slides.ICommentAuthor replyAuthor = presentation.CommentAuthors.AddAuthor("Jane Smith", "JS");
        Aspose.Slides.IComment reply = replyAuthor.Comments.AddComment("Reply to initial comment", presentation.Slides[0], position, DateTime.Now);
        reply.ParentComment = comment;

        // Access and display all comments
        foreach (object authorObj in presentation.CommentAuthors)
        {
            Aspose.Slides.CommentAuthor commentAuthor = (Aspose.Slides.CommentAuthor)authorObj;
            foreach (object commentObj in commentAuthor.Comments)
            {
                Aspose.Slides.Comment c = (Aspose.Slides.Comment)commentObj;
                Console.WriteLine("Slide " + c.Slide.SlideNumber + ": " + c.Text + " (Author: " + c.Author.Name + ")");
            }
        }

        // Update comment text
        comment.Text = "Updated comment text";

        // Delete the reply comment
        reply.Remove();

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose resources
        presentation.Dispose();
    }
}