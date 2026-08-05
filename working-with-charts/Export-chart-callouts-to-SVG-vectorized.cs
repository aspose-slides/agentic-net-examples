// -----------------------------------------------------------------------------
// Example: Export chart callouts to SVG vectorized using C#
//
// Description:
// Demonstrates how to add a pie chart with data label callouts to a PowerPoint
// slide and export the chart as a vectorized SVG file using Aspose.Slides for .NET.
// The example loads an existing presentation, inserts a chart, enables callout
// labels, writes the chart to SVG with text vectorization, and saves the updated
// presentation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, SVG, Vectorized, Chart, Callouts, Export,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Generate SVG representations of PowerPoint charts with callout labels.
// - Automate conversion of chart visuals to scalable vector graphics.
// - Integrate chart export functionality into .NET applications.
// - Validate and process PPTX files programmatically.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputSvgPath = "chart.svg";
        string outputPresPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 300f);
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            using (FileStream fs = new FileStream(outputSvgPath, FileMode.Create))
            {
                Aspose.Slides.Export.SVGOptions options = new Aspose.Slides.Export.SVGOptions();
                options.VectorizeText = true;
                chart.WriteAsSvg(fs, options);
            }

            pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL)
        }
    }
}
