// -----------------------------------------------------------------------------
// Example: Add Custom Line Annotation to Chart in PowerPoint using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, inserts a
// clustered column chart, adds a red straight line as an annotation positioned
// over the chart's plot area, and saves the result as a PPTX file. It demonstrates
// how to programmatically annotate charts using Aspose.Slides for .NET.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart annotation, custom line, AddChart, AutoShape line
//
// Use Cases:
// - Highlight a specific value range within a chart.
// - Provide visual guidance or reference lines on a chart.
// - Automate the creation of annotated presentations for reporting.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace ChartAnnotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ChartWithAnnotation.pptx";

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    100f, 100f, 500f, 350f);

                // Calculate line position to place it vertically through the middle of the plot area
                float lineX = chart.PlotArea.ActualX + chart.PlotArea.ActualWidth / 2f - 1f; // slight offset for line thickness
                float lineY = chart.PlotArea.ActualY;
                float lineWidth = 2f; // line thickness
                float lineHeight = chart.PlotArea.ActualHeight;

                // Add a red line shape as an annotation
                Aspose.Slides.IAutoShape lineShape = presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line,
                    lineX, lineY, lineWidth, lineHeight);

                lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
