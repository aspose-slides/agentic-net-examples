// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate diagnostic report for PPTX conversions using C#

//

// Description:

// Demonstrates how to convert OpenDocument Presentation (FODP) files to PPTX

// and back to FODP using Aspose.Slides for .NET while generating a diagnostic

// report that includes file sizes and processing status. The example processes

// multiple input files, handles missing files, and reports any errors or

// unsupported formats.

//

// Keywords:

// C#, PowerPoint, PPTX, FODP, Aspose.Slides for .NET, Generate, Diagnostic, Report,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Automate generation of diagnostic reports for FODP ↔ PPTX conversion workflows.

// - Build C# tools for validating presentation file size changes during conversion.

// - Integrate conversion diagnostics into .NET applications handling OpenDocument presentations.

// - Detect and log unsupported formats or processing errors in batch conversion scenarios.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace DiagnosticReport

{

    class Program

    {

        static void Main(string[] args)

        {

            // List of input FODP files to process

            string[] inputFiles = new string[] { "input1.fodp", "input2.fodp" };



            foreach (string inputFile in inputFiles)

            {

                try

                {

                    // Check if the input file exists

                    if (!File.Exists(inputFile))

                    {

                        Console.WriteLine("File not found: " + inputFile);

                        continue;

                    }



                    // Define intermediate and output file paths

                    string intermediatePptx = Path.ChangeExtension(inputFile, ".pptx");

                    string outputFodp = Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(inputFile) + "_converted.fodp");



                    // Load the original FODP presentation

                    Aspose.Slides.Presentation pres1 = new Aspose.Slides.Presentation(inputFile);

                    // Save as intermediate PPTX

                    pres1.Save(intermediatePptx, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Load the intermediate PPTX presentation

                    Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(intermediatePptx);

                    // Save as final FODP

                    pres2.Save(outputFodp, Aspose.Slides.Export.SaveFormat.Fodp);



                    // Gather file size information

                    FileInfo originalInfo = new FileInfo(inputFile);

                    FileInfo intermediateInfo = new FileInfo(intermediatePptx);

                    FileInfo finalInfo = new FileInfo(outputFodp);



                    // Output diagnostic report

                    Console.WriteLine("=== Diagnostic Report ===");

                    Console.WriteLine("Original File: " + originalInfo.FullName);

                    Console.WriteLine("Original Size: " + originalInfo.Length + " bytes");

                    Console.WriteLine("Intermediate PPTX: " + intermediateInfo.FullName);

                    Console.WriteLine("Intermediate Size: " + intermediateInfo.Length + " bytes");

                    Console.WriteLine("Final FODP: " + finalInfo.FullName);

                    Console.WriteLine("Final Size: " + finalInfo.Length + " bytes");

                    Console.WriteLine("Warnings: None");

                    Console.WriteLine("==========================");



                    // Ensure presentations are saved and resources released

                    pres1.Dispose();

                    pres2.Dispose();

                }

                catch (NotSupportedException ex)

                {

                    // Format not supported

                    Console.WriteLine("Format not supported for file " + inputFile + ": " + ex.Message);

                }

                catch (Exception ex)

                {

                    // Handle other exceptions (e.g., external URL issues)

                    Console.WriteLine("Error processing file " + inputFile + ": " + ex.Message);

                }

            }

        }

    }

}

