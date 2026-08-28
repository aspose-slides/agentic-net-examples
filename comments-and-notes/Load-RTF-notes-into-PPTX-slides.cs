// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load RTF notes into PPTX slides using C#

//

// Description:

// Demonstrates how to read an RTF file containing slide notes and embed the

// same notes into every slide of an existing PPTX presentation using

// Aspose.Slides for .NET. The example loads a presentation, reads the RTF

// content, creates a notes slide for each slide, assigns the RTF text to the

// notes text frame, and saves the result as a new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, RTF, Aspose.Slides for .NET, Load, Notes, Slides,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate the insertion of RTF‑based speaker notes into PowerPoint decks.

// - Build .NET utilities that enrich existing presentations with standardized

//   notes content.

// - Convert external RTF note collections into PPTX notes for distribution.

// - Validate and test notes‑embedding workflows before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlidesNotesEmbedding

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define paths

            string dataDir = "Data";

            string presentationPath = Path.Combine(dataDir, "input.pptx");

            string rtfPath = Path.Combine(dataDir, "notes.rtf");

            string outputPath = Path.Combine(dataDir, "output.pptx");



            // Verify input files exist

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            if (!File.Exists(rtfPath))

            {

                Console.WriteLine("RTF notes file not found: " + rtfPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(presentationPath))

                {

                    // Read RTF content

                    string rtfContent = File.ReadAllText(rtfPath);



                    // Embed notes into each slide

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;

                        INotesSlide notesSlide = notesManager.AddNotesSlide();

                        notesSlide.NotesTextFrame.Text = rtfContent;

                    }



                    // Save the updated presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment: // The file format may not be supported by Aspose.Slides

            }

        }

    }

}

