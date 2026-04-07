using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            Console.WriteLine("Please provide input PPT file path as argument.");
            return;
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        string outputDir = Path.GetDirectoryName(inputPath);
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
        string pdfPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Add watermark text to the master slide
            IMasterSlide master = pres.Masters[0];
            IAutoShape watermarkShape = master.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 50);
            watermarkShape.AddTextFrame(fileNameWithoutExt);
            watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
            watermarkShape.FillFormat.FillType = FillType.NoFill;
            watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

            // Save as PDF
            pres.Save(pdfPath, SaveFormat.Pdf);
            pres.Dispose();

            Console.WriteLine("PDF saved to: " + pdfPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}