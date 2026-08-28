// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set notes position bottomfull and export TIFF using C#

//

// Description:

// Demonstrates how to set notes position bottomfull and export TIFF using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Notes, Position, Bottomfull, 

// Export, TIFF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate set notes position bottomfull and export TIFF.

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

    static void Main(string[] args)

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.tiff";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file not found: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Configure TIFF export options with notes positioned at the bottom (full)

            TiffOptions tiffOptions = new TiffOptions();

            NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();

            notesOptions.NotesPosition = NotesPositions.BottomFull;

            tiffOptions.SlidesLayoutOptions = notesOptions;



            // Save the presentation as TIFF with the specified options

            presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);



            // Dispose the presentation object

            presentation.Dispose();



            Console.WriteLine("Presentation successfully saved as TIFF: " + outputPath);

        }

        catch (NotSupportedException ex)

        {

            // Handle unsupported file format

            Console.WriteLine("The file format is not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

