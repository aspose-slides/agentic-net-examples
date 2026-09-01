// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX files to individual PDFs using C#

//

// Description:

// Demonstrates how to convert PPTX files to individual PDFs using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Pptx, Files, 

// Individual, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate convert PPTX files to individual PDFs.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertPptxToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine the input folder: from args or current directory

            string inputFolder;

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

            {

                inputFolder = args[0];

            }

            else

            {

                inputFolder = Directory.GetCurrentDirectory();

            }



            // Verify that the folder exists

            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input folder does not exist: " + inputFolder);

                return;

            }



            // Get all PPTX files in the folder

            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");



            // Convert each PPTX to PDF

            foreach (string pptxPath in pptxFiles)

            {

                try

                {

                    // Load the presentation

                    Presentation pres = new Presentation(pptxPath);



                    // Build the output PDF path

                    string pdfPath = Path.Combine(inputFolder, Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");



                    // Save the presentation as PDF

                    pres.Save(pdfPath, SaveFormat.Pdf);



                    // Release resources

                    pres.Dispose();



                    Console.WriteLine("Converted: " + pptxPath + " -> " + pdfPath);

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine("File format not supported for file: " + pptxPath);

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine("Error processing file: " + pptxPath);

                    Console.WriteLine(ex.Message);

                }

            }

        }

    }

}

