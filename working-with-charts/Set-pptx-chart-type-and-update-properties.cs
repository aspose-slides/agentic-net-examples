using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartTypeConfigurator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            try
            {
                // Ensure there is at least one slide
                ISlide slide = presentation.Slides[0];

                // Try to find an existing chart on the slide
                IChart chart = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    IShape shape = slide.Shapes[i];
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                // If no chart is found, add a new one with a default type
                if (chart == null)
                {
                    chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);
                }

                // Change the chart type to Pie
                chart.Type = ChartType.Pie;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            finally
            {
                // Release resources
                presentation.Dispose();
            }
        }
    }
}