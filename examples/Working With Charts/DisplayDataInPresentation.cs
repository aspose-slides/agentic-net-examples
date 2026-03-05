using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn,
            50, 50, 500, 400);

        // Enable display of values, percentages, and category names for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;

        // Save the presentation
        presentation.Save("DisplayData.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}