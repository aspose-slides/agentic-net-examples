using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetDataLabelFromCellExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Access the embedded workbook of the chart
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Get a cell (B2) from the first worksheet and set its value
            IChartDataCell labelCell = workbook.GetCell(0, "B2");
            labelCell.Value = "Label from cell";

            // Access the first series and its first data point
            IChartDataPoint dataPoint = chart.ChartData.Series[0].DataPoints[0];

            // Enable showing label value from cell
            dataPoint.Label.DataLabelFormat.ShowLabelValueFromCell = true;

            // Assign the workbook cell to the data label
            dataPoint.Label.ValueFromCell = labelCell;

            // Save the presentation
            presentation.Save("SetDataLabelFromCell.pptx", SaveFormat.Pptx);
        }
    }
}