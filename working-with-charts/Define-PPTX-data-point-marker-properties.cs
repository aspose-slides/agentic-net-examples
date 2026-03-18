using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var slide = pres.Slides[0];
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
                50f, 50f, 500f, 400f);

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            var defaultWorksheetIndex = 0;
            var fact = chart.ChartData.ChartDataWorkbook;

            // Add a series
            var series = chart.ChartData.Series.Add(
                fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Add categories (X values)
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add data points
            series.DataPoints.AddDataPointForScatterSeries(1.0, fact.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series.DataPoints.AddDataPointForScatterSeries(2.0, fact.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForScatterSeries(3.0, fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Customize marker appearance
            foreach (var dp in series.DataPoints)
            {
                dp.Marker.Size = 12;
                dp.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;
                dp.Marker.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                dp.Marker.Format.Fill.SolidFillColor.Color = Color.Blue;
            }

            // Save the presentation
            pres.Save("ChartMarkerDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}