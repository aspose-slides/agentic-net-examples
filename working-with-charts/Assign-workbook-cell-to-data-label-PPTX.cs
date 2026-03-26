using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataLabelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartDataLabel.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Bubble chart to the first slide
            IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Enable showing label values from workbook cells
            series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

            // Access the chart's embedded workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Create cells with label texts
            IChartDataCell cellA10 = workbook.GetCell(0, "A10", "Label 0");
            IChartDataCell cellA11 = workbook.GetCell(0, "A11", "Label 1");
            IChartDataCell cellA12 = workbook.GetCell(0, "A12", "Label 2");

            // Assign workbook cells to data labels
            series.Labels[0].ValueFromCell = cellA10;
            series.Labels[1].ValueFromCell = cellA11;
            series.Labels[2].ValueFromCell = cellA12;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}