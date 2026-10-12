// -----------------------------------------------------------------------------
// Example: Throttled PPTX Comment Processing to Prevent UI Freezes
//
// Description:
// This console application creates or loads a PPTX file, adds comment authors,
// comments and reply (parent) comments using Aspose.Slides for .NET, processes
// each comment with a short delay to simulate throttling, and saves the updated
// presentation. It demonstrates how to avoid UI freezes when handling many
// comments in a PowerPoint file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, comment processing, throttling, UI freeze prevention
//
// Use Cases:
// - Adding and managing slide comments in bulk without blocking the UI.
// - Demonstrating parent‑child comment relationships in a PPTX.
// - Providing a template for safe comment handling in large presentations.
// Tested and Verified with Aspose.Slides for .NET v26.10.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using System.Threading;

namespace AsposeSlidesCommentThrottle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            Aspose.Slides.Presentation presentation = null;

            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide blankSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading or creating presentation: " + ex.Message);
                return;
            }

            try
            {
                // Add a comment author
                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                // Ensure there is at least one slide
                if (presentation.Slides.Count == 0)
                {
                    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                }

                Aspose.Slides.ISlide slide0 = presentation.Slides[0];
                PointF position = new PointF(100f, 100f);

                // Add a primary comment
                Aspose.Slides.IComment primaryComment = author.Comments.AddComment("This is the first comment.", slide0, position, DateTime.Now);

                // Add a reply comment (parent comment)
                Aspose.Slides.IComment replyComment = author.Comments.AddComment("This is a reply to the first comment.", slide0, position, DateTime.Now);
                replyComment.ParentComment = primaryComment;

                // Add a second author and comment
                Aspose.Slides.ICommentAuthor secondAuthor = presentation.CommentAuthors.AddAuthor("Jane Smith", "JS");
                Aspose.Slides.IComment secondComment = secondAuthor.Comments.AddComment("Another comment from a different author.", slide0, position, DateTime.Now);

                // Process comments with throttling to avoid UI freezes
                foreach (object authorObj in presentation.CommentAuthors)
                {
                    Aspose.Slides.ICommentAuthor commentAuthor = (Aspose.Slides.ICommentAuthor)authorObj;
                    foreach (object commentObj in commentAuthor.Comments)
                    {
                        Aspose.Slides.IComment comment = (Aspose.Slides.IComment)commentObj;
                        Console.WriteLine("Processing comment by " + commentAuthor.Name + ": " + comment.Text);
                        // Simulate work with a short delay
                        Thread.Sleep(200);
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during processing: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
