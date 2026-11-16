// -----------------------------------------------------------------------------
// Example: Clone First Slide to End and Add Comment
//
// Description:
// Demonstrates how to clone the first slide of a PPTX file to the end of the
// presentation and add a comment to the cloned slide using Aspose.Slides for .NET.
// The program creates a sample input file if none exists, performs the operation,
// and saves the result as a new PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Add Comment
//
// Use Cases:
// - Automate duplication of a slide with annotation for review processes.
// - Build utilities that programmatically add comments to specific slides.
// - Prepare presentations for collaborative editing by inserting reviewer notes.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Create a sample presentation if input file does not exist
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Clone the first slide to the end
            Aspose.Slides.ISlideCollection slides = pres.Slides;
            Aspose.Slides.ISlide clonedSlide = slides.AddClone(slides[0]);

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = pres.CommentAuthors.AddAuthor("AuthorName", "AN");

            // Define comment position
            PointF commentPos = new PointF(0.2f, 0.2f);

            // Add a comment to the cloned slide
            author.Comments.AddComment("This is a comment on the cloned slide", clonedSlide, commentPos, DateTime.Now);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // If the exception is related to unsupported format, note it
            if (ex.Message != null && ex.Message.IndexOf("format", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // Format not supported
                Console.WriteLine("Error: File format not supported.");
            }
            else
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Environment.Exit(1);
        }
    }
}
