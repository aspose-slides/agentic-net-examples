using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartCalloutExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string presentationPath = "ChartCallout.pptx";
            string svgPath = "ChartCallout.svg";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a Pie chart
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

                // Enable data labels as callouts
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Save the presentation
                presentation.Save(presentationPath, SaveFormat.Pptx);

                // Export the first slide to SVG with vector fidelity
                using (FileStream svgStream = File.Create(svgPath))
                {
                    SVGOptions svgOptions = new SVGOptions();
                    svgOptions.VectorizeText = true; // Preserve text as vectors
                    slide.WriteAsSvg(svgStream, svgOptions);
                }

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}