using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);
        chart.HasDataTable = true;

        // Set precision for the series values (e.g., two decimal places)
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Ensure data labels display values with the same precision
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.00";

        presentation.Save("PrecisionChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}