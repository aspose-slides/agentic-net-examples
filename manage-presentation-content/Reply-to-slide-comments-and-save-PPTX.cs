using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Ensure there is at least one comment author and comment
            if (presentation.CommentAuthors.Count == 0)
            {
                Console.WriteLine("No comment authors found.");
                return;
            }

            Aspose.Slides.ICommentAuthor originalAuthor = presentation.CommentAuthors[0];
            if (originalAuthor.Comments.Count == 0)
            {
                Console.WriteLine("No comments to reply to.");
                return;
            }

            Aspose.Slides.IComment originalComment = originalAuthor.Comments[0];

            // Add a new author for the reply
            Aspose.Slides.ICommentAuthor replyAuthor = presentation.CommentAuthors.AddAuthor("ReplyAuthor", "RA");

            // Position for the reply comment
            System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

            // Add reply comment
            Aspose.Slides.IComment replyComment = replyAuthor.Comments.AddComment("This is a reply", slide, position, DateTime.Now);
            replyComment.ParentComment = originalComment;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}