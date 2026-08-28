// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Append timestamp to PPTX slide notes using C#

//

// Description:

// Demonstrates how to append a UTC timestamp to the notes of each slide in a

// PPTX file using C# and Aspose.Slides for .NET. The example loads an existing

// presentation, ensures each slide has a notes slide, retrieves any existing

// notes text, appends a "Last edited" line with the current UTC timestamp, and

// saves the modified presentation. This pattern can be used to automate

// documentation, version tracking, or audit trails within PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Append, Timestamp, Slide Notes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically add edit timestamps to slide notes for version control.

// - Build .NET tools that enrich PowerPoint presentations with metadata.

// - Generate audit trails for presentations in corporate environments.

// - Integrate timestamping into PowerPoint workflow automation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace UpdateSlideNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Iterate through all slides

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                {

                    // Get the notes slide manager for the current slide

                    Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;



                    // Ensure a notes slide exists

                    Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;

                    if (notesSlide == null)

                    {

                        notesSlide = notesManager.AddNotesSlide();

                    }



                    // Retrieve existing notes text (if any)

                    string existingText = "";

                    if (notesSlide.NotesTextFrame != null && notesSlide.NotesTextFrame.Text != null)

                    {

                        existingText = notesSlide.NotesTextFrame.Text;

                    }



                    // Create timestamp string (UTC)

                    string timestamp = DateTime.UtcNow.ToString("u"); // e.g., 2026-04-06 12:34:56Z



                    // Append timestamp to notes

                    notesSlide.NotesTextFrame.Text = existingText + (existingText.Length > 0 ? "\n" : "") + "Last edited: " + timestamp;

                }



                // Save the updated presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation saved to: " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported or other error occurred

                Console.WriteLine("Error processing presentation: " + ex.Message);

            }

        }

    }

}

