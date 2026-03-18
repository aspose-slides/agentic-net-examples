using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Adjust plot area dimensions (fraction of chart size)
            chart.PlotArea.AsILayoutable.X = 0.1f;
            chart.PlotArea.AsILayoutable.Y = 0.1f;
            chart.PlotArea.AsILayoutable.Width = 0.8f;
            chart.PlotArea.AsILayoutable.Height = 0.8f;

            // Set plot area background fill
            chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

            // Position axis tick labels
            chart.Axes.VerticalAxis.TickLabelPosition = Aspose.Slides.Charts.TickLabelPositionType.Low;
            chart.Axes.HorizontalAxis.TickLabelPosition = Aspose.Slides.Charts.TickLabelPositionType.NextTo;

            // Save the presentation
            presentation.Save("ModifiedChartPlotArea.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}