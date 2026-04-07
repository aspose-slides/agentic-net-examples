using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchEmbedFontAndCreatePngThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory = args.Length > 0 ? args[0] : "InputPptx";
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine($"Directory does not exist: {inputDirectory}");
                return;
            }

            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);
            foreach (string pptxPath in pptxFiles)
            {
                if (!File.Exists(pptxPath))
                {
                    Console.WriteLine($"File not found: {pptxPath}");
                    continue;
                }

                try
                {
                    using (Presentation presentation = new Presentation(pptxPath))
                    {
                        // Embed all fonts used in the presentation
                        IFontData[] allFonts = presentation.FontsManager.GetFonts();
                        IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
                        foreach (IFontData font in allFonts)
                        {
                            bool alreadyEmbedded = false;
                            foreach (IFontData embedded in embeddedFonts)
                            {
                                if (embedded.FontName == font.FontName)
                                {
                                    alreadyEmbedded = true;
                                    break;
                                }
                            }

                            if (!alreadyEmbedded)
                            {
                                presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
                            }
                        }

                        // Save the presentation with embedded fonts
                        presentation.Save(pptxPath, SaveFormat.Pptx);

                        // Generate PNG thumbnails for each slide
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                            ISlide slide = presentation.Slides[i];
                            using (IImage image = slide.GetImage(1f, 1f))
                            {
                                string outputFileName = Path.Combine(
                                    inputDirectory,
                                    $"{Path.GetFileNameWithoutExtension(pptxPath)}_slide_{i + 1}.png");
                                image.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"Unsupported format for file: {pptxPath}");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error processing file {pptxPath}: {ex.Message}");
                }
            }
        }
    }
}