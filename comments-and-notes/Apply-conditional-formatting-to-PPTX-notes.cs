// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply conditional formatting to PPTX notes using C#

//

// Description:

// Demonstrates how to apply conditional formatting to the notes of each slide

// in a PPTX presentation using C# and Aspose.Slides for .NET. The example loads

// an existing presentation, creates notes slides where missing, and changes the

// text color of note portions based on specific keywords (TODO, NOTE, IMPORTANT).

// The modified presentation is saved as a new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Conditional, Formatting,

// Notes, Text, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conditional formatting of PPTX slide notes.

// - Build C# utilities for processing and enhancing PowerPoint notes.

// - Generate or transform PPTX files with highlighted note content in .NET.

// - Validate and prepare presentation notes before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Util;



namespace ApplyConditionalFormattingToNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Iterate through all slides

                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)

                    {

                        // Access the notes slide manager for the current slide

                        Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;



                        // Get existing notes slide or create a new one if it does not exist

                        Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;

                        if (notesSlide == null)

                        {

                            notesSlide = notesManager.AddNotesSlide();

                        }



                        // Get the notes text frame

                        Aspose.Slides.ITextFrame notesTextFrame = notesSlide.NotesTextFrame;

                        if (notesTextFrame == null)

                        {

                            continue; // No text frame to process

                        }



                        // Iterate through paragraphs and portions to apply conditional formatting

                        foreach (Aspose.Slides.IParagraph paragraph in notesTextFrame.Paragraphs)

                        {

                            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)

                            {

                                string portionText = portion.Text;



                                // Change text color based on keyword presence

                                if (portionText.Contains("TODO"))

                                {

                                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

                                }

                                else if (portionText.Contains("NOTE"))

                                {

                                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;

                                }

                                else if (portionText.Contains("IMPORTANT"))

                                {

                                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

                                }

                            }

                        }

                    }



                    // Save the modified presentation

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

