using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "InputPresentation.pptx";
            string outputPath = "OutputPresentation.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through existing comment authors and their comments
            foreach (object commentAuthorObj in presentation.CommentAuthors)
            {
                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)commentAuthorObj;
                foreach (object commentObj in author.Comments)
                {
                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;
                    // Display original comment information
                    Console.WriteLine("Slide " + comment.Slide.SlideNumber + " - Author: " + author.Name + " - Text: " + comment.Text);
                    // Modify comment text
                    comment.Text = "Updated: " + comment.Text;
                    // Optionally change position
                    comment.Position = new PointF(comment.Position.X + 0.1f, comment.Position.Y + 0.1f);
                }
            }

            // Add a new empty slide to host new comments
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Add a new comment author
            Aspose.Slides.ICommentAuthor newAuthor = presentation.CommentAuthors.AddAuthor("New Author", "NA");

            // Define position for the new comment
            PointF newCommentPosition = new PointF(0.5f, 0.5f);

            // Add a new comment to the first slide
            newAuthor.Comments.AddComment("This is a newly added comment.", presentation.Slides[0], newCommentPosition, DateTime.Now);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}