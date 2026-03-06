using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;

public class Program
{
    public static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

        // Access the chart's theme manager and obtain the overriding theme
        Aspose.Slides.Theme.IOverrideTheme overrideTheme = chart.ThemeManager.OverrideTheme;

        // Initialize the format scheme for overriding
        overrideTheme.InitFormatScheme();

        // Get the format scheme from the overriding theme
        Aspose.Slides.Theme.IFormatScheme formatScheme = overrideTheme.FormatScheme;

        // Modify the first fill style in the format scheme (e.g., set solid blue fill)
        Aspose.Slides.IFillFormat fillFormat = formatScheme.FillStyles[0];
        fillFormat.FillType = Aspose.Slides.FillType.Solid;
        fillFormat.SolidFillColor.Color = Color.Blue;

        // Save the presentation
        pres.Save("ChartWithTheme.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}