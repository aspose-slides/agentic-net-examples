// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Embed slide notes as hidden metadata using C#

//

// Description:

// Demonstrates how to collect notes from each slide in a PowerPoint presentation

// and store them as a custom document property, effectively embedding the notes

// as hidden metadata. The example uses Aspose.Slides for .NET to load, process,

// and save the presentation.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Embed, Slide Notes, Hidden Metadata,

// Custom Document Property, Presentation Processing, Office Automation

//

// Use Cases:

// - Preserve slide notes without displaying them in the presentation.

// - Enable downstream applications to retrieve notes via metadata.

// - Automate embedding of slide notes for archival or compliance purposes.

// - Integrate note extraction and storage into .NET PowerPoint workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace EmbedSlideNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output_with_notes.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Accumulate notes from all slides

                    string allNotes = string.Empty;

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        ISlide slide = presentation.Slides[i];

                        INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)

                        {

                            string noteText = notesSlide.NotesTextFrame.Text;

                            allNotes += $"Slide {i + 1}: {noteText}{Environment.NewLine}";

                        }

                    }



                    // Store the notes as a custom document property (metadata)

                    // This property is not visible in the slide content, acting as hidden metadata

                    presentation.DocumentProperties.SetCustomPropertyValue("EmbeddedSlideNotes", allNotes);



                    // Save the modified presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }



                Console.WriteLine("Presentation saved successfully to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported for this operation.

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., loading errors, I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

