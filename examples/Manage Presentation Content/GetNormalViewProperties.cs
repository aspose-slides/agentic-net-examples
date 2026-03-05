using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Configure normal view properties
        pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
        pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
        pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
        pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
        pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

        // Save the presentation in PPTX format
        pres.Save("NormalViewProperties_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}