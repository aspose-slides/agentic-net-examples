using System;
using System.Drawing;
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

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 300f);

            // Customize plot area layout
            chart.PlotArea.AsILayoutable.X = 0.1f;
            chart.PlotArea.AsILayoutable.Y = 0.1f;
            chart.PlotArea.AsILayoutable.Width = 0.8f;
            chart.PlotArea.AsILayoutable.Height = 0.8f;
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

            // Set fill color of the plot area
            chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

            // Save the presentation
            presentation.Save("CustomizedPlotArea.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}