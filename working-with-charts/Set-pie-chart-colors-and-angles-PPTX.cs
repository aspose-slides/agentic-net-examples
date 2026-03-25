using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace PieChartCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine presentation source
            Aspose.Slides.Presentation presentation;
            if (args.Length > 0)
            {
                string inputPath = args[0];
                if (!File.Exists(inputPath))
                {
                    throw new FileNotFoundException("Input presentation file not found.", inputPath);
                }
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Access first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

            // Set chart title
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 30f;
            chart.HasTitle = true;

            // Configure data labels to show value and percentage
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Set first slice angle (rotate chart)
            chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 45;

            // Clear default data
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Workbook for data cells
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Product A"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Product B"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Product C"));

            // Add series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Sales"), chart.Type);

            // Add data points
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 40));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 35));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 25));

            // Customize slice colors (varied colors)
            series.ParentSeriesGroup.IsColorVaried = true;

            // Explode second slice
            series.DataPoints[1].Explosion = 20;

            // Save the presentation
            string outputPath = "CustomizedPieChart.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}