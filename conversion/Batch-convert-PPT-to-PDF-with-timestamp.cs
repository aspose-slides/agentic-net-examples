using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchPptToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = @"C:\InputPresentations";
            string outputDirectory = @"C:\OutputPDFs";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PowerPoint files in the input directory
            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in pptFiles)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".ppt" && extension != ".pptx" && extension != ".odp")
                {
                    continue; // Skip non-PowerPoint files
                }

                try
                {
                    // Load the presentation
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                    {
                        // Add timestamp footer to all slides
                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        presentation.HeaderFooterManager.SetAllFootersVisibility(true);
                        presentation.HeaderFooterManager.SetAllFootersText(timestamp);

                        // Prepare output PDF path
                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Save as PDF
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
                    }
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Format not supported for PPT files
                    Console.WriteLine("Unsupported PPT format: " + filePath);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported for PPTX files
                    Console.WriteLine("Unsupported PPTX format: " + filePath);
                }
                catch (NotSupportedException)
                {
                    // General unsupported format exception
                    Console.WriteLine("File format not supported: " + filePath);
                }
                catch (Exception ex)
                {
                    // Handle other unexpected errors
                    Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
                }
            }
        }
    }
}