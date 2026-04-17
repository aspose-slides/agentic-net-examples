using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Add a digital timestamp watermark to the master slide
                IMasterSlide master = pres.Masters[0];
                float slideWidth = pres.SlideSize.Size.Width;
                float slideHeight = pres.SlideSize.Size.Height;

                IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    0,
                    0,
                    slideWidth,
                    slideHeight);

                watermarkShape.AddTextFrame(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
                watermarkShape.FillFormat.FillType = FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

                // Convert to PDF with default options
                PdfOptions pdfOptions = new PdfOptions();
                pres.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}