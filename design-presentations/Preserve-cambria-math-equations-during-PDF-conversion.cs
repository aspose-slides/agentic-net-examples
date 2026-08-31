// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Preserve cambria math equations during PDF conversion using C#

//

// Description:

// Demonstrates how to preserve Cambria Math equations when converting a PowerPoint

// presentation to PDF using C# and Aspose.Slides for .NET. The example loads a PPTX

// file, configures PDF export options to retain the Cambria Math font, and saves the

// result as a PDF document. This pattern can be used to ensure mathematical content

// remains editable and correctly rendered in the generated PDF.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Preserve, Cambria, Math,

// Equations, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate preservation of Cambria Math equations during PDF conversion.

// - Build C# utilities for processing PowerPoint presentations with mathematical content.

// - Generate PDF outputs from PPTX files while maintaining equation fidelity.

// - Integrate reliable presentation-to-PDF workflows into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PreserveCambriaMath

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Set PDF options to preserve Cambria Math equations

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.DefaultRegularFont = "Cambria Math";

                    pdfOptions.RasterizeUnsupportedFontStyles = false;



                    // Save the presentation as PDF

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

