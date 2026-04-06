using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentProcessingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CommentsOutput.pptx");
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a slide and a comment author
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");
            System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);
            author.Comments.AddComment("Sample comment", slide, position, DateTime.Now);

            try
            {
                ProcessComments(presentation);
            }
            catch (Aspose.Slides.PptxEditException ex)
            {
                Console.WriteLine("Custom exception caught:");
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Inner Exception: " + (ex.InnerException != null ? ex.InnerException.ToString() : "None"));
            }
            finally
            {
                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
        }

        static void ProcessComments(Aspose.Slides.Presentation pres)
        {
            try
            {
                foreach (Aspose.Slides.ISlide sld in pres.Slides)
                {
                    Aspose.Slides.IComment[] comments = sld.GetSlideComments(null);
                    for (int i = 0; i < comments.Length; i++)
                    {
                        Aspose.Slides.IComment comment = comments[i];
                        Console.WriteLine("Slide " + sld.SlideNumber + " Comment: " + comment.Text);
                    }
                }
            }
            catch (Exception e)
            {
                // Wrap any exception in a custom Aspose.Slides exception with detailed info
                throw new Aspose.Slides.PptxEditException("Failed to process slide comments.", e);
            }
        }
    }
}