using System;
using System.IO;
using Aspose.Slides.Export;

namespace BatchFontEmbed
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory = "InputPresentations";
            string outputDirectory = "Output";

            // Verify input directory exists
            if (!System.IO.Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Ensure output directory exists
            if (!System.IO.Directory.Exists(outputDirectory))
            {
                System.IO.Directory.CreateDirectory(outputDirectory);
            }

            // Process each PPTX file in the input directory
            string[] presentationFiles = System.IO.Directory.GetFiles(inputDirectory, "*.pptx");
            foreach (string presentationPath in presentationFiles)
            {
                try
                {
                    // Load the presentation
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                    {
                        // Embed all fonts used in the presentation
                        Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
                        Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

                        foreach (Aspose.Slides.IFontData font in allFonts)
                        {
                            bool isEmbedded = false;
                            foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
                            {
                                if (embedded.FontName == font.FontName)
                                {
                                    isEmbedded = true;
                                    break;
                                }
                            }
                            if (!isEmbedded)
                            {
                                presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                            }
                        }

                        // Save the presentation with embedded fonts
                        string fileBaseName = System.IO.Path.GetFileNameWithoutExtension(presentationPath);
                        string savedPresentationPath = System.IO.Path.Combine(outputDirectory, fileBaseName + "_embedded.pptx");
                        presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

                        // Generate PNG thumbnails for each slide
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                            using (Aspose.Slides.IImage slideImage = slide.GetImage())
                            {
                                string imagePath = System.IO.Path.Combine(outputDirectory, fileBaseName + "_slide_" + (slideIndex + 1) + ".png");
                                slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                            }
                        }
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);
                }
            }
        }
    }
}