using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Area, 50f, 50f, 500f, 400f);

            // Configure the vertical (value) axis to use a logarithmic scale
            chart.Axes.VerticalAxis.IsLogarithmic = true;
            // Optionally set the logarithmic base (default is 10)
            chart.Axes.VerticalAxis.LogBase = 10.0;

            // Save the presentation
            presentation.Save("LogarithmicAxisChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}