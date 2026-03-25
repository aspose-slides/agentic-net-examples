using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "template.pptx";
        string outputPath = "StyledBubbleChart.pptx";

        Aspose.Slides.Presentation pres = null;
        try
        {
            if (File.Exists(inputPath))
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation if the template is missing
                pres = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Ensure there is at least one slide
        Aspose.Slides.ISlide slide = null;
        if (pres.Slides.Count > 0)
        {
            slide = pres.Slides[0];
        }
        else
        {
            slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
        }

        // Add a bubble chart (no sample data)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            50, 50, 500, 400, false);

        // Remove default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Workbook for creating cells
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
            Aspose.Slides.Charts.ChartType.Bubble);

        // Add categories (X‑axis labels)
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "A"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "B"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "C"));

        // Add bubble data points: X, Y, Size
        series.DataPoints.AddDataPointForBubbleSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 4.0),
            workbook.GetCell(defaultWorksheetIndex, 1, 2, 5.0),
            workbook.GetCell(defaultWorksheetIndex, 1, 3, 30.0));

        series.DataPoints.AddDataPointForBubbleSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 6.0),
            workbook.GetCell(defaultWorksheetIndex, 2, 2, 7.0),
            workbook.GetCell(defaultWorksheetIndex, 2, 3, 50.0));

        series.DataPoints.AddDataPointForBubbleSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 8.0),
            workbook.GetCell(defaultWorksheetIndex, 3, 2, 9.0),
            workbook.GetCell(defaultWorksheetIndex, 3, 3, 70.0));

        // Enable varied colors for each bubble
        series.ParentSeriesGroup.IsColorVaried = true;

        // Style first bubble marker
        Aspose.Slides.Charts.IChartDataPoint point0 = series.DataPoints[0];
        point0.Marker.Size = 12;
        point0.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;
        point0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        point0.Format.Fill.SolidFillColor.Color = Color.Red;

        // Style second bubble marker
        Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints[1];
        point1.Marker.Size = 14;
        point1.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Triangle;
        point1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        point1.Format.Fill.SolidFillColor.Color = Color.Green;

        // Show bubble size values in data labels
        series.Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}