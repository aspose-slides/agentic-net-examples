using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPpts");
            string outputDir = Path.Combine(Environment.CurrentDirectory, "OutputPngs");

            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all PPT and PPTX files
            string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt");
            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");
            string[] allFiles = new string[pptFiles.Length + pptxFiles.Length];
            pptFiles.CopyTo(allFiles, 0);
            pptxFiles.CopyTo(allFiles, pptFiles.Length);

            foreach (string filePath in allFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                try
                {
                    // Load presentation
                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath))
                    {
                        // Define output format string with slide number prefix
                        string formatString = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + "_Slide_{0}.png");

                        for (int index = 0; index < pres.Slides.Count; index++)
                        {
                            Aspose.Slides.ISlide slide = pres.Slides[index];
                            using (Aspose.Slides.IImage image = slide.GetImage())
                            {
                                string outputPath = String.Format(formatString, slide.SlideNumber);
                                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                            }
                        }

                        // Save presentation before exit (no modifications)
                        string tempSavePath = Path.Combine(outputDir, Path.GetFileName(filePath));
                        pres.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported for file: " + filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}