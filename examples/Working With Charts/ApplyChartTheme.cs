using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Access the chart's theme manager and initialize an override color scheme
        Aspose.Slides.Theme.IOverrideThemeManager themeManager = chart.ThemeManager;
        themeManager.OverrideTheme.InitColorScheme();

        // Save the presentation
        presentation.Save("ApplyChartTheme_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}