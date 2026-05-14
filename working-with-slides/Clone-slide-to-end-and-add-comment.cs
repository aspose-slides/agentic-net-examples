using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Check if input file exists
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
            Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("AuthorName", "AN");

            // Define comment position
            System.Drawing.PointF commentPos = new System.Drawing.PointF(0.2f, 0.2f);

            // Add a comment to the cloned slide
            author.Comments.AddComment("This is a comment on the cloned slide", clonedSlide, commentPos, DateTime.Now);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
        catch (Aspose.Slides.PptxEditException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}