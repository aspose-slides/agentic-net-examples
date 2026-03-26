using System;
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
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Customize data label settings
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

        // Save the presentation
        string outputPath = "ChartDataLabels.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}