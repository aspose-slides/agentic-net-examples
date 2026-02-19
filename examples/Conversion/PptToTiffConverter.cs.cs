using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Convert PPT file to TIFF with notes
        string inputPathPpt = "input.ppt";
        string outputPathPptTiff = "output_ppt.tiff";
        using (Presentation presentation = new Presentation(inputPathPpt))
        {
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
            {
                NotesPosition = NotesPositions.BottomFull
            };
            presentation.Save(outputPathPptTiff, SaveFormat.Tiff, tiffOptions);
        }

        // Convert PPTX file to TIFF with notes
        string inputPathPptx = "input.pptx";
        string outputPathPptxTiff = "output_pptx.tiff";
        using (Presentation presentation = new Presentation(inputPathPptx))
        {
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
            {
                NotesPosition = NotesPositions.BottomFull
            };
            presentation.Save(outputPathPptxTiff, SaveFormat.Tiff, tiffOptions);
        }
    }
}