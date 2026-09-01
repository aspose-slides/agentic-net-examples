// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch summarize total size reduction using C#

//

// Description:

// Demonstrates how to batch summarize total size reduction using C# and 

// Aspose.Slides for .NET. The example processes a folder of PowerPoint files,

// converts each presentation to PDF, and calculates the total size reduction

// achieved by the conversion. It outputs a summary report with original size,

// converted size, and reduction percentage.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Batch, Summarize, Total, Size, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of presentations to PDF and evaluate storage savings.

// - Build C# tools for PowerPoint presentation processing and reporting.

// - Generate or transform PPTX files in .NET applications while tracking size impact.

// - Validate presentation workflows before publishing or integration.

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

            // Input directory containing presentations

            string inputDirectory = args.Length > 0 ? args[0] : "InputPresentations";

            // Output directory for converted files

            string outputDirectory = args.Length > 1 ? args[1] : "ConvertedPresentations";



            if (!Directory.Exists(inputDirectory))

            {

                Console.WriteLine("Input directory does not exist: " + inputDirectory);

                return;

            }



            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            string[] supportedExtensions = new string[] { ".pptx", ".ppt", ".odp", ".pptm", ".ppsx", ".potx" };

            long totalOriginalSize = 0;

            long totalConvertedSize = 0;



            foreach (string filePath in Directory.GetFiles(inputDirectory))

            {

                string extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (Array.IndexOf(supportedExtensions, extension) < 0)

                {

                    // Skip unsupported file types

                    continue;

                }



                if (!File.Exists(filePath))

                {

                    // File existence already checked by GetFiles, but keep for safety

                    continue;

                }



                try

                {

                    // Load presentation

                    using (Presentation presentation = new Presentation(filePath))

                    {

                        // Record original size

                        FileInfo originalInfo = new FileInfo(filePath);

                        totalOriginalSize += originalInfo.Length;



                        // Prepare output file path (convert to PDF)

                        string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";

                        string outputPath = Path.Combine(outputDirectory, outputFileName);



                        // Convert and save without additional options

                        presentation.Save(outputPath, SaveFormat.Pdf);



                        // Record converted size

                        FileInfo convertedInfo = new FileInfo(outputPath);

                        totalConvertedSize += convertedInfo.Length;

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported – skip this file

                }

                catch (Exception ex)

                {

                    // Handle other unexpected exceptions (e.g., file access issues)

                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);

                }

            }



            // Generate summary report

            long sizeReduction = totalOriginalSize - totalConvertedSize;

            double reductionPercentage = totalOriginalSize > 0 ? (sizeReduction * 100.0 / totalOriginalSize) : 0.0;



            Console.WriteLine("Batch Conversion Summary:");

            Console.WriteLine("Total original size (bytes): " + totalOriginalSize);

            Console.WriteLine("Total converted size (bytes): " + totalConvertedSize);

            Console.WriteLine("Total size reduction (bytes): " + sizeReduction);

            Console.WriteLine("Overall reduction (%): " + reductionPercentage.ToString("F2"));

        }

    }

}

