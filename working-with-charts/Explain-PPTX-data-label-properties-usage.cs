using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExplainDataLabelProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Set chart title
                    chart.ChartTitle.AddTextFrameForOverriding("Sales Overview");
                    chart.HasTitle = true;

                    // Get default worksheet index
                    int defaultWorksheetIndex = 0;
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add two series
                    IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Q1"), chart.Type);
                    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Q2"), chart.Type);

                    // Add three categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Product A"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Product B"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Product C"));

                    // Populate series data
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 150));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 180));

                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 80));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 130));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 170));

                    // -----------------------------------------------------------------
                    // Demonstrate data label properties
                    // -----------------------------------------------------------------

                    // 1. Show value for the first data point of the first series
                    IDataLabel label1 = series1.DataPoints[0].Label;
                    label1.DataLabelFormat.ShowValue = true;

                    // 2. Show category name and series name for the second data point of the first series
                    IDataLabel label2 = series1.DataPoints[1].Label;
                    label2.DataLabelFormat.ShowCategoryName = true;
                    label2.DataLabelFormat.ShowSeriesName = true;

                    // 3. Customize separator and position for the third data point of the first series
                    IDataLabel label3 = series1.DataPoints[2].Label;
                    label3.DataLabelFormat.ShowValue = true;
                    label3.DataLabelFormat.Separator = " / ";
                    label3.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

                    // 4. Apply default data label format to all labels of the second series
                    IDataLabelFormat defaultFormat = series2.Labels.DefaultDataLabelFormat;
                    defaultFormat.ShowValue = true;
                    defaultFormat.ShowSeriesName = true;
                    defaultFormat.ShowLeaderLines = true;

                    // 5. Hide all data labels for the second series by using the collection's Hide method
                    series2.Labels.Hide();

                    // Save the presentation
                    presentation.Save("DataLabelPropertiesDemo.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}