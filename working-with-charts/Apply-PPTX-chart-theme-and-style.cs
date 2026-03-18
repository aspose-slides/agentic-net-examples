using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Theme;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation("input.pptx"))
            {
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Access the chart's override theme manager
                IOverrideTheme chartOverride = chart.ThemeManager.OverrideTheme;

                // Initialize override theme sections from the inherited theme
                chartOverride.InitColorSchemeFromInherited();
                chartOverride.InitFontSchemeFromInherited();
                chartOverride.InitFormatSchemeFromInherited();

                // Example modification: change the first fill style color
                chartOverride.FormatScheme.FillStyles[0].FillType = Aspose.Slides.FillType.Solid;
                chartOverride.FormatScheme.FillStyles[0].SolidFillColor.Color = Color.Blue;

                // Save the presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}