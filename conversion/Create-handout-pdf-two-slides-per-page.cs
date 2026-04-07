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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Configure PDF export options for handout mode (2 slides per page) with custom settings
            PdfOptions options = new PdfOptions
            {
                ShowHiddenSlides = true,
                SlidesLayoutOptions = new HandoutLayoutingOptions
                {
                    Handout = HandoutType.Handouts2,
                    PrintFrameSlide = false // Example of custom margin-like setting
                }
            };

            // Save the presentation as a PDF handout
            pres.Save(outputPath, SaveFormat.Pdf, options);

            // Clean up
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}