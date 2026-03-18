using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Enable and set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sales Report");

                // Configure chart title font attributes
                chart.ChartTitle.TextFormat.PortionFormat.FontHeight = 24f;
                chart.ChartTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;
                chart.ChartTitle.TextFormat.PortionFormat.FontItalic = NullableBool.False;
                chart.ChartTitle.TextFormat.PortionFormat.FontUnderline = TextUnderlineType.None;
                chart.ChartTitle.TextFormat.PortionFormat.LatinFont = new FontData("Arial");
                chart.ChartTitle.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;

                // Configure legend font attributes
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;
                chart.Legend.TextFormat.PortionFormat.FontBold = NullableBool.False;
                chart.Legend.TextFormat.PortionFormat.LatinFont = new FontData("Calibri");
                chart.Legend.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                presentation.Save("ChartFontAttributes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}