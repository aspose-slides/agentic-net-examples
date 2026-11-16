// -----------------------------------------------------------------------------
// Example: Export Slide Notes to Individual Text Files Using C#
// 
// Description:
// Demonstrates how to extract notes from each slide of a PowerPoint PPTX file
// and write them to separate .txt files using Aspose.Slides for .NET. The program
// creates a sample presentation if the input file is missing, processes all
// slides, saves the notes, and persists any changes to the original file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide Notes, Text Files
// 
// Use Cases:
// - Automate extraction of slide notes for documentation purposes.
// - Generate per‑slide note files for translation or review workflows.
// - Integrate slide note handling into larger .NET automation pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputDir = "NotesOutput";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a sample presentation with a single slide and notes
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                Aspose.Slides.INotesSlide sampleNotes = sampleSlide.NotesSlideManager.AddNotesSlide();
                sampleNotes.NotesTextFrame.Text = "This is a sample note for slide 1.";
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

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

            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            return 0;
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
