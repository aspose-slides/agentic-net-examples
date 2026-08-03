// -----------------------------------------------------------------------------
// Example: Set common logo as slide background using C#
//
// Description:
// Demonstrates how to set a common logo as the background image for every slide
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads an existing presentation and a logo image, applies the logo as a
// stretched background to each slide, and saves the result as a new PPTX file.
// This pattern can be used to automate branding or watermarking of slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Common, Logo, Slide, 
// Background, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a common logo as slide background across a presentation.
// - Build C# tools for PowerPoint branding and visual consistency.
// - Generate or transform PPTX files with custom background images in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBackgroundUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string logoPath = "logo.png";
            string outputPath = "output.pptx";

            // Verify input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Verify logo image exists
            if (!File.Exists(logoPath))
            {
                Console.WriteLine("Logo image file not found: " + logoPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Load the logo image and add it to the presentation's image collection
                    Image logoImage = Image.FromFile(logoPath);
                    IPPImage logoIppImage = pres.Images.AddImage(logoImage);

                    // Apply the logo as background image to each slide
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        slide.Background.Type = BackgroundType.OwnBackground;
                        slide.Background.FillFormat.FillType = FillType.Picture;
                        slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                        slide.Background.FillFormat.PictureFillFormat.Picture.Image = logoIppImage;
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
