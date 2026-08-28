// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slide comments to SWF using C#

//

// Description:

// Demonstrates how to export slide comments to a SWF file using C# and

// Aspose.Slides for .NET. The example loads a PPTX presentation, configures

// comment layout options, and saves the result as a SWF document containing

// the comments positioned on the right side of each slide.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide, Comments, SWF,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate exporting slide comments to SWF for web preview.

// - Build C# utilities for PowerPoint comment extraction and conversion.

// - Integrate comment-aware SWF generation into .NET applications.

// - Validate presentation comment layouts before publishing.

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

        string outputPath = "output.swf";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create SWF options and assign NotesCommentsLayoutingOptions

            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

            notesOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;

            swfOptions.SlidesLayoutOptions = notesOptions;



            // Save the presentation as SWF with comments layout

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle format not supported or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

