using System;
using System.Drawing;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set background of the first slide to solid blue
            presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Save the presentation
            string outputPath = "DesignPresentation_out.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}