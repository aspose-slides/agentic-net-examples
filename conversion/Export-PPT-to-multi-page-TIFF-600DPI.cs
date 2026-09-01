// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPT to multi page TIFF 600DPI using C#

//

// Description:

// Demonstrates how to export a PowerPoint presentation (PPTX) to a multi‑page

// TIFF image with a resolution of 600 DPI using C# and Aspose.Slides for .NET.

// The example loads a presentation, configures high‑resolution TIFF options,

// and saves the result as a multi‑page TIFF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Multi‑page, TIFF, 600 DPI,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert presentations to high‑resolution multi‑page TIFF for printing.

// - Automate batch conversion of PPTX files to TIFF in .NET applications.

// - Integrate presentation export functionality into custom tools or services.

// - Validate and test PPTX to TIFF conversion workflows.

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

        string outputPath = "output.tiff";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Configure TIFF options with 600 DPI for high‑resolution printing

            TiffOptions tiffOptions = new TiffOptions();

            tiffOptions.DpiX = 600;

            tiffOptions.DpiY = 600;



            // Export the presentation to a multi‑page TIFF file

            presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);



            // Release resources

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

