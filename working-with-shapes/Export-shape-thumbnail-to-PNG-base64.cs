// -----------------------------------------------------------------------------
// Example: Export Shape Thumbnail to PNG Base64 String using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, extracts the first
// shape from the first slide, renders the shape as a PNG image, converts the
// PNG to a Base64 string, and outputs a data URI. It demonstrates how to embed
// shape previews in web pages or generate thumbnails for UI elements using
// Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shape thumbnail, Base64, PNG
//
// Use Cases:
// - Embed shape preview images directly into HTML pages without separate files.
// - Generate thumbnail images for UI components that represent slide shapes.
// - Automate PowerPoint processing workflows that require shape image extraction.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ShapeThumbnailBase64Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine("Error: The file \"{0}\" does not exist.", inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];

                if (slide.Shapes.Count == 0)
                {
                    Console.Error.WriteLine("Error: No shapes found on the first slide.");
                    pres.Dispose();
                    return;
                }

                Aspose.Slides.IShape shape = slide.Shapes[0] as Aspose.Slides.IShape;
                if (shape == null)
                {
                    Console.Error.WriteLine("Error: The first item on the slide is not a shape.");
                    pres.Dispose();
                    return;
                }

                // Render the shape as a PNG image with default scaling (1.0f, 1.0f)
                Aspose.Slides.IImage shapeImage = shape.GetImage(
                    Aspose.Slides.ShapeThumbnailBounds.Shape,
                    1.0f,
                    1.0f);

                using (MemoryStream ms = new MemoryStream())
                {
                    shapeImage.Save(ms, Aspose.Slides.ImageFormat.Png);
                    byte[] pngBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(pngBytes);
                    string dataUri = "data:image/png;base64," + base64String;
                    Console.WriteLine(dataUri);
                }

                // Save the presentation (no modifications made, but required by the rule)
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: {0}", ex.Message);
            }
        }
    }
}
