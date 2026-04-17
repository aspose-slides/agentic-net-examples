using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart without sample data
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f, false);

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add primary series
            IChartSeries primarySeries = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"),
                ChartType.ClusteredColumn);

            // Add secondary series and plot it on the secondary axis
            IChartSeries secondarySeries = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Secondary Series"),
                ChartType.ClusteredColumn);
            secondarySeries.PlotOnSecondAxis = true;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate primary series data points
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20.0));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 40.0));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30.0));

            // Populate secondary series data points
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 200.0));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 150.0));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 180.0));

            // Synchronize secondary vertical axis scale with primary vertical axis
            IAxis primaryAxis = chart.Axes.VerticalAxis;
            IAxis secondaryAxis = chart.Axes.SecondaryVerticalAxis;
            if (secondaryAxis != null)
            {
                secondaryAxis.MinValue = primaryAxis.MinValue;
                secondaryAxis.MaxValue = primaryAxis.MaxValue;
            }

            // Save the presentation
            pres.Save("AddSecondaryAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}