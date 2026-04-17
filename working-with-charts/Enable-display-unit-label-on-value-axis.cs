using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Set the vertical axis display unit to Millions (enables display unit label)
        chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

        // Save the presentation
        try
        {
            presentation.Save("DisplayUnitLabel.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other errors
        }
    }
}