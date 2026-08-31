// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add speaker notes from external data using C#

//

// Description:

// Demonstrates how to read speaker notes from an external text file and add

// them to each slide of a PowerPoint presentation using Aspose.Slides for .NET.

// The example loads an existing PPTX, creates a notes slide for every slide,

// assigns the corresponding line from the text file as the speaker note, and

// saves the result as a new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Speaker, Notes, External, Data,

// Text File, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the import of speaker notes from external sources.

// - Build .NET tools that enrich existing presentations with notes.

// - Generate or modify PPTX files programmatically in batch processes.

// - Validate and preview presentation content before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AddSpeakerNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation and external notes file paths

            string presentationPath = "input.pptx";

            string notesFilePath = "notes.txt";

            string outputPath = "output.pptx";



            // Verify that the input files exist

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            if (!File.Exists(notesFilePath))

            {

                Console.WriteLine("Notes file not found: " + notesFilePath);

                return;

            }



            // Read all notes (one line per slide)

            string[] notesLines = File.ReadAllLines(notesFilePath);



            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))

            {

                int slideCount = presentation.Slides.Count;



                // Add speaker notes to each slide

                for (int index = 0; index < slideCount; index++)

                {

                    INotesSlideManager notesManager = presentation.Slides[index].NotesSlideManager;

                    INotesSlide notesSlide = notesManager.AddNotesSlide();



                    // Use the corresponding line from the notes file if available

                    string noteText = index < notesLines.Length ? notesLines[index] : string.Empty;

                    notesSlide.NotesTextFrame.Text = noteText;

                }



                // Save the presentation and handle unsupported format exceptions

                try

                {

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

                catch (Aspose.Slides.PptxUnsupportedFormatException)

                {

                    // Format not supported for saving

                    Console.WriteLine("The presentation format is not supported for saving as PPTX.");

                }

                catch (Aspose.Slides.PptUnsupportedFormatException)

                {

                    // Format not supported for saving

                    Console.WriteLine("The presentation format is not supported for saving as PPT.");

                }

            }

        }

    }

}

