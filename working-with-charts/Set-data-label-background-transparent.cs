using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a pie chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Set the data label background to transparent
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Format.Fill.SolidFillColor.Color = Color.Transparent;

        // Save the presentation
        try
        {
            presentation.Save("ChartWithTransparentLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            // Handle exceptions such as unsupported format
            // Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}