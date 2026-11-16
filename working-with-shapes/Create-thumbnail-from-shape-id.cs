// -----------------------------------------------------------------------------
// Example: Create shape thumbnail from OfficeInteropShapeId using Aspose.Slides
//
// Description:
// Demonstrates how to locate a shape by its OfficeInteropShapeId in a PPTX file,
// generate a thumbnail image for that shape with optional scaling, and save the
// image to disk. The program also creates a sample presentation if none exists
// and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shape thumbnail, OfficeInteropShapeId
//
// Use Cases:
// - Generate visual previews of individual shapes for documentation.
// - Extract shape images for reuse in other media.
// - Automate batch processing of presentations to create shape thumbnails.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ShapeThumbnailExample
{
    class Program
    {
        private static Aspose.Slides.IImage GetShapeThumbnail(Aspose.Slides.Presentation presentation, uint shapeId, float scaleX, float scaleY)
        {
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == shapeId)
                    {
                        Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);
                        return shapeImage;
                    }
                }
            }
            return null;
        }

        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputImagePath = "shape_thumbnail.png";
            string outputPresentationPath = "output.pptx";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IAutoShape sampleShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                    sampleShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    sampleShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Failed to create input file: " + inputPath);
                    Environment.Exit(1);
                }

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                uint targetShapeId = 0;
                Aspose.Slides.IShape targetShape = null;

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape.OfficeInteropShapeId != 0)
                        {
                            targetShapeId = shape.OfficeInteropShapeId;
                            targetShape = shape;
                            break;
                        }
                    }
                    if (targetShape != null)
                    {
                        break;
                    }
                }

                if (targetShape == null)
                {
                    Console.WriteLine("No shapes found in the presentation.");
                    presentation.Dispose();
                    Environment.Exit(1);
                }

                float scaleX = 1.0f;
                float scaleY = 1.0f;
                Aspose.Slides.IImage thumbnail = GetShapeThumbnail(presentation, targetShapeId, scaleX, scaleY);
                if (thumbnail != null)
                {
                    thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                    thumbnail.Dispose();
                    Console.WriteLine("Thumbnail saved to: " + outputImagePath);
                }
                else
                {
                    Console.WriteLine("Failed to generate thumbnail for shape ID " + targetShapeId);
                    presentation.Dispose();
                    Environment.Exit(1);
                }

                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
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
        }
    }
}
