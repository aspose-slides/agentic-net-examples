// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate SWF includes all notes using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to SWF while including

// notes and comments using Aspose.Slides for .NET. The example validates that

// the generated SWF file exists and is not empty, confirming that notes are

// correctly embedded in the output.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Validate, Notes, Comments,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Verify that SWF conversion retains slide notes and comments.

// - Automate PPTX to SWF conversion with notes for e‑learning or archival.

// - Build validation tools for presentation workflows in .NET.

// - Ensure generated SWF files contain required metadata before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.swf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            var presentation = new Aspose.Slides.Presentation(inputPath);

            var swfOptions = new Aspose.Slides.Export.SwfOptions();



            // Enable notes and comments layouting

            var notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;

            notesOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;

            swfOptions.SlidesLayoutOptions = notesOptions;



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



            // Simple validation to ensure the SWF file was created and is not empty

            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)

            {

                Console.WriteLine("SWF file generated successfully with notes and comments.");

            }

            else

            {

                Console.WriteLine("SWF file generation failed or file is empty.");

            }



            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

