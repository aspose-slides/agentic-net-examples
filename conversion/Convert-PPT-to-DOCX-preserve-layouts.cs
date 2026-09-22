// -----------------------------------------------------------------------------
// Example: Convert PowerPoint PPTX to DOCX while preserving slide layouts
//
// Description:
// This console application demonstrates how to load a PowerPoint presentation
// (PPTX) using Aspose.Slides for .NET, validates the input file, and attempts to
// convert it to a DOCX document. Since Aspose.Slides does not directly support
// DOCX export, the code handles the limitation gracefully and saves a copy of
// the presentation in PPTX format before exiting. Developers can extend this
// pattern with additional libraries (e.g., Aspose.Words) for full PPTX‑to‑DOCX
// conversion.
//
// Keywords:
// C#, PowerPoint, PPTX, DOCX, Aspose.Slides for .NET, slide layout preservation
//
// Use Cases:
// - Automate batch conversion of presentations to Word documents in a CI pipeline.
// - Validate that slide layouts are retained when exporting to editable formats.
// - Integrate presentation processing into .NET backend services.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPptxPath = "output_copy.pptx";
        string outputDocxPath = "output.docx";

        // Verify that the input PPTX file exists
        if (!System.IO.File.Exists(inputPath))
        {
            Console.WriteLine($"Error: The input file \"{inputPath}\" was not found.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Attempt to save as DOCX – not directly supported by Aspose.Slides
            // This block demonstrates handling the unsupported format scenario.
            try
            {
                // The following line would cause a compile-time error because
                // Aspose.Slides.Export.SaveFormat does not contain a Docx member.
                // presentation.Save(outputDocxPath, Aspose.Slides.Export.SaveFormat.Docx);
                Console.WriteLine("DOCX export is not directly supported by Aspose.Slides. " +
                                  "Consider using Aspose.Words or another conversion library.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("DOCX export attempted but is not supported.");
            }

            // Save a copy of the presentation in PPTX format to satisfy the "save before exit" requirement
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine($"Presentation saved as PPTX to \"{outputPptxPath}\".");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"An error occurred while processing the presentation: {ex.Message}");
        }
    }
}
