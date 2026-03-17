using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a comment author for the team
                ICommentAuthor author = presentation.CommentAuthors.AddAuthor("DevTeam", "DT");

                // Define the position where the comment will appear on the slide
                PointF commentPosition = new PointF(0.2f, 0.2f);

                // Add a comment to the first slide
                IComment comment = author.Comments.AddComment(
                    "Please review this slide for accuracy.",
                    presentation.Slides[0],
                    commentPosition,
                    DateTime.Now);

                // Save the presentation with comments
                presentation.Save("PresentationWithComments.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}