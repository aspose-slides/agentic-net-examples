using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide (adjust index if needed)
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Locate the first chart on the slide
                Aspose.Slides.Charts.IChart chart = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.Charts.IChart)
                    {
                        chart = (Aspose.Slides.Charts.IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("Error: No chart found on the first slide.");
                    return;
                }

                // Ensure the chart is a doughnut type
                if (!Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypeDoughnut(chart.Type))
                {
                    Console.WriteLine("Error: The chart is not a doughnut chart.");
                    return;
                }

                // -----------------------------------------------------------------
                // Modify doughnut hole size (percentage of plot area, 10-90)
                // -----------------------------------------------------------------
                chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

                // -----------------------------------------------------------------
                // Change the fill color of the first series
                // -----------------------------------------------------------------
                chart.ChartData.Series[0].Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                chart.ChartData.Series[0].Format.Fill.SolidFillColor.Color = Color.Blue;

                // -----------------------------------------------------------------
                // Add a new data point to the first series
                // -----------------------------------------------------------------
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;
                int newColumnIndex = chart.ChartData.Series[0].DataPoints.Count + 1; // Next column
                Aspose.Slides.Charts.IChartDataCell newCell = workbook.GetCell(defaultWorksheetIndex, 1, newColumnIndex, 25);
                Aspose.Slides.Charts.IChartDataPoint newPoint = chart.ChartData.Series[0].DataPoints.AddDataPointForDoughnutSeries(newCell);

                // Set fill color for the new data point
                newPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                newPoint.Format.Fill.SolidFillColor.Color = Color.Green;

                // -----------------------------------------------------------------
                // Save the modified presentation
                // -----------------------------------------------------------------
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
        }
    }
}