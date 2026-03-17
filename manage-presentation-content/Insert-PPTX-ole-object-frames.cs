using System;
using System.IO;
using Aspose.Slides.Export;

namespace InsertOleObject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFile = "book1.xlsx";
                string outputFile = "OleEmbed_out.pptx";

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = pres.Slides[0];
                byte[] excelData = File.ReadAllBytes(inputFile);
                Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");
                Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, dataInfo);
                pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}