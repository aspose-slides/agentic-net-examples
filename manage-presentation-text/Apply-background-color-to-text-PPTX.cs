using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.PortionFormat format = new Aspose.Slides.PortionFormat();
            format.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            format.FillFormat.SolidFillColor.Color = Color.Yellow;

            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "[placeholder]", "[placeholder]", format);

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}