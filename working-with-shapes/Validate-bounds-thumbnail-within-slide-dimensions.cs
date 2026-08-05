// -----------------------------------------------------------------------------
// Example: Validate bounds thumbnail within slide dimensions using C#
//
// Description:
// Demonstrates how to generate thumbnails for each shape using bounds‑based
// rendering and verify that the resulting thumbnail dimensions do not exceed
// the slide size. The example loads a PPTX file, iterates through slides and
// shapes, creates a thumbnail for each shape, checks its width and height
// against the presentation slide dimensions, reports any violations, and
// saves the presentation.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Shape Thumbnail, Bounds Rendering,
// Validate Thumbnail Size, Slide Dimensions, Presentation Automation
//
// Use Cases:
// - Ensure shape thumbnails fit within slide boundaries in automated workflows.
// - Build validation tools for PowerPoint content before publishing.
// - Integrate thumbnail size checks into .NET applications that process PPTX files.
// - Detect oversized shape renderings during batch processing of presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            foreach (var slide in presentation.Slides)
            {
                var slideWidth = presentation.SlideSize.Size.Width;
                var slideHeight = presentation.SlideSize.Size.Height;

                // Iterate through each shape on the slide
                foreach (var shape in slide.Shapes)
                {
                    // Generate a thumbnail using bounds‑based rendering (shape bounds)
                    var scaleX = 1f;
                    var scaleY = 1f;
                    var thumbnail = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

                    // Validate that the thumbnail does not exceed slide dimensions
                    if (thumbnail.Width > slideWidth || thumbnail.Height > slideHeight)
                    {
                        Console.WriteLine($"Thumbnail of a shape exceeds slide dimensions on slide {slide.SlideNumber}.");
                    }

                    // Release the thumbnail resources
                    thumbnail.Dispose();
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
