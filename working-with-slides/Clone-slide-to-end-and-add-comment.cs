// -----------------------------------------------------------------------------
// Example: Clone slide to end and add comment using C#
//
// Description:
// Demonstrates how to clone the first slide to the end of a presentation and
// add a comment to the cloned slide using C# and Aspose.Slides for .NET. The
// example loads an existing PPTX file, performs the slide cloning and comment
// insertion, and saves the result as a new PPTX file. This pattern can be used
// to automate slide duplication and annotation tasks in PowerPoint workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Add Comment,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of a slide and attaching comments programmatically.
// - Build C# utilities for annotating PowerPoint presentations.
// - Generate or modify PPTX files in .NET applications.
// - Validate presentation content before publishing or integration.
// -----------------------------------------------------------------------------

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
