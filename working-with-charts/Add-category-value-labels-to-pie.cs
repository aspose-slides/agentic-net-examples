using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

        // Customize data labels to show both category name and value with a separator
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Separator = " - ";

        // Save the presentation
        pres.Save("CustomDataLabelPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}