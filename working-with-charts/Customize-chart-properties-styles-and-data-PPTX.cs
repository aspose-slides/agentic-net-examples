using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory and file
        string outputDir = "output";
        string outputPath = Path.Combine(outputDir, "CustomizedChart.pptx");

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Optional external workbook path
        string workbookPath = "data.xlsx";
        bool useExternalWorkbook = File.Exists(workbookPath);

        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20;

            // Access the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Link external workbook if it exists
            if (useExternalWorkbook)
            {
                Aspose.Slides.Charts.ChartData chartData = chart.ChartData as Aspose.Slides.Charts.ChartData;
                chartData.SetExternalWorkbook(workbookPath);
            }

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Default worksheet index
            int defaultWorksheetIndex = 0;

            // Add series with names
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "2019"), chart.Type);
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "2020"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Q1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Q2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Q3"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "Q4"));

            // Populate series1 data points
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 120));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 150));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 170));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 200));

            // Populate series2 data points
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 100));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 130));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 160));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 190));

            // Set fill colors for series
            series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.CornflowerBlue;

            series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            series2.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Orange;

            // Show values on data labels for the first series
            series1.Labels.DefaultDataLabelFormat.ShowValue = true;

            // Adjust gap width via the series group
            Aspose.Slides.Charts.IChartSeriesGroup seriesGroup = series1.ParentSeriesGroup;
            seriesGroup.GapWidth = 150; // percentage

            // Apply a predefined chart style
            chart.Style = Aspose.Slides.Charts.StyleType.Style3;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}