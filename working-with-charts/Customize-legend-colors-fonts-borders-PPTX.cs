using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomizeLegend
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation inside a using block to ensure proper disposal
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Assume the first shape on the first slide is a chart
                IChart chart = (IChart)presentation.Slides[0].Shapes[0];

                // ----- Customize Legend Appearance -----

                // Set legend position to the right side of the chart
                chart.Legend.Position = LegendPositionType.Right;

                // Adjust legend size and placement (optional)
                chart.Legend.Width = 0.2f;   // 20% of chart width
                chart.Legend.Height = 0.5f;  // 50% of chart height

                // Set legend fill color to light gray
                chart.Legend.Format.Fill.FillType = FillType.Solid;
                chart.Legend.Format.Fill.SolidFillColor.Color = System.Drawing.Color.LightGray;

                // Set legend border (line) style
                chart.Legend.Format.Line.FillFormat.FillType = FillType.Solid;
                chart.Legend.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.DarkGray;
                chart.Legend.Format.Line.Width = 1.5f; // line width in points

                // Customize legend text font
                chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;
                chart.Legend.TextFormat.PortionFormat.FontBold = NullableBool.True;
                chart.Legend.TextFormat.PortionFormat.FontItalic = NullableBool.False;
                chart.Legend.TextFormat.PortionFormat.FontUnderline = TextUnderlineType.None;

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}