using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ValidateChartLayout.pptx";

        // Create a new presentation
        using (var pres = new Aspose.Slides.Presentation())
        {
            var slide = pres.Slides[0];

            // Add a chart to the slide
            var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

            // Calculate actual layout values
            chart.ValidateChartLayout();

            // Validate that actual dimensions are greater than zero before manual adjustments
            if (chart.PlotArea.ActualWidth > 0 && chart.PlotArea.ActualHeight > 0)
            {
                // Apply manual layout adjustments
                chart.PlotArea.AsILayoutable.X = 0.1f;
                chart.PlotArea.AsILayoutable.Y = 0.1f;
                chart.PlotArea.AsILayoutable.Width = 0.8f;
                chart.PlotArea.AsILayoutable.Height = 0.8f;
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}