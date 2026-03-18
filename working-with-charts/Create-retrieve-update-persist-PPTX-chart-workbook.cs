using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide's shape collection
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 400f, 300f);

            // Get the chart's workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Index of the default worksheet
            int defaultWorksheetIndex = 0;

            // Set series names
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1");
            workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2");

            // Set category names
            workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1");
            workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2");
            workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3");

            // Populate data points for Series 1
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 20);
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 50);
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 30);

            // Populate data points for Series 2
            workbook.GetCell(defaultWorksheetIndex, 1, 2, 30);
            workbook.GetCell(defaultWorksheetIndex, 2, 2, 10);
            workbook.GetCell(defaultWorksheetIndex, 3, 2, 60);

            // Recalculate any formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            pres.Save("ChartWorkbookDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}