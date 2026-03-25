using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ConfigureChartFontAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Set chart title text
                chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");

                // Configure font attributes for the chart title
                chart.ChartTitle.TextFormat.PortionFormat.FontHeight = 24f; // Size
                chart.ChartTitle.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True; // Bold
                chart.ChartTitle.TextFormat.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True; // Italic
                chart.ChartTitle.TextFormat.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single; // Underline
                chart.ChartTitle.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial"); // Font family

                // Note: Font color for chart text is not directly supported via IChartPortionFormat.
                // If needed, color can be applied through other mechanisms such as shape fill.

                // Example: Configure font for horizontal axis title
                chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("X Axis");
                chart.Axes.HorizontalAxis.Title.TextFormat.PortionFormat.FontHeight = 18f;
                chart.Axes.HorizontalAxis.Title.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                chart.Axes.HorizontalAxis.Title.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Calibri");

                // Example: Configure font for vertical axis title
                chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Y Axis");
                chart.Axes.VerticalAxis.Title.TextFormat.PortionFormat.FontHeight = 18f;
                chart.Axes.VerticalAxis.Title.TextFormat.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                chart.Axes.VerticalAxis.Title.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Calibri");

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}