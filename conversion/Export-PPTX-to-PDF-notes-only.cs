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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Configure PDF export options to use the NotesOnly layout
            Aspose.Slides.Export.PdfOptions options = new Aspose.Slides.Export.PdfOptions();
            options.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

            // Save the presentation as PDF with the specified options
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, options);

            // Release resources
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}