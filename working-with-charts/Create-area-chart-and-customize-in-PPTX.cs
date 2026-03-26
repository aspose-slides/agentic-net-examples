using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AreaChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Area,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Enable rounded corners for the chart area
            chart.HasRoundedCorners = true;

            // Set line format for the chart border
            chart.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.LineFormat.Style = Aspose.Slides.LineStyle.Single;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add two series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                Aspose.Slides.Charts.ChartType.Area
            );
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                Aspose.Slides.Charts.ChartType.Area
            );

            // Add three categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate data points for Series 1
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20.0));
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 35.0));
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 15.0));

            // Populate data points for Series 2
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30.0));
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25.0));
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 40.0));

            // Optional: Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample Area Chart");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20;

            // Save the presentation
            string outputPath = "AreaChartPresentation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}