// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slide notes from a PPTX to a consolidated PDF using C#

//

// Description:

// Demonstrates how to extract notes from each slide of a PPTX file, place

// each note onto a separate slide in a new presentation, and then export the

// resulting notes presentation to PDF using Aspose.Slides for .NET. The example

// includes file existence checks, error handling, and shows how to work with

// NotesSlideManager, INotesSlide, and IAutoShape objects in a console

// application.

//

// Keywords:

// C#, Aspose.Slides, PPTX, slide notes, PDF export, presentation processing,

// PowerPoint automation, .NET, INotesSlide, IAutoShape

//

// Use Cases:

// - Generate a PDF document containing all slide notes from a PowerPoint file.

// - Create reporting or documentation from presentation notes.

// - Automate extraction of presenter notes for review or publishing.

// - Integrate notes extraction into larger .NET workflows or services.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExtractNotesToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPdfPath = "Notes.pdf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the source presentation

                using (Presentation sourcePres = new Presentation(inputPath))

                {

                    // Create a new presentation to hold consolidated notes

                    using (Presentation notesPres = new Presentation())

                    {

                        // Iterate through each slide in the source presentation

                        for (int i = 0; i < sourcePres.Slides.Count; i++)

                        {

                            ISlide sourceSlide = sourcePres.Slides[i];

                            INotesSlide notesSlide = null;



                            // Retrieve notes slide if it exists

                            if (sourceSlide.NotesSlideManager.NotesSlide != null)

                            {

                                notesSlide = sourceSlide.NotesSlideManager.NotesSlide;

                            }



                            // Continue only if notes text is available

                            if (notesSlide != null && notesSlide.NotesTextFrame != null)

                            {

                                string notesText = notesSlide.NotesTextFrame.Text;



                                // Add a new empty slide to the notes presentation

                                ISlide newSlide = notesPres.Slides.AddEmptySlide(notesPres.Slides[0].LayoutSlide);



                                // Add a textbox shape containing the notes text

                                IAutoShape textBox = (IAutoShape)newSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 400);

                                textBox.AddTextFrame(notesText);

                            }

                        }



                        // Save the consolidated notes as PDF

                        notesPres.Save(outputPdfPath, SaveFormat.Pdf);

                    }



                    // Save the source presentation before exiting (no modifications made)

                    sourcePres.Save("temp_save.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

