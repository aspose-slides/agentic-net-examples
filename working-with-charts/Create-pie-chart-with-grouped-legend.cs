using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 400f);

        // Customize legend layout
        chart.Legend.X = 460f;
        chart.Legend.Y = 50f;
        chart.Legend.Width = 150f;
        chart.Legend.Height = 400f;

        // Customize a slice (explosion) to illustrate grouping by category
        chart.ChartData.Series[0].DataPoints[0].Explosion = 20;

        // Save the presentation
        pres.Save("CustomPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}