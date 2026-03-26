using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Retrieve the first chart on the slide
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Clear existing series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add new series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

            // Add new categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Populate data for the first series
            IChartSeries series0 = chart.ChartData.Series[0];
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series0.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            series0.Format.Fill.FillType = FillType.Solid;
            series0.Format.Fill.SolidFillColor.Color = Color.Red;

            // Populate data for the second series
            IChartSeries series1 = chart.ChartData.Series[1];
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));
            series1.Format.Fill.FillType = FillType.Solid;
            series1.Format.Fill.SolidFillColor.Color = Color.Green;

            // Configure data labels for the second series
            IDataLabel label0 = series1.DataPoints[0].Label;
            label0.DataLabelFormat.ShowCategoryName = true;

            IDataLabel label1 = series1.DataPoints[1].Label;
            label1.DataLabelFormat.ShowSeriesName = true;

            IDataLabel label2 = series1.DataPoints[2].Label;
            label2.DataLabelFormat.ShowValue = true;
            label2.DataLabelFormat.ShowSeriesName = true;
            label2.DataLabelFormat.Separator = "/";

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}