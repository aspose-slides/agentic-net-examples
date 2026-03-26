using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizeCalloutShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
                // Add a blank slide
                ISlide slide = presentation.Slides[0];
                // Add a sample pie chart to demonstrate callout customization
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 400);
                // Populate chart with sample data
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 30));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 50));
                series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 20));
            }

            // Access the first slide
            ISlide firstSlide = presentation.Slides[0];

            // Find the first chart on the slide
            IChart targetChart = null;
            for (int i = 0; i < firstSlide.Shapes.Count; i++)
            {
                IChart chartCandidate = firstSlide.Shapes[i] as IChart;
                if (chartCandidate != null)
                {
                    targetChart = chartCandidate;
                    break;
                }
            }

            // If no chart exists, add one
            if (targetChart == null)
            {
                targetChart = firstSlide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 400);
            }

            // Enable callout for data labels of the first series
            targetChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Iterate through each data point and customize visual properties
            for (int i = 0; i < targetChart.ChartData.Series[0].DataPoints.Count; i++)
            {
                IChartDataPoint dataPoint = targetChart.ChartData.Series[0].DataPoints[i];

                // Set fill color of the callout shape
                dataPoint.Format.Fill.FillType = FillType.Solid;
                dataPoint.Format.Fill.SolidFillColor.Color = Color.Yellow;

                // Set line style of the callout shape
                dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
                dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
                dataPoint.Format.Line.Width = 2.0f;
                dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
                dataPoint.Format.Line.Style = LineStyle.Single;

                // Customize text formatting of the callout
                IDataLabel label = dataPoint.Label;
                label.TextFormat.PortionFormat.FontBold = NullableBool.True;
                label.TextFormat.PortionFormat.FontHeight = 12.0f;
                label.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
                label.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}