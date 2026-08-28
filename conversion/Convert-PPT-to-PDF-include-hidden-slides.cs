// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to PDF include hidden slides using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a PDF file

// while including hidden slides using C# and Aspose.Slides for .NET. The example

// loads a presentation, configures PDF export options to show hidden slides,

// and saves the result as a PDF document. This pattern can be used in console

// applications or integrated into larger .NET solutions for automated

// presentation processing.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Convert, Include, Hidden,

// Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF while preserving hidden slides.

// - Build C# utilities for PowerPoint presentation export and archiving.

// - Integrate hidden-slide-aware PDF generation into .NET applications.

// - Validate and preview presentation content before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertPptToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Set PDF options to include hidden slides

                PdfOptions pdfOptions = new PdfOptions();

                pdfOptions.ShowHiddenSlides = true;



                // Save the presentation as PDF with the specified options

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (Exception ex)

            {

                // Handle exceptions (e.g., unsupported format)

                Console.WriteLine("An error occurred during conversion: " + ex.Message);

                // Format not supported comment

                // The provided file format may not be supported by Aspose.Slides.

            }

        }

    }

}

