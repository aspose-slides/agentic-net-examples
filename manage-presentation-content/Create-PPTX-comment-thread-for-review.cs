using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideCommentsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a comment author
                    ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                    // Define comment position
                    PointF position = new PointF(0.2f, 0.2f);

                    // Add a comment to the slide
                    IComment comment = author.Comments.AddComment("This is a review comment.", slide, position, DateTime.Now);

                    // Retrieve and display all comments on the slide
                    IComment[] comments = slide.GetSlideComments(null);
                    foreach (IComment c in comments)
                    {
                        Console.WriteLine("Slide {0} Comment by {1}: {2}", c.Slide.SlideNumber, c.Author.Name, c.Text);
                    }

                    // Remove the comment
                    comment.Remove();

                    // Save the presentation
                    presentation.Save("SlideCommentsDemo.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}