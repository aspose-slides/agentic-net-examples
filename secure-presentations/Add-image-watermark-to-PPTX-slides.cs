// -----------------------------------------------------------------------------
// Example: Add image watermark to PPTX slides using C#
//
// Description:
// Demonstrates how to add an image watermark to PPTX slides using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Image, Watermark, Pptx, Slides, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add image watermark to PPTX slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AddImageWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentation and watermark image
            string presentationPath = "input.pptx";
            string watermarkImagePath = "watermark.png";
            string outputPath = "output.pptx";

            // Verify that the input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(watermarkImagePath))
            {
                Console.WriteLine("Watermark image file not found: " + watermarkImagePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(presentationPath))
                {
                    // Load watermark image bytes and add to the presentation's image collection
                    byte[] watermarkBytes = File.ReadAllBytes(watermarkImagePath);
                    IPPImage watermarkImg = pres.Images.AddImage(watermarkBytes);

                    // Iterate through all slides and add the watermark
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Get slide dimensions
                        float slideWidth = pres.SlideSize.Size.Width;
                        float slideHeight = pres.SlideSize.Size.Height;

                        // Add picture frame that covers the entire slide
                        IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                            ShapeType.Rectangle,
                            0,
                            0,
                            slideWidth,
                            slideHeight,
                            watermarkImg);

                        // Apply 30% opacity using Alpha Modulate Fixed effect
                        IImageTransformOperationCollection imgTransform = ((ISlidesPicture)pictureFrame).ImageTransform;
                        imgTransform.AddAlphaModulateFixedEffect(30f);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
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
