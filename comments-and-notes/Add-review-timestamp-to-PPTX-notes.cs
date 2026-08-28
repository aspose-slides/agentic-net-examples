// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add review timestamp to PPTX notes using C#

//

// Description:

// Demonstrates how to add a review timestamp to PPTX notes using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Review, Timestamp, Pptx, Notes, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate add review timestamp to PPTX notes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AddTimestampToNotes

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output_with_timestamps.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation with exception handling for unsupported formats

            Aspose.Slides.Presentation presentation = null;

            try

            {

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Format not supported or other loading error

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                // Comment: format not supported

                return;

            }



            // Iterate through each slide and add a timestamp to its notes

            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                Aspose.Slides.ISlide slide = presentation.Slides[i];

                Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;



                // Create notes slide if it does not exist

                Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();



                // Prepare timestamp text

                string timestampText = "Last reviewed on: " + DateTime.Now.ToString("g");



                // Set the notes text (append if existing text is present)

                if (notesSlide.NotesTextFrame != null && !string.IsNullOrEmpty(notesSlide.NotesTextFrame.Text))

                {

                    notesSlide.NotesTextFrame.Text += Environment.NewLine + timestampText;

                }

                else

                {

                    notesSlide.NotesTextFrame.Text = timestampText;

                }

            }



            // Save the presentation

            try

            {

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to save presentation: " + ex.Message);

            }

            finally

            {

                // Ensure resources are released

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}

