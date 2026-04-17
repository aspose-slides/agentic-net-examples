using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Configure PDF options to include notes and comments
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            layoutOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            layoutOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;
            pdfOptions.SlidesLayoutOptions = layoutOptions;

            // Save the presentation as PDF
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Dispose the presentation object
            pres.Dispose();

            Console.WriteLine("Presentation exported to PDF successfully.");
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported.
        }
    }
}