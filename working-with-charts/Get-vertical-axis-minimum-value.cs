using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50, 50, 500, 400);

            // Validate chart layout to ensure axis values are calculated
            chart.ValidateChartLayout();

            // Optionally set a custom minimum value on the vertical axis
            chart.Axes.VerticalAxis.MinValue = 0;

            // Retrieve the vertical axis minimum value via MinValue property
            double minValue = chart.Axes.VerticalAxis.MinValue;

            // Output the retrieved minimum value
            Console.WriteLine("Vertical Axis Minimum Value: " + minValue);

            // Save the presentation
            string outPath = "OutputChart.pptx";
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}