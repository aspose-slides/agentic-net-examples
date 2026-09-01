// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to TIFF LZW notes using C#

//

// Description:

// Demonstrates how to export a PPTX file to a multi-page TIFF image with LZW

// compression while including slide notes at the bottom of each page using

// Aspose.Slides for .NET. The example loads a presentation, configures TIFF

// export options, adds notes layouting, and saves the result as a TIFF file.

// This pattern can be used in console applications or automated workflows.

//

// Keywords:

// C#, Aspose.Slides, PPTX, TIFF, LZW compression, slide notes, export, .NET,

// presentation processing, console app

//

// Use Cases:

// - Convert PowerPoint presentations to high‑quality TIFF files with notes.

// - Automate generation of printable or archival TIFF documents from PPTX.

// - Integrate slide‑notes extraction into .NET tools or services.

// - Create batch conversion utilities for PowerPoint to TIFF with LZW compression.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToTiff

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");



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



                // Configure TIFF export options

                TiffOptions tiffOptions = new TiffOptions();

                tiffOptions.CompressionType = TiffCompressionTypes.LZW; // Use LZW compression



                // Include slide notes as separate image layers

                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();

                notesOptions.NotesPosition = NotesPositions.BottomFull;

                tiffOptions.SlidesLayoutOptions = notesOptions;



                // Save the presentation as TIFF

                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation exported to TIFF successfully.");

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

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

