using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "MasterBackground_Navy.pptx");
        var pres = new Aspose.Slides.Presentation();

        // Set the master slide background to solid navy color
        pres.Masters[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        pres.Masters[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.Navy;

        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}