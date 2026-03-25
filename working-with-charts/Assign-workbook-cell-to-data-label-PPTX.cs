using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found: " + inputPath);
                return;
            }

            // Load existing presentation
            Presentation presentation = new Presentation(inputPath);

            // Add a Bubble chart to the first slide
            IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Access the first series
            IChartSeries series = chart.ChartData.Series[0];

            // Enable data labels to show values from workbook cells
            series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

            // Get the workbook associated with the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Create cells with label texts
            workbook.GetCell(0, "A10", "Label 0");
            workbook.GetCell(0, "A11", "Label 1");
            workbook.GetCell(0, "A12", "Label 2");

            // Assign workbook cells to data labels
            series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0");
            series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1");
            series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2");

            // Save the presentation
            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}