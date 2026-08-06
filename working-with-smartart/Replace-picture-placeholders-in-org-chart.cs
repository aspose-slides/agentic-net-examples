// -----------------------------------------------------------------------------
// Example: Replace picture placeholders in org chart using C#
//
// Description:
// Demonstrates how to replace picture placeholders in an organization chart using
// C# and Aspose.Slides for .NET. The example loads a PPTX file, iterates over
// picture shapes on the first slide, replaces each placeholder image with a
// high‑resolution image retrieved (simulated) from a database, and saves the
// modified presentation. This pattern can be used to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Picture, Placeholders,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of picture placeholders in organization charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Assume the organization chart is on the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    int placeholderIndex = 0;

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.ISlidesPicture)
                        {
                            Aspose.Slides.ISlidesPicture pictureShape = (Aspose.Slides.ISlidesPicture)shape;

                            byte[] imageData = null;
                            try
                            {
                                // Replace this with actual database retrieval logic
                                imageData = GetImageBytesFromDatabase(placeholderIndex);
                            }
                            catch (WebException webEx)
                            {
                                Console.WriteLine("Failed to retrieve image from database: " + webEx.Message);
                                continue;
                            }

                            if (imageData != null && imageData.Length > 0)
                            {
                                Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);
                                pictureShape.Image = img;
                            }

                            placeholderIndex++;
                        }
                    }

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Mock method to simulate fetching high‑resolution photos from a database
        static byte[] GetImageBytesFromDatabase(int id)
        {
            // In a real scenario, replace this with actual DB access code.
            // Here we simply read a local file named "photo{id}.png".
            string fileName = $"photo{id}.png";

            if (!File.Exists(fileName))
                throw new WebException("Image file not found: " + fileName);

            return File.ReadAllBytes(fileName);
        }
    }
}
