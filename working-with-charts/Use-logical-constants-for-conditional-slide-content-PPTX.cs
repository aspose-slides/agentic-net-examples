using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Logical constants for conditional content
            const bool AddRectangleShape = true;
            const bool AddChart = true;

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Conditionally add a rectangle shape
                if (AddRectangleShape)
                {
                    Aspose.Slides.IShape rectangle = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        50, 50, 200, 100);
                    rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    rectangle.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightBlue;
                }

                // Conditionally add a chart with varied series colors
                if (AddChart)
                {
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ClusteredColumn,
                        300, 50, 400, 300);

                    // Clear default sample data
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Access the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    const int defaultWorksheetIndex = 0;

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                    // Add series
                    Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        chart.Type);
                    Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                        chart.Type);

                    // Populate series data
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

                    // Enable automatic varied colors for each series
                    series1.ParentSeriesGroup.IsColorVaried = true;
                    series2.ParentSeriesGroup.IsColorVaried = true;
                }

                // Save the presentation
                string outputPath = "ConditionalContentPresentation.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}