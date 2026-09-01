// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF quick default using C#

//

// Description:

// Demonstrates how to convert a PPTX file to PDF using the default settings

// with Aspose.Slides for .NET. The example loads a presentation, saves it as

// PDF, and handles basic error conditions in a console application.

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Convert, Quick, Default,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF with default options.

// - Build command‑line tools for PowerPoint to PDF transformation.

// - Integrate simple PDF export functionality into .NET applications.

// - Validate PPTX files before distribution by generating PDFs.

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



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Presentation pres = new Presentation(inputPath);



            // Convert to PDF using default settings

            pres.Save(outputPath, SaveFormat.Pdf);



            // Release resources

            pres.Dispose();



            Console.WriteLine("Conversion completed successfully.");

        }

        catch (NotSupportedException)

        {

            // Handle unsupported format

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

