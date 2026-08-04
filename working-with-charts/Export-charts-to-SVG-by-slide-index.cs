// -----------------------------------------------------------------------------
// Example: Export charts to SVG by slide index using C#
//
// Description:
// Demonstrates how to export only chart objects from each slide to SVG files 
// using C# and Aspose.Slides for .NET. The example loads a PowerPoint file, 
// iterates through its slides, extracts chart shapes, and writes each chart as 
// an individual SVG file named by slide and chart index. The original 
// presentation is saved unchanged. This pattern helps automate chart extraction 
// for reporting, analysis, or web publishing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, Charts, Slide, 
// Index, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of charts from PPTX files as SVG images.
// - Build C# tools for PowerPoint presentation processing focused on chart data.
// - Generate SVG assets for web or documentation from PowerPoint charts.
// - Validate and transform chart visuals before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string presentationPath = "input.pptx";

        // Verify that the file exists
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(presentationPath);

            // Iterate through each slide and export its charts as SVG
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                int chartIndex = 0;

                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart chart)
                    {
                        string svgFilePath = $"slide_{i}_chart_{chartIndex}.svg";

                        using (FileStream svgStream = File.Create(svgFilePath))
                        {
                            chart.WriteAsSvg(svgStream);
                        }

                        chartIndex++;
                    }
                }
            }

            // Save the (unchanged) presentation before exiting
            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
