using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolder = "InputPresentations";
            string outputFolder = "OutputImages";

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".potx", ".potm" };
            string[] presentationFiles = Directory.GetFiles(inputFolder);

            foreach (string filePath in presentationFiles)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string extension = Path.GetExtension(filePath).ToLowerInvariant();
                    bool isSupported = false;
                    foreach (string ext in supportedExtensions)
                    {
                        if (extension == ext)
                        {
                            isSupported = true;
                            break;
                        }
                    }

                    if (!isSupported)
                    {
                        // format not supported
                        Console.WriteLine($"Unsupported format: {filePath}");
                        continue;
                    }

                    // Load with fallback font (DefaultRegularFont)
                    LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
                    loadOptions.DefaultRegularFont = "Arial";

                    using (Presentation presentation = new Presentation(filePath, loadOptions))
                    {
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                            ISlide slide = presentation.Slides[i];
                            // Generate full‑scale image
                            IImage image = slide.GetImage(1f, 1f);
                            string outputFileName = Path.GetFileNameWithoutExtension(filePath) + $"_slide_{i + 1}.png";
                            string outputPath = Path.Combine(outputFolder, outputFileName);
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }

                        // Save presentation before exit (no changes made, but fulfills requirement)
                        string tempSavePath = Path.Combine(outputFolder, Path.GetFileName(filePath));
                        presentation.Save(tempSavePath, SaveFormat.Pptx);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // format not supported
                    Console.WriteLine($"Unsupported format exception for file: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }
    }
}