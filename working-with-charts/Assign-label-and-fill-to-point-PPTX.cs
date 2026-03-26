using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a Sunburst chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Sunburst, 50f, 50f, 500f, 400f);

        // Access the data points of the first series
        Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

        // Choose a data point and its level to customize the label
        Aspose.Slides.Charts.IChartDataPointLevel level = dataPoints[0].DataPointLevels[1];

        // Set label display options
        level.Label.DataLabelFormat.ShowCategoryName = false;
        level.Label.DataLabelFormat.ShowValue = true;
        level.Label.DataLabelFormat.ShowSeriesName = true;

        // Set a custom fill color for the label text
        level.Label.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        level.Label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Save the presentation
        presentation.Save("CustomLabelSunburst.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}