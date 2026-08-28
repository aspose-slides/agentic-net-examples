// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PDF with bookmarks using C#

//

// Description:

// Demonstrates how to export a PowerPoint PPTX file to a PDF document while

// preserving slide titles as PDF bookmarks using Aspose.Slides for .NET. The

// example loads a presentation, configures PDF export options, and saves the

// result, handling missing input files and potential errors.

//

// Keywords:

// C#, Aspose.Slides, PPTX, PDF, Export, Bookmarks, Presentation, PowerPoint,

// Automation, .NET

//

// Use Cases:

// - Convert PowerPoint presentations to PDF with navigable bookmarks.

// - Integrate PPTX to PDF conversion into C# applications or services.

// - Automate document generation workflows that require PDF bookmarks.

// - Validate and process presentations before distribution.

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

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Create PDF export options (Aspose.Slides automatically generates bookmarks from slide titles)

            PdfOptions pdfOptions = new PdfOptions();



            // Export to PDF with the specified options

            presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);



            // Ensure the presentation is saved before exiting

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Handle unsupported file format

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

