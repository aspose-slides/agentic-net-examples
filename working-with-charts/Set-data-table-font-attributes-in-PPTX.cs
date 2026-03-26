using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Enable the data table for the chart
                chart.HasDataTable = true;

                // Configure font attributes for the data table
                IChartTextFormat tableTextFormat = chart.ChartDataTable.TextFormat;
                // Set font height (size) in points
                tableTextFormat.PortionFormat.FontHeight = 14f;
                // Set font to bold
                tableTextFormat.PortionFormat.FontBold = NullableBool.True;
                // Set font to italic
                tableTextFormat.PortionFormat.FontItalic = NullableBool.True;
                // Set underline style
                tableTextFormat.PortionFormat.FontUnderline = TextUnderlineType.Single;
                // Set typeface (Latin font)
                tableTextFormat.PortionFormat.LatinFont = new FontData("Arial");

                // Save the presentation
                pres.Save("ChartDataTableFontAttributes.pptx", SaveFormat.Pptx);
            }
        }
    }
}