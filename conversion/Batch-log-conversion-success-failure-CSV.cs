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
            // CSV report file
            string reportPath = "conversion_report.csv";
            using (StreamWriter reportWriter = new StreamWriter(reportPath, false))
            {
                // Write CSV header
                reportWriter.WriteLine("InputFile,OutputFile,Status,Message");

                // Determine source directory from arguments or use current directory
                string sourceDirectory;
                if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
                {
                    sourceDirectory = args[0];
                }
                else
                {
                    sourceDirectory = Directory.GetCurrentDirectory();
                }

                // Supported presentation extensions
                string[] extensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".ppsx", ".ppsm", ".potx", ".potm", ".pps", ".pot", ".otp", ".fodp", ".xml" };

                // Get all files with supported extensions
                string[] files = Directory.GetFiles(sourceDirectory, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string inputPath in files)
                {
                    // Check if file has a supported extension
                    string fileExtension = Path.GetExtension(inputPath);
                    bool isSupported = false;
                    foreach (string ext in extensions)
                    {
                        if (String.Equals(ext, fileExtension, StringComparison.OrdinalIgnoreCase))
                        {
                            isSupported = true;
                            break;
                        }
                    }

                    if (!isSupported)
                    {
                        // Log unsupported format
                        reportWriter.WriteLine($"{inputPath},,Failed,Format not supported");
                        continue;
                    }

                    // Verify that the file exists
                    if (!File.Exists(inputPath))
                    {
                        reportWriter.WriteLine($"{inputPath},,Failed,File does not exist");
                        continue;
                    }

                    // Prepare output PDF path
                    string directory = Path.GetDirectoryName(inputPath);
                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(directory ?? "", filenameWithoutExt + ".pdf");

                    try
                    {
                        // Load presentation
                        using (Presentation pres = new Presentation(inputPath))
                        {
                            // Save as PDF
                            pres.Save(outputPath, SaveFormat.Pdf);
                        }

                        // Log success
                        reportWriter.WriteLine($"{inputPath},{outputPath},Success,");
                    }
                    catch (NotSupportedException)
                    {
                        // Log format not supported exception
                        reportWriter.WriteLine($"{inputPath},{outputPath},Failed,Format not supported (NotSupportedException)");
                    }
                    catch (Exception ex)
                    {
                        // Log any other failure
                        reportWriter.WriteLine($"{inputPath},{outputPath},Failed,{ex.Message}");
                    }
                }
            }

            // Indicate completion
            Console.WriteLine("Batch conversion completed. Report saved to " + reportPath);
        }
    }
}