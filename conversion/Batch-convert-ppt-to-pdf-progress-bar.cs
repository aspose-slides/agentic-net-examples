using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConversion
{
    // Implements progress reporting for Aspose.Slides save operations
    public class ProgressCallback : IProgressCallback
    {
        private readonly string _fileName;

        public ProgressCallback(string fileName)
        {
            _fileName = fileName;
        }

        public void Reporting(double progressValue)
        {
            Console.WriteLine($"Converting \"{_fileName}\": {progressValue:F2}% completed.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Define input files; if none provided via command line, use a sample array
            string[] inputFiles;
            if (args != null && args.Length > 0)
            {
                inputFiles = args;
            }
            else
            {
                inputFiles = new string[]
                {
                    "Sample1.pptx",
                    "Sample2.pptx",
                    "Sample3.pptx"
                };
            }

            foreach (string inputPath in inputFiles)
            {
                // Verify that the source file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        // Determine output path (PDF with same base name)
                        string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                        // Set up PDF options with progress callback
                        PdfOptions pdfOptions = new PdfOptions();
                        pdfOptions.ProgressCallback = new ProgressCallback(Path.GetFileName(inputPath));

                        // Save the presentation as PDF while reporting progress
                        presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                    }

                    Console.WriteLine($"Successfully converted: {inputPath}");
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"The format of \"{inputPath}\" is not supported for conversion.");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine($"Error processing \"{inputPath}\": {ex.Message}");
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
    }
}