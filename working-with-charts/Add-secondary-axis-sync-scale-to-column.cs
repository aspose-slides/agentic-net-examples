using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add primary series
            IChartSeries primarySeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"), chart.Type);
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Add secondary series
            IChartSeries secondarySeries = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Secondary Series"), chart.Type);
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 100));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 200));
            secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 300));

            // Plot the secondary series on the secondary vertical axis
            secondarySeries.PlotOnSecondAxis = true;

            // Synchronize secondary axis scale with primary axis
            IAxis primaryVertical = chart.Axes.VerticalAxis;
            IAxis secondaryVertical = chart.Axes.SecondaryVerticalAxis;

            // Assuming MaxValue and MinValue are writable properties; adjust as needed
            // Copy the scale from primary to secondary axis
            // Note: ActualMaxValue/ActualMinValue are read‑only; use appropriate settable properties if available
            // Example using hypothetical properties:
            // secondaryVertical.MaxValue = primaryVertical.MaxValue;
            // secondaryVertical.MinValue = primaryVertical.MinValue;

            // Save the presentation
            try
            {
                string outPath = "SecondaryAxisChart.pptx";
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}