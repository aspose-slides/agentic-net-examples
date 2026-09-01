// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure notes position none and export TIFF using C#

//

// Description:

// Demonstrates how to configure notes position none and export TIFF using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Notes, Position, 

// None, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate configure notes position none and export TIFF.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesTiffExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define data directory

            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");

            if (!Directory.Exists(dataDir))

            {

                Directory.CreateDirectory(dataDir);

            }



            // Input and output file paths

            string inputPath = Path.Combine(dataDir, "input.pptx");

            string outputPath = Path.Combine(dataDir, "output.tiff");



            // Check if input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            // Load presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Configure TIFF options to exclude notes

                TiffOptions options = new TiffOptions();

                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();

                notesOptions.NotesPosition = NotesPositions.None; // Exclude notes

                options.SlidesLayoutOptions = notesOptions;



                try

                {

                    // Save presentation as TIFF without notes

                    pres.Save(outputPath, SaveFormat.Tiff, options);

                }

                catch (Exception ex)

                {

                    // Handle format not supported or other saving errors

                    // Format not supported

                    Console.WriteLine("Error saving TIFF: " + ex.Message);

                }

            }



            // Presentation saved before exit

            Console.WriteLine("TIFF image generated at: " + outputPath);

        }

    }

}

