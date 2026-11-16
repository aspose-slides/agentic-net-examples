// -----------------------------------------------------------------------------
// Example: Validate Shape Thumbnails Within Slide Dimensions Using C#
// 
// Description:
// Demonstrates generating thumbnails for each shape using bounds‑based rendering
// and verifies that the thumbnail dimensions do not exceed the slide size. The
// program creates a sample PPTX if none exists, checks each shape thumbnail,
// reports any violations, and saves the presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shape Thumbnail, Bounds Rendering,
// Validate Thumbnail Size, Slide Dimensions
// 
// Use Cases:
// - Ensure shape thumbnails fit within slide boundaries in automated workflows.
// - Build validation tools for PowerPoint content before publishing.
// - Detect oversized shape renderings during batch processing of presentations.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide firstSlide = samplePresentation.Slides[0];
                Aspose.Slides.IShape rectangle = firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f);
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.FillFormat.SolidFillColor.Color = Color.Blue;
                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
                Console.WriteLine("Sample presentation created: " + inputPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating sample presentation: " + ex.Message);
                Environment.Exit(1);
            }
        }

        bool violationFound = false;

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            float slideWidth = presentation.SlideSize.Size.Width;
            float slideHeight = presentation.SlideSize.Size.Height;

            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IImage thumbnail = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                    if ((float)thumbnail.Width > slideWidth || (float)thumbnail.Height > slideHeight)
                    {
                        Console.WriteLine("Thumbnail of a shape exceeds slide dimensions on slide " + slide.SlideNumber + ".");
                        violationFound = true;
                    }
                    thumbnail.Dispose();
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }

        if (violationFound)
        {
            Environment.Exit(1);
        }
        else
        {
            Environment.Exit(0);
        }
    }
}
