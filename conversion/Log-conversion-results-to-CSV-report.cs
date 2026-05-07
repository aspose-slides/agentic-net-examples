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
            // Determine input directory
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Prepare CSV report
            string reportPath = Path.Combine(inputDirectory, "conversion_report.csv");
            using (StreamWriter reportWriter = new StreamWriter(reportPath, false))
            {
                // Write CSV header
                reportWriter.WriteLine("FilePath,Status,Message");

                // Supported extensions for conversion
                string[] supportedExtensions = new string[]
                {
                    ".ppt", ".pptx", ".odp", ".pptm", ".ppsx", ".ppsm",
                    ".potx", ".potm", ".pps", ".pot", ".fodp", ".xml"
                };

                // Get all files in the directory
                string[] allFiles = Directory.GetFiles(inputDirectory);
                foreach (string filePath in allFiles)
                {
                    string extension = Path.GetExtension(filePath).ToLowerInvariant();
                    if (Array.IndexOf(supportedExtensions, extension) < 0)
                    {
                        // Skip unsupported file types
                        continue;
                    }

                    try
                    {
                        // Load presentation
                        using (Presentation pres = new Presentation(filePath))
                        {
                            // Convert-to-pdf rule: determine output PDF path
                            string __inputPath__ = filePath;
                            string __directory__ = Path.GetDirectoryName(__inputPath__);
                            string __filenameWithoutExt__ = Path.GetFileNameWithoutExtension(__inputPath__);
                            string __outputPath__ = Path.Combine(__directory__ ?? "", __filenameWithoutExt__ + ".pdf");

                            // Save as PDF using convert-without-xps-options rule
                            pres.Save(__outputPath__, Aspose.Slides.Export.SaveFormat.Pdf);

                            // Log success
                            reportWriter.WriteLine($"{filePath},Success,Converted to PDF");
                        }
                    }
                    catch (NotSupportedException)
                    {
                        // Log format not supported
                        reportWriter.WriteLine($"{filePath},Failure,Format not supported");
                    }
                    catch (Exception ex)
                    {
                        // Log any other failure
                        reportWriter.WriteLine($"{filePath},Failure,{ex.Message}");
                    }
                }
            }

            Console.WriteLine("Batch conversion completed. Report saved to: " + reportPath);
        }
    }
}