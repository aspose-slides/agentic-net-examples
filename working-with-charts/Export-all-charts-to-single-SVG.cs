// -----------------------------------------------------------------------------
// Example: Export all charts to a single SVG using C#
//
// Description:
// Demonstrates how to extract every chart from a PowerPoint presentation
// and combine them into one SVG file using Aspose.Slides for .NET. The example
// loads a PPTX, iterates through all slides and shapes, writes each chart as
// SVG markup, and wraps the output in a single SVG root element. This pattern
// is useful for creating composite vector graphics from multiple charts.
//
// Keywords:
// C#, Aspose.Slides, PPTX, PowerPoint, SVG, Export, Charts, Single SVG,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Consolidate multiple chart visualizations into a single SVG for web or
//   documentation purposes.
// - Automate extraction of chart graphics from presentations in .NET tools.
// - Generate vector‑based assets from PowerPoint files for further processing.
// - Validate chart rendering in automated CI pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportChartsToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputSvgPath = "charts.svg";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Save presentation before exit as required
                    pres.Save(inputPath, SaveFormat.Pptx);

                    using (FileStream outStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                    {
                        // Write SVG root element
                        byte[] headerBytes = Encoding.UTF8.GetBytes("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n");
                        outStream.Write(headerBytes, 0, headerBytes.Length);

                        foreach (ISlide slide in pres.Slides)
                        {
                            foreach (IShape shape in slide.Shapes)
                            {
                                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                                if (chart != null)
                                {
                                    using (MemoryStream chartStream = new MemoryStream())
                                    {
                                        chart.WriteAsSvg(chartStream);
                                        chartStream.Position = 0;
                                        byte[] chartBytes = chartStream.ToArray();
                                        outStream.Write(chartBytes, 0, chartBytes.Length);
                                        byte[] newlineBytes = Encoding.UTF8.GetBytes("\n");
                                        outStream.Write(newlineBytes, 0, newlineBytes.Length);
                                    }
                                }
                            }
                        }

                        // Close SVG root element
                        byte[] footerBytes = Encoding.UTF8.GetBytes("</svg>");
                        outStream.Write(footerBytes, 0, footerBytes.Length);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
