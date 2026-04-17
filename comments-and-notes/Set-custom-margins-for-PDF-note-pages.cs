using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                var pdfOptions = new Aspose.Slides.Export.PdfOptions();
                var notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
                pdfOptions.SlidesLayoutOptions = notesOptions;

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}