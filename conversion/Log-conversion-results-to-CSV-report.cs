// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log conversion results to CSV report using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint and other supported presentation

// files to PDF and log the conversion results into a CSV report using C# and

// Aspose.Slides for .NET. The example processes all supported files in a given

// directory, creates PDFs, and records success or failure details.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, CSV, Conversion Report,

// Batch Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of presentations to PDF with result logging.

// - Generate CSV reports for auditing conversion outcomes.

// - Build .NET tools for PowerPoint file processing and validation.

// - Integrate presentation conversion workflows into larger applications.

// -----------------------------------------------------------------------------

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

                            pres.Save(__outputPath__, SaveFormat.Pdf);



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

