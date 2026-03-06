using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Adjust the position of the first data label in the first series
        // X and Y are fractions of the chart's width and height (0.0 to 1.0)
        chart.ChartData.Series[0].Labels[0].X = 0.5f; // Center horizontally
        chart.ChartData.Series[0].Labels[0].Y = 0.2f; // 20% from the top

        // Ensure the label displays its value
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;

        // Save the presentation
        presentation.Save("AdjustLabelLocation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}