// -----------------------------------------------------------------------------
// Example: Export slide notes to DOCX document using C#
//
// Description:
// Demonstrates how to export slide notes to a DOCX document using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Aspose.Words for .NET, Export, Slide, Notes, Docx, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export slide notes to DOCX document.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Words;

namespace ExportSlideNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output DOCX file path
            string outputPath = "SlideNotes.docx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // StringBuilder to collect notes
                StringBuilder notesBuilder = new StringBuilder();

                // Iterate through slides and extract notes
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                    INotesSlide notesSlide = notesManager.NotesSlide;
                    if (notesSlide != null && notesSlide.NotesTextFrame != null && notesSlide.NotesTextFrame.Text != null)
                    {
                        notesBuilder.AppendLine("Slide " + (i + 1) + " Notes:");
                        notesBuilder.AppendLine(notesSlide.NotesTextFrame.Text);
                        notesBuilder.AppendLine();
                    }
                }

                // Write notes to a DOCX file using Aspose.Words
                Document doc = new Document();
                DocumentBuilder builder = new DocumentBuilder(doc);
                builder.Writeln(notesBuilder.ToString());
                doc.Save(outputPath, Aspose.Words.SaveFormat.Docx);
                Console.WriteLine("Slide notes exported to: " + outputPath);

                // Save the presentation before exiting (using a supported format)
                presentation.Save("SavedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Format not supported comment
                Console.WriteLine("The requested format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
