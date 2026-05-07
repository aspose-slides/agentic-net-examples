using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
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
            Presentation pres = new Presentation(inputPath);

            // Configure PDF export options for handout with two slides per page
            PdfOptions options = new PdfOptions
            {
                ShowHiddenSlides = true,
                SlidesLayoutOptions = new HandoutLayoutingOptions
                {
                    Handout = HandoutType.Handouts2,
                    // Custom margins can be adjusted via additional properties if needed
                }
            };

            // Save the presentation as a handout PDF
            pres.Save(outputPath, SaveFormat.Pdf, options);
            pres.Dispose();

            Console.WriteLine("Handout PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}