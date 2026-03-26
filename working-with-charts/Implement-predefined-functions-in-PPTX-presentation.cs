using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Create a new presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                using (Presentation presentation = new Presentation())
                {
                    // Add a chart to the first slide
                    ISlide slide = presentation.Slides[0];
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding("Sample Chart Title");

                    // Set an external hyperlink on the chart title
                    chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            else
            {
                // Load the existing presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Ensure there is at least one slide
                    ISlide slide = presentation.Slides[0];

                    // Find the first chart on the slide (if any)
                    IChart chart = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IChart)
                        {
                            chart = (IChart)shape;
                            break;
                        }
                    }

                    // If no chart exists, add one
                    if (chart == null)
                    {
                        chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
                    }

                    // Ensure the chart has a title
                    chart.HasTitle = true;
                    if (chart.ChartTitle.TextFrameForOverriding == null)
                    {
                        chart.ChartTitle.AddTextFrameForOverriding("Sample Chart Title");
                    }

                    // Set an external hyperlink on the chart title
                    chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
    }
}