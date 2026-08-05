// -----------------------------------------------------------------------------
// Example: Export slide notes to text files using C#
//
// Description:
// Demonstrates how to export slide notes from each slide of a PowerPoint
// presentation to individual text files using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, extracts the notes text for every slide,
// writes each note to a separate .txt file, and saves the presentation.
// This pattern can be used to automate note extraction, create documentation,
// or integrate slide notes handling into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide Notes, Text Files,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of slide notes to text files for documentation.
// - Build C# utilities for processing PowerPoint presentations.
// - Generate separate note files for review, translation, or archiving.
// - Integrate slide notes handling into larger .NET workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation file path
        string inputPath = "input.pptx";
        // Output directory for notes files
        string outputDir = "NotesOutput";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }

        // Export notes from each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
            string notesText = string.Empty;

            if (notesSlide != null && notesSlide.NotesTextFrame != null)
            {
                notesText = notesSlide.NotesTextFrame.Text;
            }

            string noteFilePath = Path.Combine(outputDir, $"Slide_{i + 1}_Notes.txt");
            File.WriteAllText(noteFilePath, notesText);
        }

        // Save the presentation before exiting
        presentation.Save(inputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}
