// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure fallback fonts and export to PDF using C#

//

// Description:

// Demonstrates how to configure fallback fonts for loading a PowerPoint

// presentation and for PDF export using Aspose.Slides for .NET. The example

// loads a PPTX file, applies a default regular font as a fallback, and saves

// the presentation as a PDF document. This pattern is useful for handling

// missing fonts in source files and ensuring consistent rendering.

//

// Keywords:

// C#, Aspose.Slides, PDF, Fallback Fonts, PowerPoint, PPTX, Export, Presentation

// Processing, .NET

//

// Use Cases:

// - Apply fallback fonts when loading presentations with missing fonts.

// - Export PowerPoint files to PDF while preserving text layout.

// - Build automation tools for batch conversion of PPTX to PDF.

// - Ensure consistent font rendering across different environments.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Configure load options with a fallback font

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.DefaultRegularFont = "Arial";



            // Load the presentation using the configured load options

            using (Presentation presentation = new Presentation(inputPath, loadOptions))

            {

                // Configure PDF export options with the same fallback font

                PdfOptions pdfOptions = new PdfOptions();

                pdfOptions.DefaultRegularFont = "Arial";



                // Save the presentation as PDF

                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (Exception ex)

        {

            // If the format is not supported, handle accordingly (commented for clarity)

            // Format not supported.

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

