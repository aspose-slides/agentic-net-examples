using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Save the presentation before exiting (as required)
        presentation.Save("saved_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Create TIFF export options
        Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

        // Configure notes layout to include notes at the bottom of each page
        Aspose.Slides.Export.NotesCommentsLayoutingOptions notesLayout = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
        notesLayout.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
        tiffOptions.SlidesLayoutOptions = notesLayout;

        // Export the presentation to a multi‑page TIFF file with notes
        presentation.Save("output_with_notes.tiff", Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
    }
}