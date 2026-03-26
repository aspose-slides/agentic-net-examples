using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExplainDataLabelProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outPath = "DataLabelProperties_out.pptx";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Add two series
                IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Populate data points for series1
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                // Populate data points for series2
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 10));
                series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 60));

                // Example 1: Show value for the first data label of the first series
                IDataLabel label1 = series1.DataPoints[0].Label;
                label1.DataLabelFormat.ShowValue = true;

                // Example 2: Show series name for the second data label of the first series
                IDataLabel label2 = series1.DataPoints[1].Label;
                label2.DataLabelFormat.ShowSeriesName = true;

                // Example 3: Show category name and value with a custom separator for the third data label
                IDataLabel label3 = series1.DataPoints[2].Label;
                label3.DataLabelFormat.ShowCategoryName = true;
                label3.DataLabelFormat.ShowValue = true;
                label3.DataLabelFormat.Separator = " - ";

                // Example 4: Change default data label format for all labels in the second series
                IDataLabelFormat defaultFormatSeries2 = series2.Labels.DefaultDataLabelFormat;
                defaultFormatSeries2.ShowValue = true;
                defaultFormatSeries2.ShowSeriesName = true;
                defaultFormatSeries2.ShowLegendKey = false;
                defaultFormatSeries2.ShowLabelAsDataCallout = true; // display as callout

                // Example 5: Hide a specific data label
                IDataLabel labelToHide = series2.DataPoints[1].Label;
                labelToHide.Hide();

                // Save the presentation
                pres.Save(outPath, SaveFormat.Pptx);
            }

            // Notify the user
            Console.WriteLine("Presentation saved to " + Path.GetFullPath(outPath));
        }
    }
}