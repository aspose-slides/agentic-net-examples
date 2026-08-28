// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Find PPTX slide notes by phrase using C#

//

// Description:

// Demonstrates how to search slide notes in a PPTX file for a specific phrase

// using Aspose.Slides for .NET. The example loads a presentation, iterates

// through each slide's notes, collects indices of slides whose notes contain the

// target phrase (case‑insensitive), outputs the matching slide indices, and saves

// the presentation.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Slide Notes, Text Search, Presentation

// Processing, Office Automation

//

// Use Cases:

// - Locate slides that contain important annotations or reminders.

// - Build automated validation tools for presentation content.

// - Generate reports of slides with specific note keywords.

// - Integrate note‑search functionality into .NET PowerPoint utilities.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideNotesSearch

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Phrase to search in notes

            string searchPhrase = "Important";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            Presentation presentation = null;

            try

            {

                // Load presentation

                presentation = new Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or loading errors

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            // List to hold slide indices containing the phrase

            List<int> matchingSlideIndices = new List<int>();



            // Iterate through slides

            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                ISlide slide = presentation.Slides[i];

                INotesSlideManager notesManager = slide.NotesSlideManager;

                INotesSlide notesSlide = notesManager.NotesSlide;

                if (notesSlide != null && notesSlide.NotesTextFrame != null)

                {

                    string notesText = notesSlide.NotesTextFrame.Text;

                    if (!string.IsNullOrEmpty(notesText) && notesText.IndexOf(searchPhrase, StringComparison.OrdinalIgnoreCase) >= 0)

                    {

                        matchingSlideIndices.Add(i);

                    }

                }

            }



            // Output matching slide indices

            Console.WriteLine("Slides containing the phrase \"" + searchPhrase + "\" in notes:");

            foreach (int index in matchingSlideIndices)

            {

                Console.WriteLine("Slide index: " + index);

            }



            try

            {

                // Save presentation before exit

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle save errors (e.g., unsupported format)

                Console.WriteLine("Failed to save presentation: " + ex.Message);

            }

            finally

            {

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}

