using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 400);

        // Set the start angle of the first slice to 90 degrees
        chart.ChartData.Series[0].ParentSeriesGroup.FirstSliceAngle = 90;

        // Save the presentation
        presentation.Save("PieChart_StartAngle.pptx", SaveFormat.Pptx);
    }
}