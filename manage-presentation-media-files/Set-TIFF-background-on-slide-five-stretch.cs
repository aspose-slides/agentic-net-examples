// -----------------------------------------------------------------------------
// Example: Set TIFF background on slide five stretch using C#
//
// Description:
// Demonstrates how to set a TIFF image as the background of the fifth slide
// in a presentation, stretching the image to fill the slide. The example uses
// Aspose.Slides for .NET to create a presentation, ensure at least five slides,
// add the TIFF image as a picture fill, and save the result as a PPTX file.
// This pattern can be used in console applications for automated PowerPoint
// processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, Background, Slide, Five,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a TIFF background on the fifth slide with stretch mode.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with custom slide backgrounds in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string dataDir = Directory.GetCurrentDirectory();
            string imageFileName = "background.tiff";
            string imagePath = Path.Combine(dataDir, imageFileName);
            string outputPath = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Ensure there are at least five slides
                while (presentation.Slides.Count < 5)
                {
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                Aspose.Slides.ISlide slide5 = presentation.Slides[4];
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
                Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(img);

                slide5.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide5.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                slide5.Background.FillFormat.PictureFillFormat.Picture.Image = imgx;
                slide5.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
