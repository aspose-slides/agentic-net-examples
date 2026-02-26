using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify command‑line arguments: input file and output TIFF file
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputFilePath> <outputTiffPath>");
            return;
        }

        string inputFilePath = args[0];
        string outputTiffPath = args[1];

        // Load the source presentation (PPT or PPTX)
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath))
        {
            // Configure TIFF options to include notes on each slide
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            Aspose.Slides.Export.NotesCommentsLayoutingOptions notesLayout = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesLayout.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            tiffOptions.SlidesLayoutOptions = notesLayout;

            // Save the presentation as a multi‑page TIFF with notes
            presentation.Save(outputTiffPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
    }
}