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
            // Input presentation path
            string inputPath = "input.pptx";
            // Output SVG file path
            string outputSvgPath = "charts_combined.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Ensure the presentation is saved before exiting (no modifications made)
                    pres.Save(inputPath, SaveFormat.Pptx);

                    // StringBuilder to accumulate SVG fragments
                    StringBuilder svgBuilder = new StringBuilder();
                    // Begin the combined SVG document
                    svgBuilder.AppendLine("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">");

                    // Iterate through all slides and shapes to find charts
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                // Export each chart to SVG using a memory stream
                                using (MemoryStream chartStream = new MemoryStream())
                                {
                                    chart.WriteAsSvg(chartStream);
                                    chartStream.Position = 0;
                                    using (StreamReader reader = new StreamReader(chartStream))
                                    {
                                        string chartSvg = reader.ReadToEnd();

                                        // Extract inner SVG content (exclude outer <svg> tags)
                                        int startTagEnd = chartSvg.IndexOf('>');
                                        int endTagStart = chartSvg.LastIndexOf("</svg>");
                                        if (startTagEnd > -1 && endTagStart > startTagEnd)
                                        {
                                            string innerContent = chartSvg.Substring(startTagEnd + 1, endTagStart - (startTagEnd + 1));
                                            svgBuilder.AppendLine(innerContent);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Close the combined SVG document
                    svgBuilder.AppendLine("</svg>");

                    // Write the combined SVG to file
                    File.WriteAllText(outputSvgPath, svgBuilder.ToString());
                    Console.WriteLine("All charts have been exported to: " + outputSvgPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}