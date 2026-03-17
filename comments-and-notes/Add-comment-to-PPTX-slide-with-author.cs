using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Add a comment author
                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                // Define the position for the comment
                System.Drawing.PointF position = new System.Drawing.PointF();
                position.X = 0.2f;
                position.Y = 0.2f;

                // Add a comment to the first slide
                Aspose.Slides.IComment comment = author.Comments.AddComment(
                    "This is a new comment",
                    presentation.Slides[0],
                    position,
                    DateTime.Now);

                // Save the presentation with the new comment
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}