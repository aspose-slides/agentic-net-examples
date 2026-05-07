using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure PDF options to include hidden slides and preserve notes layout
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.ShowHiddenSlides = true;
            pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
            {
                NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
            };

            // Save the presentation to a memory stream in PDF format
            MemoryStream memoryStream = new MemoryStream();
            presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            memoryStream.Position = 0;

            // Write the memory stream to the output file
            using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                memoryStream.CopyTo(fileStream);
            }

            // Clean up resources
            memoryStream.Close();
            presentation.Dispose();

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}