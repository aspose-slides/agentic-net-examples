using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();
                var slide = presentation.Slides[0];

                // Add first author and a comment
                var author1 = presentation.CommentAuthors.AddAuthor("Author1", "A1");
                var point = new PointF(100, 100);
                var comment1 = author1.Comments.AddComment("Original comment", slide, point, DateTime.Now);

                // Edit the comment text
                comment1.Text = "Edited comment";

                // Add second author and a reply to the first comment
                var author2 = presentation.CommentAuthors.AddAuthor("Author2", "A2");
                var reply = author2.Comments.AddComment("Reply to comment", slide, point, DateTime.Now);
                reply.ParentComment = comment1;

                // Retrieve and display comment hierarchy
                var comments = slide.GetSlideComments(null);
                foreach (var c in comments)
                {
                    var indent = "";
                    var current = c;
                    while (current.ParentComment != null)
                    {
                        indent += "\t";
                        current = current.ParentComment;
                    }
                    Console.WriteLine($"{indent}{c.Author.Name}: {c.Text}");
                }

                // Save the presentation
                presentation.Save("CommentsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}