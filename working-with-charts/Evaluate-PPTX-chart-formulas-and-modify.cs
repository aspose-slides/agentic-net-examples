using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Get the chart's data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Populate cells with values
            Aspose.Slides.Charts.IChartDataCell cellA1 = workbook.GetCell(0, "A1", 2);
            Aspose.Slides.Charts.IChartDataCell cellA2 = workbook.GetCell(0, "A2", 3);

            // Set a formula in cell A3 that sums A1 and A2
            Aspose.Slides.Charts.IChartDataCell cellA3 = workbook.GetCell(0, "A3");
            cellA3.Formula = "A1+A2";

            // Calculate all formulas in the workbook
            workbook.CalculateFormulas();

            // Save the presentation
            string outPath = Path.Combine(Directory.GetCurrentDirectory(), "ChartFormulas_out.pptx");
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}