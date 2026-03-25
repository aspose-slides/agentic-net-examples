using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartDataLabelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output file path
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ChartDataLabel.pptx");

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a bubble chart to the first slide
                Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);

                // Get the first series of the chart
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Enable data label values from workbook cells
                series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

                // Access the chart's embedded workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Create cells with label texts
                workbook.GetCell(0, "A10", "First Label");
                workbook.GetCell(0, "A11", "Second Label");
                workbook.GetCell(0, "A12", "Third Label");

                // Assign workbook cells to data labels
                series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "First Label");
                series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Second Label");
                series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Third Label");

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}