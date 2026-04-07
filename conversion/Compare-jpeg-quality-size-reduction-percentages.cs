using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideQualityComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                CompareJpegQuality(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void CompareJpegQuality(string inputPath)
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Define JPEG quality levels to test
            byte[] qualities = new byte[] { 100, 80, 60, 40, 20 };

            // Store file sizes for each quality
            long[] fileSizes = new long[qualities.Length];

            // Directory for temporary PDF files
            string outputDir = Path.Combine(Path.GetDirectoryName(inputPath), "QualityComparison");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Save PDF with each quality setting and record file size
            for (int i = 0; i < qualities.Length; i++)
            {
                string outputPath = Path.Combine(outputDir, $"output_quality_{qualities[i]}.pdf");

                // Configure PDF options
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.JpegQuality = qualities[i];

                // Save presentation as PDF with the specified JPEG quality
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                // Record file size
                FileInfo fileInfo = new FileInfo(outputPath);
                fileSizes[i] = fileInfo.Length;
            }

            // Calculate and display reduction percentages relative to the highest quality (100)
            long baseSize = fileSizes[0];
            Console.WriteLine("JPEG Quality Comparison (File Size in bytes):");
            for (int i = 0; i < qualities.Length; i++)
            {
                double reduction = 0;
                if (baseSize > 0)
                {
                    reduction = ((double)(baseSize - fileSizes[i]) / baseSize) * 100;
                }
                Console.WriteLine($"Quality {qualities[i]}: {fileSizes[i]} bytes, Reduction: {reduction:F2}%");
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}