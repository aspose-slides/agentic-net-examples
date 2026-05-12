using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideThumbnailComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputRegularThumb = "thumb_regular.jpg";
            string outputEmbeddedThumb = "thumb_embedded.jpg";
            string outputPresentation = "output_embedded.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Create rendering options with a default regular font
                RenderingOptions renderOpts = new RenderingOptions();
                renderOpts.DefaultRegularFont = "Arial";

                // Generate thumbnail using default regular font
                IImage regularImage = pres.Slides[0].GetImage(renderOpts, 1f, 1f);
                regularImage.Save(outputRegularThumb, Aspose.Slides.ImageFormat.Jpeg);
                regularImage.Dispose();

                // Add embedded fonts (using provided rule pattern)
                IFontData[] allFonts = pres.FontsManager.GetFonts();
                IFontData[] embeddedFonts = pres.FontsManager.GetEmbeddedFonts();
                foreach (IFontData font in allFonts)
                {
                    bool isEmbedded = false;
                    foreach (IFontData ef in embeddedFonts)
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

                // Save presentation after embedding fonts
                pres.Save(outputPresentation, SaveFormat.Pptx);

                // Generate thumbnail after embedding fonts
                IImage embeddedImage = pres.Slides[0].GetImage(renderOpts, 1f, 1f);
                embeddedImage.Save(outputEmbeddedThumb, Aspose.Slides.ImageFormat.Jpeg);
                embeddedImage.Dispose();

                // Compare dimensions (width and height)
                // Note: IImage provides Width and Height properties
                int regularWidth = regularImage.Width;
                int regularHeight = regularImage.Height;
                int embeddedWidth = embeddedImage.Width;
                int embeddedHeight = embeddedImage.Height;

                Console.WriteLine("Regular thumbnail size: {0}x{1}", regularWidth, regularHeight);
                Console.WriteLine("Embedded thumbnail size: {0}x{1}", embeddedWidth, embeddedHeight);
                if (regularWidth == embeddedWidth && regularHeight == embeddedHeight)
                {
                    Console.WriteLine("Thumbnail dimensions are identical.");
                }
                else
                {
                    Console.WriteLine("Thumbnail dimensions differ.");
                }

                // Dispose presentation
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}