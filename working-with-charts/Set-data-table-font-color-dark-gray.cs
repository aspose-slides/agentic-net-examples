using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // format not supported
            return;
        }

        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
        if (table == null)
        {
            Console.WriteLine("No table found on the first slide.");
            presentation.Dispose();
            return;
        }

        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
        portionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkGray;

        table.SetTextFormat(portionFormat);

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}