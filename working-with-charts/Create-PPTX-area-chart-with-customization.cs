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
            // Define output file path
            string outputPath = "AreaChartPresentation.pptx";

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
            if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 600f, 400f);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sample Area Chart");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
            chart.ChartTitle.Height = 20;

            // Enable rounded corners for the chart area
            chart.HasRoundedCorners = true;

            // Set line format for the chart border
            chart.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.LineFormat.Style = Aspose.Slides.LineStyle.Single;

            // Clear default generated series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get reference to the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add first series
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20.0));
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50.0));
            series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30.0));

            // Add second series
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30.0));
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10.0));
            series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60.0));

            // Apply automatic fill colors to each series
            for (int i = 0; i < chart.ChartData.Series.Count; i++)
            {
                chart.ChartData.Series[i].GetAutomaticSeriesColor();
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}