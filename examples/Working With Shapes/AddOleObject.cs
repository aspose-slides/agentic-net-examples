using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        // Add an ActiveX OLE object (Excel) to the slide
        var oleObjectFrame = slide.Shapes.AddOleObjectFrame(50f, 50f, 400f, 300f, "Excel.Sheet.12", "sample.xlsx");
        // Display the OLE object as an icon
        oleObjectFrame.IsObjectIcon = true;
        // Save the presentation
        presentation.Save("ActiveX_OLE_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}