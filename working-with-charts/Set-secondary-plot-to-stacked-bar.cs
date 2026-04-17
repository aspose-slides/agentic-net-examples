using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetSecondaryPlotToStackedBar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart as the primary chart type
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add primary series (Clustered Column)
                IChartSeries primarySeries = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Primary Series"), ChartType.ClusteredColumn);
                primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                primarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Add secondary series and set it to plot on secondary axis
                IChartSeries secondarySeries = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Secondary Series"), ChartType.StackedBar);
                secondarySeries.PlotOnSecondAxis = true;
                secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 40));
                secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 20));
                secondarySeries.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

                // Save the presentation
                try
                {
                    pres.Save("SetSecondaryPlotToStackedBar.pptx", SaveFormat.Pptx);
                }
                catch (System.NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}