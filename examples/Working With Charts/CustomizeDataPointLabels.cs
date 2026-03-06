using System;

namespace CustomDataLabelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Enable leader lines for the default data label format
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

            // Customize the first data label of the first series
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = ", ";

            // Save the presentation
            pres.Save("CustomDataLabels_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}