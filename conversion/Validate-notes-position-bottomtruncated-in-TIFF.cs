// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate notes position bottomtruncated in TIFF using C#

//

// Description:

// Demonstrates how to validate notes position bottomtruncated in TIFF using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, TIFF, Aspose.Slides for .NET, Validate, Notes, Position, 

// Bottomtruncated, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validation of notes position bottomtruncated when converting to TIFF.

// - Build C# tools for PowerPoint presentation processing and image export.

// - Generate or transform PPTX files to TIFF with specific notes layout in .NET applications.

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

            using (Presentation pres = new Presentation(inputPath))

            {

                // Configure TIFF options with notes layout set to BottomTruncated

                TiffOptions tiffOptions = new TiffOptions();

                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();

                notesOptions.NotesPosition = NotesPositions.BottomTruncated;

                tiffOptions.SlidesLayoutOptions = notesOptions;



                // Save the presentation as TIFF using the configured options

                pres.Save(outputPath, SaveFormat.Tiff, tiffOptions);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URL or web service errors)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

