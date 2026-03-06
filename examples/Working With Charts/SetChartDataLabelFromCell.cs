using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartDataLabelFromCell
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "SetChartDataLabelFromCell_out.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Enable data label values to be taken from workbook cells
            series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

            // Access the chart's data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Create cells that will hold the label texts
            workbook.GetCell(0, "A10", "Label 0");
            workbook.GetCell(0, "A11", "Label 1");
            workbook.GetCell(0, "A12", "Label 2");

            // Assign the workbook cells to the data labels
            series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0");
            series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1");
            series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2");

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}