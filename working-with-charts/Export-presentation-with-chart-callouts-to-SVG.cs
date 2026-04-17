using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartCalloutToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file paths
            string outputPptxPath = "ChartCalloutPresentation.pptx";
            string outputSvgPath = "Slide1.svg";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a Pie chart with callout data labels
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Enable value display and callout for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Save the presentation to PPTX
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Export the first slide to SVG with vector fidelity
                using (FileStream svgStream = File.Create(outputSvgPath))
                {
                    Aspose.Slides.Export.SVGOptions svgOptions = new Aspose.Slides.Export.SVGOptions();
                    svgOptions.VectorizeText = true; // Preserve text as vectors
                    slide.WriteAsSvg(svgStream, svgOptions);
                }

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}