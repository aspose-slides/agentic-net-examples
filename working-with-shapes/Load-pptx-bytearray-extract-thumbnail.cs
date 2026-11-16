// -----------------------------------------------------------------------------
// Example: Load PPTX from byte array and extract first shape thumbnail
//
// Description:
// Demonstrates loading a PPTX file into a byte array, creating a presentation
// from the byte array, extracting a thumbnail image of the first shape on the
// first slide, and saving both the thumbnail and the presentation using
// Aspose.Slides for .NET. Includes input file existence check and creates a
// sample presentation if missing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, ByteArray, Extract, Thumbnail, Shape
//
// Use Cases:
// - Automate loading PPTX files from byte arrays and extracting shape thumbnails.
// - Build utilities for PowerPoint shape image extraction.
// - Integrate slide and shape processing into .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string outputImagePath = "shape_thumbnail.png";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    using (Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation())
                    {
                        Aspose.Slides.ISlide slide = samplePres.Slides[0];
                        Aspose.Slides.IShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                        rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        rectangle.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
                        samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }

                // Verify that the input file now exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file does not exist: " + inputPath);
                    Environment.Exit(1);
                }

                // Load the presentation into a byte array
                byte[] presentationData = File.ReadAllBytes(inputPath);

                // Load the presentation from the byte array
                using (MemoryStream memoryStream = new MemoryStream(presentationData))
                {
                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(memoryStream))
                    {
                        if (pres.Slides.Count == 0)
                        {
                            Console.WriteLine("The presentation contains no slides.");
                            Environment.Exit(1);
                        }

                        Aspose.Slides.ISlide firstSlide = pres.Slides[0];

                        if (firstSlide.Shapes.Count == 0)
                        {
                            Console.WriteLine("The first slide contains no shapes.");
                            Environment.Exit(1);
                        }

                        Aspose.Slides.IShape firstShape = firstSlide.Shapes[0];

                        using (Aspose.Slides.IImage shapeImage = firstShape.GetImage())
                        {
                            shapeImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                        }

                        // Save the presentation
                        pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }

                Console.WriteLine("Shape thumbnail saved to: " + outputImagePath);
                Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
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
