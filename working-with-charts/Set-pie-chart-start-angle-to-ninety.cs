using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();
            // Access the first slide
            ISlide slide = presentation.Slides[0];
            // Add a pie chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50f, 50f, 400f, 400f);
            // Set the start angle of the first slice to 90 degrees
            chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 90;
            // Save the presentation
            try
            {
                presentation.Save("PieChart_StartAngle.pptx", SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported or other save error
            }
        }
    }
}