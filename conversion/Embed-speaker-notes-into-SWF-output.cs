// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed speaker notes into SWF output using C#

//

// Description:

// Demonstrates how to embed speaker notes into SWF output using C# and 

// Aspose.Slides for .NET. The example loads a PPTX file, adds speaker notes to 

// the first slide, configures SWF export options to place notes at the bottom 

// of each slide, and saves the presentation as an SWF file with embedded notes. 

// It also saves a copy of the modified presentation as PPTX.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Embed, Speaker, Notes, 

// Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate embedding speaker notes into SWF output for e‑learning platforms.

// - Build C# utilities for converting PPTX to SWF with notes preservation.

// - Integrate PowerPoint to SWF conversion into .NET applications.

// - Validate and preview presentation content before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class CustomNotesLayoutOptions : NotesCommentsLayoutingOptions

{

    // Custom implementation can be extended here if needed.

}



class Program

{

    static void Main()

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

            using (Presentation pres = new Presentation(inputPath))

            {

                // Add speaker notes to the first slide

                INotesSlideManager notesManager = pres.Slides[0].NotesSlideManager;

                INotesSlide notesSlide = notesManager.AddNotesSlide();

                notesSlide.NotesTextFrame.Text = "Speaker notes for slide 1.";



                // Configure SWF export options with custom notes layout

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.SlidesLayoutOptions = new CustomNotesLayoutOptions();

                ((NotesCommentsLayoutingOptions)swfOptions.SlidesLayoutOptions).NotesPosition = NotesPositions.BottomFull;



                // Save the presentation as SWF with embedded notes

                pres.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Save the presentation before exiting (as PPTX)

                pres.Save("saved_before_exit.pptx", SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

            // Format not supported comment

            // The provided file format may not be supported by Aspose.Slides.

        }

    }

}

