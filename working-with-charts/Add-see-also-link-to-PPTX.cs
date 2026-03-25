using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            if (presentation.Slides.Count < 2)
            {
                Console.WriteLine("Presentation must contain at least two slides.");
                return;
            }

            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            Aspose.Slides.ISlide targetSlide = presentation.Slides[1];

            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 50);
            shape.AddTextFrame("See also");

            Aspose.Slides.IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];
            Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
            hyperlinkManager.SetInternalHyperlinkClick(targetSlide);
            portion.PortionFormat.HyperlinkClick.Tooltip = "Go to related slide";

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}