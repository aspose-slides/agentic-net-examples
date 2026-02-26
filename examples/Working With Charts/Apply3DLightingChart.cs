using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("3D Lighting Example");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

        // Apply 3D lighting settings
        chart.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        chart.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        chart.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;

        // Save the presentation
        pres.Save("Chart3DLighting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}