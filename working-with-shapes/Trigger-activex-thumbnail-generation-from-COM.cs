using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPptx = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            string outputPng = Path.Combine(Directory.GetCurrentDirectory(), "shape_thumbnail.png");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation that contains ActiveX controls
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Iterate through ActiveX controls on the slide
                foreach (Aspose.Slides.IControl ctrl in slide.Controls)
                {
                    // Trigger thumbnail generation when a control with a specific name is found
                    if (ctrl.Name == "GenerateThumbnail")
                    {
                        // Create a rectangle shape on the slide
                        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Rectangle,
                            100,   // X position
                            100,   // Y position
                            200,   // Width
                            100);  // Height

                        // Configure shape appearance
                        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

                        // Generate thumbnail image for the shape
                        Aspose.Slides.IImage shapeImage = shape.GetImage(
                            Aspose.Slides.ShapeThumbnailBounds.Shape,
                            1f,    // Scale X
                            1f);   // Scale Y

                        // Save the thumbnail as PNG
                        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the modified presentation
                pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., COM interop issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}