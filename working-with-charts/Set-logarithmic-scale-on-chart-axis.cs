using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set chart title (optional)
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Logarithmic Scale Example");

            // Configure the vertical axis to use a logarithmic scale
            IAxis verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.IsLogarithmic = true;
            // Set the logarithmic base (default is 10)
            verticalAxis.LogBase = 10.0;

            // Save the presentation and handle unsupported format exception
            try
            {
                pres.Save("LogarithmicChart.pptx", SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported format: " + ex.Message);
            }
        }
    }
}