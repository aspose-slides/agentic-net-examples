// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to TIFF 150DPI using C#

//

// Description:

// Demonstrates how to export a PPTX file to a multi‑page TIFF image with a

// resolution of 150 DPI using C# and Aspose.Slides for .NET. The example loads a

// presentation, configures TIFF export options, and saves the result to disk.

// This pattern can be used in console utilities or automated workflows that

// require high‑resolution image output from PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, TIFF, 150DPI, Presentation

// Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to high‑resolution TIFF images.

// - Build batch conversion tools for archival or printing purposes.

// - Integrate PPTX‑to‑TIFF conversion into .NET applications or services.

// - Validate presentation rendering at a specific DPI before publishing.

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

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Configure TIFF options with custom DPI

            TiffOptions options = new TiffOptions();

            options.DpiX = 150;

            options.DpiY = 150;



            // Save the presentation as TIFF using the specified options

            presentation.Save(outputPath, SaveFormat.Tiff, options);



            // Ensure the presentation is saved before exiting

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

