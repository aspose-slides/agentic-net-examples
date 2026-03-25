using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Calculate actual layout values
        chart.ValidateChartLayout();

        // Access the plot area of the chart
        IChartPlotArea plotArea = chart.PlotArea;

        // Retrieve actual dimensions (in points)
        float actualX = plotArea.ActualX;
        float actualY = plotArea.ActualY;
        float actualWidth = plotArea.ActualWidth;
        float actualHeight = plotArea.ActualHeight;

        // Retrieve relative dimensions (fractions of the chart size)
        float relativeX = plotArea.X;
        float relativeY = plotArea.Y;
        float relativeWidth = plotArea.Width;
        float relativeHeight = plotArea.Height;

        // Retrieve formatting information
        IFormat format = plotArea.Format;

        // Output plot area properties
        Console.WriteLine("Plot Area Actual Position and Size (points):");
        Console.WriteLine($"  X = {actualX}, Y = {actualY}");
        Console.WriteLine($"  Width = {actualWidth}, Height = {actualHeight}");
        Console.WriteLine("Plot Area Relative Position and Size (fractions of chart):");
        Console.WriteLine($"  X = {relativeX}, Y = {relativeY}");
        Console.WriteLine($"  Width = {relativeWidth}, Height = {relativeHeight}");
        Console.WriteLine($"  Format Type: {format.GetType().Name}");

        // Save the presentation
        string outputPath = "ChartPlotAreaOverview.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}