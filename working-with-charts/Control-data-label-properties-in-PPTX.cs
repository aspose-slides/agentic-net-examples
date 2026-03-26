using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data label properties
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

        // Save the presentation
        pres.Save("CustomizedDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}