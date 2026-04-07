using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = @"C:\InputPresentations";
            string outputDirectory = @"C:\OutputPresentations";

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

            // Get all presentation files (common formats)
            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            long totalOriginalSize = 0;
            long totalConvertedSize = 0;

            foreach (string filePath in presentationFiles)
            {
                // Filter supported extensions
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")
                {
                    // Skip unsupported file types
                    continue;
                }

                // Check file existence (redundant but follows rule)
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                long originalSize = new FileInfo(filePath).Length;
                totalOriginalSize += originalSize;

                try
                {
                    // Load presentation
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Define output file path (convert to PDF)
                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Save presentation in PDF format
                        presentation.Save(outputPath, SaveFormat.Pdf);

                        // Accumulate converted file size
                        long convertedSize = new FileInfo(outputPath).Length;
                        totalConvertedSize += convertedSize;
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported – comment as required
                    Console.WriteLine("Format not supported for file: " + filePath);
                }
                catch (Exception ex) when (ex is DirectoryNotFoundException || ex is FileNotFoundException)
                {
                    // Handle directory or file not found exceptions
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine(ex.Message);
                }
            }

            // Generate summary report
            if (totalOriginalSize > 0)
            {
                long sizeReduction = totalOriginalSize - totalConvertedSize;
                double reductionPercentage = (double)sizeReduction / totalOriginalSize * 100.0;
                Console.WriteLine("Total original size: {0} bytes", totalOriginalSize);
                Console.WriteLine("Total converted size: {0} bytes", totalConvertedSize);
                Console.WriteLine("Total size reduction: {0} bytes ({1:F2}%)", sizeReduction, reductionPercentage);
            }
            else
            {
                Console.WriteLine("No presentations were processed.");
            }
        }
    }
}