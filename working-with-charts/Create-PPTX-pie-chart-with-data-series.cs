using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Show values on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Show category name on the first data label and set a custom separator
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

        // Explode the first slice for visual emphasis
        chart.ChartData.Series[0].Explosion = 10; // percentage of the pie diameter

        // Save the presentation to a PPTX file
        presentation.Save("PieChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}