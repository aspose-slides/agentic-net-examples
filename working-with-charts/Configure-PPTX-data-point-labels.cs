using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace DataLabelCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 500, 400);

            // Enable leader lines for the default data label format
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

            // Customize the first data label
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = "; ";

            // Show percentage for all data labels in the series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Save the presentation
            presentation.Save("CustomizedDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}