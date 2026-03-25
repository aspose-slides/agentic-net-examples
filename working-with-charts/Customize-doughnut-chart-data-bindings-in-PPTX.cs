using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = null;
        if (args.Length > 0)
        {
            inputPath = args[0];
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }
        }

        Presentation pres = null;
        if (inputPath != null)
        {
            pres = new Presentation(inputPath);
        }
        else
        {
            pres = new Presentation();
        }

        ISlide slide = pres.Slides[0];
        // Add a doughnut chart at position (50,50) with size 500x500
        IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 500f, 500f);
        // Set the doughnut hole size to 50%
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

        // Customize chart data
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));

        // Add a series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Add data points to the series
        IChartSeries series = chart.ChartData.Series[0];
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 70));

        // Save the presentation
        string outputPath = "CustomizedDoughnutChart.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}