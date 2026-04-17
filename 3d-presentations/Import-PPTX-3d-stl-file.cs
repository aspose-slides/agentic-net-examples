using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        string stlPath = "model.stl";
        string outputPath = "output.pptx";

        if (!File.Exists(stlPath))
        {
            Console.WriteLine("STL file not found: " + stlPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            byte[] stlData = File.ReadAllBytes(stlPath);
            Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(stlData, "stl");

            Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                0,
                0,
                presentation.SlideSize.Size.Width,
                presentation.SlideSize.Size.Height,
                dataInfo);

            // Show the 3D object instead of an icon
            oleObjectFrame.IsObjectIcon = false;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}