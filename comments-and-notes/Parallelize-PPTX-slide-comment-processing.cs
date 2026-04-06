using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentProcessingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add two empty slides based on the first layout slide
            pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("AuthorName", "AN");

            // Define comment position
            System.Drawing.PointF position = new System.Drawing.PointF(0.2f, 0.2f);

            // Add comments to the first two slides
            author.Comments.AddComment("Comment on slide 1", pres.Slides[0], position, DateTime.Now);
            author.Comments.AddComment("Comment on slide 2", pres.Slides[1], position, DateTime.Now);

            // Process comments in parallel for all slides
            Aspose.Slides.ISlideCollection slideCollection = pres.Slides;
            Parallel.For(0, slideCollection.Count, i =>
            {
                Aspose.Slides.ISlide slide = slideCollection[i];
                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                foreach (Aspose.Slides.IComment comment in comments)
                {
                    Console.WriteLine("Slide " + slide.SlideNumber + " comment: " + comment.Text + " by " + comment.Author.Name);
                }
            });

            // Save the presentation
            string outPath = Path.Combine(Environment.CurrentDirectory, "CommentsParallel_out.pptx");
            try
            {
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}