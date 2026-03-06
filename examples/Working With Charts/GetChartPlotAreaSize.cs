using System;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Assume the first shape is a chart
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.Charts.Chart chart = shape as Aspose.Slides.Charts.Chart;

        if (chart != null)
        {
            // Validate layout to obtain actual dimensions
            chart.ValidateChartLayout();

            // Get the plot area
            Aspose.Slides.Charts.IChartPlotArea plotArea = chart.PlotArea;

            // Retrieve actual width and height
            float actualWidth = plotArea.ActualWidth;
            float actualHeight = plotArea.ActualHeight;

            // Output the dimensions
            Console.WriteLine("Plot Area Actual Width: " + actualWidth);
            Console.WriteLine("Plot Area Actual Height: " + actualHeight);
        }

        // Save the presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}