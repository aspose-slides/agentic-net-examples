using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure there is at least one series; if not, add a default series
            if (chart.ChartData.Series.Count == 0)
            {
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
                chart.ChartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            }

            // Enable data labels to show values for the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Enable automatic overlapping prevention for data labels
            // Note: In the current Aspose.Slides version, IDataLabelFormat does not expose an OverlapMode property.
            // If the property becomes available, it would be set as shown below:
            // chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.OverlapMode = OverlapMode.Auto;

            // Save the presentation
            pres.Save("Output.pptx", SaveFormat.Pptx);
        }
    }
}