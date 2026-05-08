using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 400f, 300f);

        // Set the chart's background fill to a gradient
        chart.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

        // Configure gradient shape and direction
        chart.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        chart.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

        // Retrieve the presentation's theme color scheme
        Aspose.Slides.Theme.IColorScheme colorScheme = presentation.MasterTheme.ColorScheme;

        // Add gradient stops using theme accent colors
        chart.FillFormat.GradientFormat.GradientStops.Add(0f, colorScheme.Accent1.Color);
        chart.FillFormat.GradientFormat.GradientStops.Add(1f, colorScheme.Accent2.Color);

        // Save the presentation with handling for unsupported formats
        try
        {
            presentation.Save("ChartBackgroundGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}