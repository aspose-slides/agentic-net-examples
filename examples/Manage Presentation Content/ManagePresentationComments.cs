using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation instance
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first (empty) slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a comment author to the presentation
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define the position where the comment will appear on the slide
            PointF position = new PointF(0.2f, 0.2f);

            // Add a comment authored by the previously created author
            Aspose.Slides.IComment comment = author.Comments.AddComment(
                "This is a sample comment.",
                slide,
                position,
                DateTime.Now);

            // Iterate through all comment authors and display their comments
            foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
            {
                Aspose.Slides.IComment[] comments = commentAuthor.Comments.ToArray();
                foreach (Aspose.Slides.IComment c in comments)
                {
                    Console.WriteLine(
                        "Slide " + c.Slide.SlideNumber +
                        ": " + c.Text +
                        " (Author: " + c.Author.Name + ")");
                }
            }

            // Save the presentation to a PPTX file
            presentation.Save("CommentsDemo.pptx", SaveFormat.Pptx);
        }
    }
}