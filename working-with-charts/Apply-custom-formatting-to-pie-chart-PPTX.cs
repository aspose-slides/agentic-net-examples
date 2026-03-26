using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        // Customize default data label format
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

        // Customize the first data label
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

        // Set explosion for the second slice
        chart.ChartData.Series[0].DataPoints[1].Explosion = 20;

        // Save the presentation
        string outputPath = "CustomPieChart.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}