// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create TIFF from PPT no notes LZW using C#

//

// Description:

// Demonstrates how to create a multi‑page TIFF image from a PowerPoint

// presentation without including slide notes, using LZW compression, with

// Aspose.Slides for .NET. The example loads a PPTX file, configures TIFF

// export options, and saves the result as a TIFF file in a console

// application. This pattern can be used to automate PPTX to TIFF conversion

// workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, LZW, No Notes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of multi‑page TIFF from PPTX without notes using LZW.

// - Build .NET tools for PowerPoint to image conversion.

// - Generate TIFF assets for publishing or archival purposes.

// - Validate presentation conversion processes in CI pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input PPTX file path

        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

        // Output multi‑page TIFF file path

        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.tiff");



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure TIFF options with LZW compression (default)

            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

            tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;



            // Save all slides (notes are excluded by default) as a multi‑page TIFF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);



            // Release resources

            presentation.Dispose();



            Console.WriteLine("TIFF created successfully at: " + outputPath);

        }

        catch (NotSupportedException)

        {

            // Handle unsupported format

            Console.WriteLine("The provided file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

