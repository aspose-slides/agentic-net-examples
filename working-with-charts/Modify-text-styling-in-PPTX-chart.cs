using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ChartFontAttributes_out.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Configure font attributes for the chart text
        chart.TextFormat.PortionFormat.FontHeight = 14f;
        chart.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        chart.TextFormat.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;

        // Show data label values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}