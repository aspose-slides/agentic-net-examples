using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Presentation pres = new Presentation("input.pptx");

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Find the first chart on the slide
            IChart chart = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IChart)
                {
                    chart = (IChart)shape;
                    break;
                }
            }

            if (chart == null)
                throw new InvalidOperationException("No chart found on the first slide.");

            // Get the embedded workbook that holds the chart data
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Index of the default worksheet (usually 0)
            int defaultWorksheetIndex = 0;

            // Update a specific cell value (row 1, column 1) to a new numeric value
            // The GetCell method with a value parameter creates/updates the cell
            IChartDataCell updatedCell = workbook.GetCell(defaultWorksheetIndex, 1, 1, 75.0);

            // Recalculate any formulas in the workbook to reflect the change
            workbook.CalculateFormulas();

            // Save the modified presentation
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}