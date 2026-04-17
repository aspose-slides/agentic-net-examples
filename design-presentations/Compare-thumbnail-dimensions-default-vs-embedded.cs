using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideThumbnailComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string defaultThumbPath = "thumb_default.jpg";
            string embeddedThumbPath = "thumb_embedded.jpg";
            string embeddedPresPath = "presentation_embedded.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation with default regular font for rendering
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions(Aspose.Slides.LoadFormat.Auto);
                loadOptions.DefaultRegularFont = "Arial";
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions);

                // Generate thumbnail using default regular font
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IImage defaultImg = slide.GetImage(1f, 1f);
                defaultImg.Save(defaultThumbPath, Aspose.Slides.ImageFormat.Jpeg);
                defaultImg.Dispose();

                // Add all missing fonts as embedded fonts (add-embedded-fonts rule)
                Aspose.Slides.IFontData[] allFonts = pres.FontsManager.GetFonts();
                Aspose.Slides.IFontData[] embeddedFonts = pres.FontsManager.GetEmbeddedFonts();
                foreach (Aspose.Slides.IFontData font in allFonts)
                {
                    bool isEmbedded = false;
                    foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                    {
                        if (ef.Equals(font))
                        {
                            isEmbedded = true;
                            break;
                        }
                    }
                    if (!isEmbedded)
                    {
                        pres.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                }

                // Save presentation with embedded fonts
                pres.Save(embeddedPresPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Generate thumbnail after embedding fonts
                Aspose.Slides.IImage embeddedImg = slide.GetImage(1f, 1f);
                embeddedImg.Save(embeddedThumbPath, Aspose.Slides.ImageFormat.Jpeg);
                embeddedImg.Dispose();

                // Compare dimensions of the two thumbnails
                Image imgDefault = Image.FromFile(defaultThumbPath);
                Image imgEmbedded = Image.FromFile(embeddedThumbPath);
                Console.WriteLine("Default thumbnail size: {0}x{1}", imgDefault.Width, imgDefault.Height);
                Console.WriteLine("Embedded thumbnail size: {0}x{1}", imgEmbedded.Width, imgEmbedded.Height);
                imgDefault.Dispose();
                imgEmbedded.Dispose();

                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}