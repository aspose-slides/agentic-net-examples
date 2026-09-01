// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export ODP slides to PDF range using C#

//

// Description:

// Demonstrates how to export a range of slides from an ODP presentation to a

// PDF file using Aspose.Slides for .NET. The example loads an ODP file,

// selects specific slide indices, and saves those slides as a PDF document.

// This pattern can be used to automate slide extraction, create custom PDFs,

// or integrate ODP processing into .NET applications.

//

// Keywords:

// C#, ODP, PDF, Aspose.Slides for .NET, Export, Slides, Range, Presentation

// Processing, Office Automation

//

// Use Cases:

// - Automate export of selected ODP slides to PDF.

// - Build C# utilities for ODP to PDF conversion with slide selection.

// - Generate PDFs from specific slides in presentation workflows.

// - Validate and test slide extraction before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportSelectedSlides

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input ODP file path

            string inputPath = "input.odp";

            // Output PDF file path

            string outputPath = "selected_slides.pdf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the ODP presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Define slide indices to export (2 through 5). Indices are 1‑based.

                    int[] slideIndices = new int[] { 2, 3, 4, 5 };



                    // Save the selected slides as PDF

                    presentation.Save(outputPath, slideIndices, SaveFormat.Pdf);

                }



                Console.WriteLine("Selected slides exported successfully to: " + outputPath);

            }

            catch (InvalidOperationException)

            {

                // Format not supported for the requested operation

                Console.WriteLine("The specified format is not supported for exporting selected slides.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors, permission issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

