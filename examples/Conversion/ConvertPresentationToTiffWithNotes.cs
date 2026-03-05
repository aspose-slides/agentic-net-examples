using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToTiffWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file (PPT or PPTX)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Output TIFF file path
            string outputTiffPath = Path.ChangeExtension(inputPath, ".tiff");

            // Output presentation path to satisfy the "save before exit" rule
            string outputPresentationPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", "saved_output.pptx");

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Configure TIFF options with notes layout
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                Aspose.Slides.Export.NotesCommentsLayoutingOptions notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
                tiffOptions.SlidesLayoutOptions = notesOptions;

                // Save as multi‑page TIFF with notes
                presentation.Save(outputTiffPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                // Save the (unchanged) presentation before exiting
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}