using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                PdfOptions options = new PdfOptions
                {
                    SlidesLayoutOptions = new HandoutLayoutingOptions
                    {
                        Handout = HandoutType.Handouts2,
                        PrintSlideNumbers = false,
                        PrintFrameSlide = false
                    }
                };

                // Save the presentation as a handout PDF with speaker notes beneath each slide
                pres.Save(outputPath, SaveFormat.Pdf, options);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}