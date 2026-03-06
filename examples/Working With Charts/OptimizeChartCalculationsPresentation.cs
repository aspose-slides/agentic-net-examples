class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart without initializing sample data (faster calculation)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f, false);

        // Get the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Set formulas in cells
        workbook.GetCell(0, "B2").Formula = "5";
        workbook.GetCell(0, "B3").Formula = "10";
        workbook.GetCell(0, "B4").Formula = "B2+B3";

        // Calculate all formulas to update cell values
        workbook.CalculateFormulas();

        // Save the presentation
        presentation.Save("OptimizedChartCalculations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}