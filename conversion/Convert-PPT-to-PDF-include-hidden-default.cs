// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to PDF include hidden default using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a PDF file

// while preserving hidden slides using C# and Aspose.Slides for .NET. The example

// shows the required steps to load a presentation, configure PDF options to

// include hidden slides, and save the output as a PDF document in a standalone

// console application. Developers can use this pattern to automate PPTX to PDF

// workflows, ensure hidden content is retained, or integrate presentation

// processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, PDF, Convert, Include,

// Hidden, Default, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF while preserving hidden slides.

// - Build C# tools for PowerPoint presentation processing with hidden content.

// - Generate or transform PPTX files into PDF in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



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

                pdfOptions.ShowHiddenSlides = true; // preserve hidden slides



                // Save the presentation as PDF with the specified options

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

