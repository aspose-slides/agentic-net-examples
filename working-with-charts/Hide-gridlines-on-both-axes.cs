using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
        // Hide major gridlines on the horizontal axis
        chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        // Hide major gridlines on the vertical axis
        chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        // Save the presentation
        try
        {
            presentation.Save("HideGridlines.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle exceptions such as unsupported format
        }
    }
}