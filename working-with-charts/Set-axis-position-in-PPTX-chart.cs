using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace SetAxisPositionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expected arguments: inputPath outputPath axisType position
            // axisType: "category" or "value"
            // position: "Bottom", "Left", "Right", "Top"
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: SetAxisPositionExample <inputPath> <outputPath> <axisType> <position>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string axisType = args[2].ToLower();
            string positionName = args[3];

            // Load existing presentation if it exists, otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
                // Add a default chart to the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
                // Optional: clear default data
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();
                Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                // Add sample categories
                chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, "A1", "Category 1"));
                chart.ChartData.Categories.Add(wb.GetCell(defaultWorksheetIndex, "A2", "Category 2"));
                // Add sample series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    wb.GetCell(defaultWorksheetIndex, "B1", "Series 1"), chart.Type);
                series.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, "B2", 10));
                series.DataPoints.AddDataPointForBarSeries(wb.GetCell(defaultWorksheetIndex, "B3", 20));
            }

            // Get the first chart on the first slide
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart targetChart = null;
            foreach (Aspose.Slides.IShape shape in firstSlide.Shapes)
            {
                targetChart = shape as Aspose.Slides.Charts.IChart;
                if (targetChart != null)
                {
                    break;
                }
            }

            if (targetChart == null)
            {
                Console.WriteLine("No chart found in the presentation.");
                return;
            }

            // Parse the desired position
            Aspose.Slides.Charts.AxisPositionType position;
            switch (positionName.ToLower())
            {
                case "bottom":
                    position = Aspose.Slides.Charts.AxisPositionType.Bottom;
                    break;
                case "left":
                    position = Aspose.Slides.Charts.AxisPositionType.Left;
                    break;
                case "right":
                    position = Aspose.Slides.Charts.AxisPositionType.Right;
                    break;
                case "top":
                    position = Aspose.Slides.Charts.AxisPositionType.Top;
                    break;
                default:
                    Console.WriteLine("Invalid position value.");
                    return;
            }

            // Set axis position based on the requested axis type
            if (axisType == "category")
            {
                targetChart.Axes.HorizontalAxis.Position = position;
            }
            else if (axisType == "value")
            {
                targetChart.Axes.VerticalAxis.Position = position;
            }
            else
            {
                Console.WriteLine("Invalid axis type. Use 'category' or 'value'.");
                return;
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}