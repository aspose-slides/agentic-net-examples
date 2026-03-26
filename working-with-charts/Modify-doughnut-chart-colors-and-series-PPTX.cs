using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Assume the first shape is a doughnut chart
        IChart chart = slide.Shapes[0] as IChart;
        if (chart == null || chart.Type != ChartType.Doughnut)
        {
            Console.WriteLine("No doughnut chart found on the first slide.");
            pres.Save(outputPath, SaveFormat.Pptx);
            return;
        }

        // Change the doughnut hole size (using the parent series group)
        chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

        // Change the fill color of the first series
        chart.ChartData.Series[0].Format.Fill.FillType = FillType.Solid;
        chart.ChartData.Series[0].Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 0); // Red

        // Add a new category
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 4, 0, "New Category"));

        // Add a new data point to the first series for the new category
        IChartSeries series = chart.ChartData.Series[0];
        series.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 25));

        // Set fill color for the newly added data point
        IChartDataPoint newPoint = series.DataPoints[series.DataPoints.Count - 1];
        newPoint.Format.Fill.FillType = FillType.Solid;
        newPoint.Format.Fill.SolidFillColor.Color = Color.FromArgb(0, 0, 255); // Blue

        // Save the modified presentation
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}