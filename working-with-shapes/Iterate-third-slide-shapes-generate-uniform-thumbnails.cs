// -----------------------------------------------------------------------------
// Example: Generate Uniform Thumbnails for Shapes on Third Slide
//
// Description:
// Demonstrates how to iterate over all shapes on the third slide of a PowerPoint
// presentation and generate uniformly scaled thumbnail PNG images using C# and
// Aspose.Slides for .NET. The program creates a sample presentation if none is
// found, extracts each shape as a thumbnail, and saves them to a folder.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shape thumbnails, third slide
//
// Use Cases:
// - Automate extraction of shape images for documentation.
// - Build tools that need visual previews of slide elements.
// - Integrate shape thumbnail generation into .NET presentation workflows.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ShapeThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputDirectory = "thumbnails";

            try
            {
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();

                    while (samplePres.Slides.Count < 3)
                    {
                        Aspose.Slides.ILayoutSlide layout = samplePres.Slides[0].LayoutSlide;
                        samplePres.Slides.AddEmptySlide(layout);
                    }

                    Aspose.Slides.ISlide thirdSlide = samplePres.Slides[2];
                    Aspose.Slides.IAutoShape rectShape = thirdSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 200f, 100f);
                    rectShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    Aspose.Slides.IAutoShape ellipseShape = thirdSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300f, 150f, 150f, 150f);
                    ellipseShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                if (pres.Slides.Count < 3)
                {
                    Console.WriteLine("The presentation does not contain a third slide.");
                    pres.Dispose();
                    Environment.Exit(1);
                }

                Aspose.Slides.ISlide slide = pres.Slides[2];

                int shapeIndex = 0;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1.0f, 1.0f);
                    string outputPath = Path.Combine(outputDirectory, $"shape_{shapeIndex}.png");
                    shapeImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    shapeImage.Dispose();
                    shapeIndex++;
                }

                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
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
        }
    }
}
