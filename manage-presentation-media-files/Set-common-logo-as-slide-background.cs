// -----------------------------------------------------------------------------
// Example: Set Common Logo as Slide Background using Aspose.Slides for .NET
//
// Description:
// This console application loads an existing PPTX file and a logo image,
// then applies the logo as a stretched picture background to every slide.
// It demonstrates branding or watermarking of presentations using C# and
// Aspose.Slides for .NET, and saves the modified presentation as a new PPTX.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide background image, branding, watermark
//
// Use Cases:
// - Automatically add corporate logo to all slides in a presentation.
// - Create branded slide decks for marketing or internal communications.
// - Apply a consistent watermark across multiple presentations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SlideBackgroundLogoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPresentationPath = "input.pptx";
            string logoImagePath = "logo.png";
            string outputPresentationPath = "output.pptx";

            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPresentationPath);
                return;
            }

            if (!File.Exists(logoImagePath))
            {
                Console.WriteLine("Logo image not found: " + logoImagePath);
                return;
            }

            try
            {
                byte[] logoBytes = File.ReadAllBytes(logoImagePath);
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPresentationPath);
                Aspose.Slides.IPPImage logoImage = presentation.Images.AddImage(logoBytes);

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    slide.Background.FillFormat.PictureFillFormat.Picture.Image = logoImage;
                    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                }

                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPresentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
