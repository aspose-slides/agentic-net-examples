using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Hide various data label elements for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLegendKey = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowSeriesName = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = false;

        // Hide legend and title
        chart.HasLegend = false;
        chart.HasTitle = false;

        // Optionally hide the entire chart shape
        chart.Hidden = true;

        // Save the presentation
        presentation.Save("HiddenChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}