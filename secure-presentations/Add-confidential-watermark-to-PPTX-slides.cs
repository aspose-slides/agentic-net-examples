using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SecurePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : null;
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            Aspose.Slides.Presentation pres;

            if (!string.IsNullOrEmpty(inputPath))
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file does not exist.");
                    return;
                }

                try
                {
                    // Load existing presentation
                    pres = new Aspose.Slides.Presentation(inputPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The file format is not supported.");
                    return;
                }
            }
            else
            {
                // Create a new presentation
                pres = new Aspose.Slides.Presentation();
            }

            // Get the first master slide
            Aspose.Slides.IMasterSlide master = pres.Masters[0];

            // Determine slide dimensions
            float slideWidth = pres.SlideSize.Size.Width;
            float slideHeight = pres.SlideSize.Size.Height;

            // Add a rectangle shape that covers the whole slide
            Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                slideWidth,
                slideHeight);

            // Add the watermark text
            watermarkShape.AddTextFrame("Confidential");

            // Center the text
            watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // Make the shape itself invisible
            watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Set semi‑transparent text color
            watermarkShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            watermarkShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Gray);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}