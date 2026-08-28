// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPTX as PDF 90percent quality using C#

//

// Description:

// Demonstrates how to save a PPTX file as a PDF with 90% JPEG image quality 

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint 

// presentation, configures PDF export options to set JPEG quality to 90%, and 

// saves the result as a PDF file. This pattern can be used in console 

// applications to automate presentation conversion workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Save, Pptx, 90Percent, 

// Quality, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to PDF with controlled image quality.

// - Build C# utilities for batch processing of PowerPoint files.

// - Integrate PDF export with specific JPEG quality settings into .NET apps.

// - Ensure consistent visual fidelity while reducing PDF file size.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pdf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Configure PDF options with reduced JPEG quality

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                pdfOptions.JpegQuality = 90; // Set image quality to 90%



                // Save the presentation as PDF with the specified options

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

