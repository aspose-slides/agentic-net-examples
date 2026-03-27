using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "book1.xlsx";
        string outputPath = "OleEmbed_out.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        Presentation pres = new Presentation();
        ISlide slide = pres.Slides[0];
        byte[] excelData = File.ReadAllBytes(inputPath);
        IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(excelData, "xlsx");
        IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, dataInfo);
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}