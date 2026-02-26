using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.tiff";

        using (var presentation = new Aspose.Slides.Presentation(inputPath))
        {
            var tiffOptions = new Aspose.Slides.Export.TiffOptions();

            var notesLayout = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesLayout.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomTruncated;

            tiffOptions.SlidesLayoutOptions = notesLayout;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
        }
    }
}