// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to TIFF with notes using C#

//

// Description:

// Demonstrates how to export PPTX to TIFF with notes using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Tiff, Notes, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export PPTX to TIFF with notes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

            using (Presentation pres = new Presentation(inputPath))

            {

                // Configure TIFF options with notes embedded

                TiffOptions options = new TiffOptions();

                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();

                notesOptions.NotesPosition = NotesPositions.BottomFull;

                options.SlidesLayoutOptions = notesOptions;



                // Save the presentation as TIFF

                pres.Save(outputPath, SaveFormat.Tiff, options);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

