// -----------------------------------------------------------------------------
// Example: Export shape thumbnail to PNG base64 using C#
//
// Description:
// Demonstrates how to export a shape thumbnail to a PNG Base64 string using
// C# and Aspose.Slides for .NET. The example loads a presentation, selects a
// shape from a slide, renders the shape as a PNG image, converts the image to
// a Base64 string and writes the data URI to the console. This pattern can be
// used to embed shape previews in web pages, generate thumbnails for UI
// elements, or automate PowerPoint processing workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Shape, Thumbnail,
// Base64, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of a shape thumbnail to PNG Base64.
// - Build C# tools for PowerPoint presentation processing that need shape previews.
// - Generate or transform PPTX files in .NET applications while exposing shape images.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "sample.pptx";
            // Slide index (0‑based)
            int slideIndex = 0;
            // Shape index on the slide (0‑based)
            int shapeIndex = 0;

            // Override with command line arguments if provided
            if (args.Length >= 1)
                inputPath = args[0];
            if (args.Length >= 2)
                Int32.TryParse(args[1], out slideIndex);
            if (args.Length >= 3)
                Int32.TryParse(args[2], out shapeIndex);

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Ensure slide index is within range
                if (slideIndex < 0 || slideIndex >= pres.Slides.Count)
                {
                    Console.WriteLine("Slide index out of range.");
                    return;
                }

                // Get the requested slide
                ISlide slide = pres.Slides[slideIndex];

                // Ensure shape index is within range
                if (shapeIndex < 0 || shapeIndex >= slide.Shapes.Count)
                {
                    Console.WriteLine("Shape index out of range.");
                    return;
                }

                // Get the requested shape
                IShape shape = slide.Shapes[shapeIndex];

                // Create a thumbnail image of the shape (full scale)
                IImage thumbnail = shape.GetThumbnail(1f, 1f);

                // Save the thumbnail to a memory stream in PNG format
                using (MemoryStream ms = new MemoryStream())
                {
                    thumbnail.Save(ms, ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();

                    // Convert the image bytes to a Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Output the Base64 string as a data URI (can be embedded in HTML)
                    Console.WriteLine("data:image/png;base64," + base64String);
                }

                // Save the presentation (optional, as required by some workflows)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
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
