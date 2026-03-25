using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizeBubbleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to an optional source presentation
            string sourcePath = "Template.pptx";
            // Output file path
            string outputPath = "CustomizedBubbleChart_out.pptx";

            // Create or load presentation with exception handling
            Aspose.Slides.Presentation presentation;
            if (File.Exists(sourcePath))
            {
                try
                {
                    presentation = new Aspose.Slides.Presentation(sourcePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                // If source file not found, create a new presentation
                presentation = new Aspose.Slides.Presentation();
            }

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get reference to the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories (X axis labels)
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), ChartType.Bubble);

            // Populate bubble data points (X, Y, Size)
            series.DataPoints.AddDataPointForBubbleSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10), workbook.GetCell(defaultWorksheetIndex, 1, 2, 20), workbook.GetCell(defaultWorksheetIndex, 1, 3, 30));
            series.DataPoints.AddDataPointForBubbleSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 15), workbook.GetCell(defaultWorksheetIndex, 2, 2, 25), workbook.GetCell(defaultWorksheetIndex, 2, 3, 35));
            series.DataPoints.AddDataPointForBubbleSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20), workbook.GetCell(defaultWorksheetIndex, 3, 2, 30), workbook.GetCell(defaultWorksheetIndex, 3, 3, 40));

            // Customize bubble appearance
            // Enable varied colors for each bubble
            series.ParentSeriesGroup.IsColorVaried = true;

            // Set fill color for the series (applies to bubbles without varied colors)
            series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 100, 150, 200); // Light blue

            // Set border (line) format for bubbles
            series.Format.Line.Width = 2.0f;
            series.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            series.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}