using System;
using System.IO;
using Aspose.Slides.Export;

namespace BatchPptToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories
            string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPpt");
            string outputDir = Path.Combine(Environment.CurrentDirectory, "OutputSvg");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Collect PPT and PPTX files
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
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    // Format string for SVG output files
                    string formatString = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + "_slide_{0}.svg");

                    // Export each slide to SVG
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[index];
                        using (FileStream stream = new FileStream(string.Format(formatString, index + 1), FileMode.Create, FileAccess.Write))
                        {
                            slide.WriteAsSvg(stream);
                        }
                    }

                    // Dispose presentation
                    pres.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("File format not supported: " + filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }
        }
    }
}