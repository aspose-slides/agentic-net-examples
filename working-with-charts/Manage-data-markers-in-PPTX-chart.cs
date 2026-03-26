using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ManageChartDataMarkers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (File.Exists(inputPath))
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    IChart chart = FindOrCreateChart(presentation);
                    ConfigureChartDataAndMarkers(chart);
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            else
            {
                using (Presentation presentation = new Presentation())
                {
                    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
                    ConfigureChartDataAndMarkers(chart);
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }

        private static IChart FindOrCreateChart(Presentation presentation)
        {
            IChart chart = null;
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                chart = shape as IChart;
                if (chart != null)
                {
                    break;
                }
            }

            if (chart == null)
            {
                chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);
            }

            return chart;
        }

        private static void ConfigureChartDataAndMarkers(IChart chart)
        {
            // Clear any default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Workbook helper
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // First series with visible markers
            IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

            foreach (IChartDataPoint point in series1.DataPoints)
            {
                IMarker marker = point.Marker;
                marker.Size = 10;
                marker.Symbol = MarkerStyleType.Circle;
            }

            // Second series with markers removed
            IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 10));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 60));

            foreach (IChartDataPoint point in series2.DataPoints)
            {
                IMarker marker = point.Marker;
                marker.Symbol = MarkerStyleType.None;
            }
        }
    }
}