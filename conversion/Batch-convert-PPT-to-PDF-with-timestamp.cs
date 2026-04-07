using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertPptToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDir = "C:\\InputPpt";
            string outputDir = "C:\\OutputPdf";

            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt", SearchOption.TopDirectoryOnly);
            string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx", SearchOption.TopDirectoryOnly);
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
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                    {
                        // Add timestamp footer to all slides
                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        presentation.HeaderFooterManager.SetAllFootersText(timestamp);
                        presentation.HeaderFooterManager.SetAllFootersVisibility(true);

                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                        // Save as PDF
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                    }
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Format not supported
                    Console.WriteLine("Unsupported format for file: " + filePath);
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