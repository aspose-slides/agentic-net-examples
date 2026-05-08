using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideAxisLines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Hide the vertical axis line while keeping its labels visible
                Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                verticalAxis.IsVisible = true; // ensure labels stay visible

                // Hide the horizontal axis line while keeping its labels visible
                Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                horizontalAxis.IsVisible = true; // ensure labels stay visible

                // Save the presentation
                presentation.Save("HideAxisLines.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, web service errors)
                Console.WriteLine(ex.Message);
            }
        }
    }
}