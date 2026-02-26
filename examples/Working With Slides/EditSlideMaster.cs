using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set background of the first master slide
        presentation.Masters[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Masters[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "MasterBackground_out.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}