// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert selected slides of a PowerPoint presentation to PDF using C#

//

// Description:

// Demonstrates how to load a PowerPoint file, select specific slide indices 

// (1‑based), and save only those slides as a PDF document using Aspose.Slides 

// for .NET. The example accepts an optional input file path via command‑line 

// arguments, falls back to "input.pptx" when not provided, and writes the PDF 

// with the same name but a .pdf extension. This pattern is useful for 

// automating slide‑level export scenarios in console applications.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, PDF, Convert, Selected Slides, 

// Presentation Export, Console Application, Office Automation

//

// Use Cases:

// - Export only chosen slides from a PPTX to a PDF file.

// - Build command‑line utilities for slide‑specific PDF generation.

// - Integrate selective slide conversion into larger .NET workflows.

// - Automate reporting or documentation tasks that require only part of a deck.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertSelectedSlidesToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input file path

            var inputPath = args.Length > 0 && !string.IsNullOrEmpty(args[0]) ? args[0] : "input.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            // Determine output file path

            var outputPath = Path.ChangeExtension(inputPath, ".pdf");



            try

            {

                // Load presentation

                using (var presentation = new Presentation(inputPath))

                {

                    // Specify slides to include (1-based indices)

                    var slides = new int[] { 1, 3, 5 };



                    // Save selected slides as PDF

                    presentation.Save(outputPath, slides, SaveFormat.Pdf);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine($"Error: {ex.Message}");

            }

        }

    }

}

