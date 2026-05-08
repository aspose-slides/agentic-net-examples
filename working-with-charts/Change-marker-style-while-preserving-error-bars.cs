using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        Presentation pres = null;
        try
        {
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }

            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            if (chart.ChartData.Series.Count == 0)
            {
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Series 1"), ChartType.ClusteredColumn);
                chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "Category 2"));
                IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 1, 1, 10));
                series.DataPoints.AddDataPointForBarSeries(wb.GetCell(0, 2, 1, 20));
            }

            IChartSeries firstSeries = chart.ChartData.Series[0];
            IMarker marker = firstSeries.Marker;
            marker.Symbol = MarkerStyleType.Circle;
            marker.Size = 10;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}