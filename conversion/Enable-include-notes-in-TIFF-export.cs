using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffExport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.tiff";

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure TIFF export options with notes included
                TiffOptions tiffOptions = new TiffOptions();
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomFull;
                tiffOptions.SlidesLayoutOptions = notesOptions;

                // Save the presentation as TIFF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}