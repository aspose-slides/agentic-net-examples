using System;

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
            Aspose.Slides.Charts.ChartType.Pie,
            0f, 0f, 500f, 500f);

        // Enable leader lines for data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

        // Customize the first data label
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowPercentage = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

        // Save the presentation
        pres.Save("CustomDataLabelChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}