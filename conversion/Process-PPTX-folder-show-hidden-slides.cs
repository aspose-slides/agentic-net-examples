// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Process PPTX folder show hidden slides using C#

//

// Description:

// Demonstrates how to process a folder of PPTX files, converting each presentation

// to PDF while including hidden slides using C# and Aspose.Slides for .NET.

// The example iterates over all *.pptx files in a specified directory (or the

// current working directory if none is provided), loads each presentation,

// configures PDF export options to show hidden slides, and saves the result as

// a PDF file with the same base name. This pattern can be used to automate batch

// conversion of PowerPoint files while preserving hidden content.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Process, Folder, Show Hidden Slides,

// PDF conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPTX files to PDF including hidden slides.

// - Build C# tools for PowerPoint presentation processing in .NET environments.

// - Generate PDFs from presentations while retaining hidden content for review.

// - Validate and archive PowerPoint files with hidden slides preserved.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ProcessPptx

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine the directory to process

            string inputDirectory;

            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

            {

                inputDirectory = args[0];

            }

            else

            {

                inputDirectory = Directory.GetCurrentDirectory();

            }



            // Verify that the directory exists

            if (!Directory.Exists(inputDirectory))

            {

                Console.WriteLine("The specified directory does not exist: " + inputDirectory);

                return;

            }



            // Get all PPTX files in the directory

            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");



            foreach (string pptxPath in pptxFiles)

            {

                try

                {

                    // Load the presentation

                    using (Presentation presentation = new Presentation(pptxPath))

                    {

                        // Set PDF options to include hidden slides

                        PdfOptions pdfOptions = new PdfOptions();

                        pdfOptions.ShowHiddenSlides = true;



                        // Determine output PDF path

                        string outputPdfPath = Path.Combine(

                            inputDirectory,

                            Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");



                        // Save as PDF with hidden slides included

                        presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);

                    }



                    Console.WriteLine("Converted: " + pptxPath);

                }

                catch (Exception ex)

                {

                    // Handle unsupported format or other errors

                    Console.WriteLine("Failed to process file: " + pptxPath);

                    Console.WriteLine("Error: " + ex.Message);

                }

            }

        }

    }

}

