using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AdjustLegendFontSize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Assume the first shape is a chart; cast it accordingly
                Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

                // Adjust the legend font size
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            else
            {
                // Create a new presentation with a chart
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Adjust the legend font size
                chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

                // Save the new presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
        }
    }
}