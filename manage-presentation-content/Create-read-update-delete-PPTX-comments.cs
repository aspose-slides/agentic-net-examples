using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define comment position
            PointF position = new PointF(0.2f, 0.2f);

            // Add a comment to the first slide
            Aspose.Slides.IComment comment = author.Comments.AddComment("Initial comment", presentation.Slides[0], position, DateTime.Now);

            // Save the presentation
            presentation.Save("CommentsDemo.pptx", SaveFormat.Pptx);

            // Load the saved presentation
            Aspose.Slides.Presentation loadedPres = new Aspose.Slides.Presentation("CommentsDemo.pptx");

            // Retrieve the first author and comment
            Aspose.Slides.ICommentAuthor loadedAuthor = loadedPres.CommentAuthors[0];
            Aspose.Slides.IComment loadedComment = loadedAuthor.Comments[0];

            // Update the comment text
            loadedComment.Text = "Updated comment text";

            // Delete the comment
            loadedComment.Remove();

            // Save the updated presentation
            loadedPres.Save("CommentsDemo_Updated.pptx", SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
            loadedPres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}