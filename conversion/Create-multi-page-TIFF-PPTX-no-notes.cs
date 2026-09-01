// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create multi-page TIFF from PPTX without notes using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a multi‑page

// TIFF image while excluding slide notes, using Aspose.Slides for .NET. The

// example loads a PPTX file, configures TiffOptions with default settings,

// and saves the result as a multi‑page TIFF file. This pattern can be used in

// console applications or automated workflows that require image export of

// presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, TIFF, Aspose.Slides for .NET, Multi‑page TIFF, No notes,

// Presentation conversion, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to multi‑page TIFF images for archiving.

// - Generate image versions of slides without including speaker notes.

// - Build .NET tools for batch processing of PowerPoint files.

// - Integrate PPTX‑to‑TIFF conversion into document management systems.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.tiff";



        // Verify that the input PPTX file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation from the specified file

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create TiffOptions with default settings (default compression, no notes)

            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();



            // Save the presentation as a multi‑page TIFF file

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);



            // Release resources used by the presentation

            presentation.Dispose();



            Console.WriteLine("TIFF file created successfully at: " + outputPath);

        }

        catch (NotSupportedException ex)

        {

            // Handle case where the format is not supported

            Console.WriteLine("Format not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

