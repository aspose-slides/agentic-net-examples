using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DataLabelCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 500f, 400f);

            // Customize data label formatting
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = false;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = "; ";

            // Save the presentation
            pres.Save("CustomDataLabels.pptx", SaveFormat.Pptx);
        }
    }
}