using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideWithComment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Clone the first slide to the end of the same presentation
                Aspose.Slides.ISlideCollection slides = pres.Slides;
                Aspose.Slides.ISlide clonedSlide = slides.AddClone(slides[0]);

                // Add a comment author
                Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("Author", "AU");

                // Define comment position
                System.Drawing.PointF commentPosition = new System.Drawing.PointF(0.2f, 0.2f);

                // Add a comment to the cloned slide
                author.Comments.AddComment("Comment on cloned slide", clonedSlide, commentPosition, System.DateTime.Now);

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                pres.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}