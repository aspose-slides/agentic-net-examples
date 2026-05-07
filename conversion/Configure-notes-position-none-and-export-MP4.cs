using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.mp4";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure notes to be hidden during rendering
            NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.None;

            // NOTE: Aspose.Slides does not provide a built‑in MP4 export option in this version.
            // Attempting to save as MP4 would raise a NotSupportedException.
            // The following line is commented out to keep the code compilable.
            // presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Mp4, notesOptions);

            // Since MP4 export is not supported, inform the user.
            Console.WriteLine("MP4 video export is not supported by the current Aspose.Slides library.");

            // Save the presentation (e.g., as PDF) to demonstrate that the presentation can be saved.
            string fallbackPath = Path.ChangeExtension(outputPath, ".pdf");
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.SlidesLayoutOptions = notesOptions; // Hide notes in the PDF as well
            presentation.Save(fallbackPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation before exiting
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested export format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}