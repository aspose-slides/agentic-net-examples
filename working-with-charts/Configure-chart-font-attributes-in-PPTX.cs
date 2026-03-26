using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Set font family for the chart text
            chart.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");

            // Set font size (height) for the chart text
            chart.TextFormat.PortionFormat.FontHeight = 14f;

            // Set font style: bold and italic
            chart.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            chart.TextFormat.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;

            // Set underline style
            chart.TextFormat.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;

            // Set font color
            chart.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;

            // Optionally show values on the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Save the presentation
            presentation.Save("ChartWithCustomFont.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}