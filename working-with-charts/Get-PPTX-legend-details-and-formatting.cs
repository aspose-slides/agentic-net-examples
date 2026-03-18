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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Ensure the chart has a legend
            chart.HasLegend = true;

            // Set legend properties
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Right;
            chart.Legend.Overlay = false;
            chart.Legend.Height = 0.2f; // fraction of chart height
            chart.Legend.Width = 0.2f;  // fraction of chart width
            chart.Legend.X = 0.8f;      // fraction of chart width
            chart.Legend.Y = 0.0f;      // fraction of chart height

            // Set legend text formatting
            chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

            // Validate layout to obtain actual values
            chart.ValidateChartLayout();

            // Retrieve legend details
            Aspose.Slides.Charts.ILegend legend = chart.Legend;

            Console.WriteLine("Legend Details:");
            Console.WriteLine("Position: " + legend.Position);
            Console.WriteLine("Overlay: " + legend.Overlay);
            Console.WriteLine("Height (fraction): " + legend.Height);
            Console.WriteLine("Width (fraction): " + legend.Width);
            Console.WriteLine("X (fraction): " + legend.X);
            Console.WriteLine("Y (fraction): " + legend.Y);
            Console.WriteLine("Actual Height: " + legend.ActualHeight);
            Console.WriteLine("Actual Width: " + legend.ActualWidth);
            Console.WriteLine("Actual X: " + legend.ActualX);
            Console.WriteLine("Actual Y: " + legend.ActualY);
            Console.WriteLine("Font Height: " + legend.TextFormat.PortionFormat.FontHeight);

            // Save the presentation
            presentation.Save("ChartLegendDetails.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}