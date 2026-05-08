using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the title slide (first slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 100f, 400f, 300f);

        // Display percentage labels for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Optionally hide the raw value labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;

        // Save the presentation
        try
        {
            presentation.Save("PieChartWithPercentages.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}