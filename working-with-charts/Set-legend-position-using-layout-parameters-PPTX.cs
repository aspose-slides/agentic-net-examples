using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Set custom legend position and size (fractions of chart dimensions)
        chart.Legend.X = 0.7f;      // Legend X position
        chart.Legend.Y = 0.1f;      // Legend Y position
        chart.Legend.Width = 0.2f; // Legend width
        chart.Legend.Height = 0.2f; // Legend height

        // Save the presentation
        presentation.Save("ChartLegendPosition.pptx", SaveFormat.Pptx);
    }
}