using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);
        // Set the font size of the third legend entry (index 2) to 10 points
        Aspose.Slides.Charts.ILegendEntryProperties entry = chart.Legend.Entries[2];
        entry.TextFormat.PortionFormat.FontHeight = 10f;
        // Save the presentation
        presentation.Save("LegendFontSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        presentation.Dispose();
    }
}