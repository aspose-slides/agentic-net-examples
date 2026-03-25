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
        // Determine input file path if provided as argument
        string inputPath = null;
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        Aspose.Slides.Presentation presentation = null;

        try
        {
            if (!string.IsNullOrEmpty(inputPath))
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException("Input file not found.", inputPath);
                }
                // Load existing presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an Area chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Area,
            50f, 50f, 600f, 400f);

        // Enable rounded corners for the chart area
        chart.HasRoundedCorners = true;

        // Set line format to solid and single style
        chart.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        chart.LineFormat.Style = Aspose.Slides.LineStyle.Single;

        // Remove default sample series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Index of the default worksheet in the chart data workbook
        int defaultWorksheetIndex = 0;
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add first series and populate data points
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
            Aspose.Slides.Charts.ChartType.Area);
        series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
        series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
        series1.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
        series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = Color.Blue;

        // Add second series and populate data points
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
            Aspose.Slides.Charts.ChartType.Area);
        series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 15));
        series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 25));
        series2.DataPoints.AddDataPointForAreaSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 35));
        series2.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series2.Format.Fill.SolidFillColor.Color = Color.Green;

        // Add and configure chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sample Area Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
        chart.ChartTitle.Height = 20;

        // Save the presentation
        string outputPath = "AreaChartPresentation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}