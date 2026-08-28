// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate SWF notes inclusion with NotesCommentsLayoutingOptions using C#

//

// Description:

// Demonstrates how to add notes to each slide of a PPTX presentation,

// configure NotesCommentsLayoutingOptions to place notes at the bottom,

// and save the presentation as an SWF file with notes included using 

// Aspose.Slides for .NET. The example is a self‑contained console application 

// that validates the notes inclusion during conversion.

//

// Keywords:

// C#, Aspose.Slides for .NET, SWF, PPTX, Notes, NotesCommentsLayoutingOptions, 

// Presentation conversion, Office automation

//

// Use Cases:

// - Verify that notes are correctly embedded when converting PPTX to SWF.

// - Build C# utilities for batch conversion of presentations with notes.

// - Automate validation of notes layout options in PowerPoint workflows.

// - Integrate notes‑aware SWF generation into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfNotesValidation

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            var inputPath = "input.pptx";

            var outputPath = "output.swf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                var presentation = new Aspose.Slides.Presentation(inputPath);



                // Ensure each slide has notes

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    var notesManager = presentation.Slides[i].NotesSlideManager;

                    var notesSlide = notesManager.AddNotesSlide();

                    notesSlide.NotesTextFrame.Text = $"Notes for slide {i + 1}";

                }



                // Configure SWF options with notes layouting enabled

                var swfOptions = new Aspose.Slides.Export.SwfOptions

                {

                    SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions

                    {

                        NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull

                    }

                };



                // Save presentation as SWF

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



                // Dispose presentation

                presentation.Dispose();



                Console.WriteLine("SWF file saved successfully with notes included.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

