using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Set chart title with current date and time
        chart.HasTitle = true;
        string titleText = "Report generated on " + DateTime.Now.ToString("g");
        chart.ChartTitle.AddTextFrameForOverriding(titleText);
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 30f;
        chart.ChartTitle.Width = 400f;
        chart.ChartTitle.Y = 10f;
        chart.ChartTitle.X = 100f;

        // Save the presentation
        presentation.Save("ChartWithDynamicTitle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}