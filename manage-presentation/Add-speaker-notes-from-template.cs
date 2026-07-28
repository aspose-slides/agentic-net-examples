// -----------------------------------------------------------------------------
// Example: Add speaker notes from template using C#
//
// Description:
// Demonstrates how to add speaker notes to each slide of a presentation 
// using a plain‑text template file with Aspose.Slides for .NET. The example 
// loads an existing PPTX, reads a line‑per‑slide notes file, creates a notes 
// slide for every slide, assigns the corresponding text (or a default note) 
// and saves the result as a new PPTX file. This pattern can be used to 
// automate speaker‑notes generation in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Speaker, Notes, Template, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding speaker notes from a predefined template.
// - Build C# utilities for PowerPoint presentation enrichment.
// - Generate or modify PPTX files programmatically in .NET.
// - Validate and preview speaker notes before publishing a presentation.
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
            // Paths for input presentation, notes template and output presentation
            string inputPath = "input.pptx";
            string notesTemplatePath = "notes.txt";
            string outputPath = "output.pptx";

            // Verify that input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }

            if (!File.Exists(notesTemplatePath))
            {
                Console.WriteLine("Notes template file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Read notes template (one line per slide)
                string[] notesLines = File.ReadAllLines(notesTemplatePath);

                // Add speaker notes to each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    INotesSlideManager notesManager = slide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.AddNotesSlide();

                    // Use corresponding line from template or a default note
                    string noteText = i < notesLines.Length ? notesLines[i] : "Speaker notes not provided.";
                    notesSlide.NotesTextFrame.Text = noteText;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to unsupported format, the format is not supported.
            }
        }
    }
}
