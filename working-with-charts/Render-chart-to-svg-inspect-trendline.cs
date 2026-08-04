// -----------------------------------------------------------------------------
// Example: Render chart to SVG and inspect trendline using C#
//
// Description:
// Demonstrates how to create a clustered column chart, add various trendlines,
// save the presentation, export the first slide to SVG, and inspect the SVG
// content for trendline elements using Aspose.Slides for .NET. The example
// provides a complete console application workflow for chart rendering and
// SVG analysis.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Render, Chart, Trendline,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Generate a PPTX with chart trendlines.
// - Export a slide containing a chart to SVG format.
// - Programmatically verify that trendline elements are present in the SVG.
// - Automate PowerPoint chart processing and SVG validation in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Add various trend lines to the first series
        Aspose.Slides.Charts.ITrendline trendExp = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Exponential);
        trendExp.DisplayEquation = false;
        trendExp.DisplayRSquaredValue = false;

        Aspose.Slides.Charts.ITrendline trendLin = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Linear);
        trendLin.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        trendLin.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        Aspose.Slides.Charts.ITrendline trendLog = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Logarithmic);
        trendLog.AddTextFrameForOverriding("Logarithmic Trend");

        Aspose.Slides.Charts.ITrendline trendMA = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.MovingAverage);
        trendMA.Period = 3;
        trendMA.TrendlineName = "MA3";

        Aspose.Slides.Charts.ITrendline trendPoly = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Polynomial);
        trendPoly.Order = 2;
        trendPoly.Forward = 1;

        Aspose.Slides.Charts.ITrendline trendPower = chart.ChartData.Series[0].TrendLines.Add(
            Aspose.Slides.Charts.TrendlineType.Power);
        trendPower.Backward = 1;

        // Save the presentation
        string pptxPath = "TrendLinesPresentation.pptx";
        try
        {
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Export the first slide as SVG
        string svgPath = "Slide1.svg";
        try
        {
            using (FileStream svgStream = File.Create(svgPath))
            {
                presentation.Slides[0].WriteAsSvg(svgStream);
            }
        }
        catch (Exception)
        {
            // Handle SVG export exception
        }

        // Inspect the SVG XML for trend line elements
        try
        {
            string svgContent = File.ReadAllText(svgPath);
            if (svgContent.Contains("trendline"))
            {
                Console.WriteLine("Trend line elements found in SVG.");
            }
            else
            {
                Console.WriteLine("No trend line elements detected in SVG.");
            }
        }
        catch (Exception)
        {
            // Handle file read exception
        }

        // Clean up
        presentation.Dispose();
    }
}
