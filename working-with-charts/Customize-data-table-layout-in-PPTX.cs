using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartDataTableCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "Template.pptx";
            string outputPath = "CustomizedChart.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Add a bubble chart to the first slide
            IChart chart = (IChart)presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Enable data labels to show values from workbook cells
            series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

            // Get the workbook associated with the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Create cells in the workbook that will be used as data label values
            workbook.GetCell(0, 0, 0, "Label A");
            workbook.GetCell(0, 1, 0, "Label B");
            workbook.GetCell(0, 2, 0, "Label C");

            // Assign the workbook cells to the data labels of the series
            series.Labels[0].ValueFromCell = workbook.GetCell(0, 0, 0, "Label A");
            series.Labels[1].ValueFromCell = workbook.GetCell(0, 1, 0, "Label B");
            series.Labels[2].ValueFromCell = workbook.GetCell(0, 2, 0, "Label C");

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}