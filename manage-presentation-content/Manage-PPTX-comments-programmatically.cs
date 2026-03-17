using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add an empty slide
            presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define comment position
            System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

            // Add a comment to the first slide
            Aspose.Slides.IComment comment1 = author.Comments.AddComment("First comment", presentation.Slides[0], position, DateTime.Now);

            // Add a second author and a reply comment
            Aspose.Slides.ICommentAuthor author2 = presentation.CommentAuthors.AddAuthor("Jane Smith", "JS");
            Aspose.Slides.IComment reply = author2.Comments.AddComment("Reply to first comment", presentation.Slides[0], position, DateTime.Now);
            reply.ParentComment = comment1;

            // Retrieve and display all comments on the first slide
            Aspose.Slides.IComment[] comments = presentation.Slides[0].GetSlideComments(null);
            for (int i = 0; i < comments.Length; i++)
            {
                Aspose.Slides.IComment c = comments[i];
                Console.WriteLine("Author: " + c.Author.Name + " Text: " + c.Text);
            }

            // Modify the text of the first comment
            comment1.Text = "Updated first comment";

            // Delete the reply comment
            reply.Remove();

            // Save the presentation
            presentation.Save("CommentsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}