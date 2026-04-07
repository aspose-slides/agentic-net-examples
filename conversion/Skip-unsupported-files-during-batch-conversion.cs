using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide input file paths as arguments.");
                return;
            }

            foreach (string inputPath in args)
            {
                try
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("File not found: " + inputPath);
                        continue;
                    }

                    // Determine output PDF path
                    string directory = Path.GetDirectoryName(inputPath);
                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(directory ?? "", filenameWithoutExt + ".pdf");

                    // Load presentation and convert to PDF
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                    {
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                    }

                    Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    Console.WriteLine("Unsupported PPTX format (skipping): " + inputPath);
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    Console.WriteLine("Unsupported PPT format (skipping): " + inputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing " + inputPath + ": " + ex.Message);
                }
            }
        }
    }
}