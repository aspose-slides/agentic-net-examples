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

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Calculate layout to obtain actual values
        chart.ValidateChartLayout();

        // Access the plot area
        IChartPlotArea plotArea = chart.PlotArea;

        // Actual position and size (in points)
        float actualX = plotArea.ActualX;
        float actualY = plotArea.ActualY;
        float actualWidth = plotArea.ActualWidth;
        float actualHeight = plotArea.ActualHeight;

        // Relative position and size (fractions of the chart dimensions)
        float relativeX = plotArea.X;
        float relativeY = plotArea.Y;
        float relativeWidth = plotArea.Width;
        float relativeHeight = plotArea.Height;

        // Output the plot area properties
        Console.WriteLine("Plot Area Actual Position and Size:");
        Console.WriteLine($"  X = {actualX}, Y = {actualY}");
        Console.WriteLine($"  Width = {actualWidth}, Height = {actualHeight}");
        Console.WriteLine("Plot Area Relative (fraction) Position and Size:");
        Console.WriteLine($"  X = {relativeX}, Y = {relativeY}");
        Console.WriteLine($"  Width = {relativeWidth}, Height = {relativeHeight}");

        // Access formatting information (read‑only)
        IFormat format = plotArea.Format;
        // Example: you could inspect format.FillFormat.FillType here if needed

        // Save the presentation
        string outputPath = "ChartPlotAreaOverview.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}