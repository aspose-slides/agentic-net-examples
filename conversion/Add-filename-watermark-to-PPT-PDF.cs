using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToPdfWithWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

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

                // Add watermark text to the master slide (appears on all slides)
                Aspose.Slides.IMasterSlide master = pres.Masters[0];
                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    0, 0, 500, 50);
                watermarkShape.AddTextFrame(Path.GetFileName(inputPath));
                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Define output PDF path
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Save the presentation as PDF
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("PDF saved successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format exception
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}