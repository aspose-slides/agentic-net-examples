using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 400, 300);
            // Set the chart background to a solid fill using a theme accent color
            chart.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;
            // Save the presentation
            presentation.Save("ChartBackgroundTheme.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Exception)
        {
            // Handle other exceptions
        }
    }
}