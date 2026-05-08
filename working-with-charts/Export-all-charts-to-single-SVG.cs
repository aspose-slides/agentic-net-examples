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
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Save presentation before exit as required
                    pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    using (FileStream outStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                    {
                        // Write SVG root element
                        byte[] headerBytes = Encoding.UTF8.GetBytes("<svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">\n");
                        outStream.Write(headerBytes, 0, headerBytes.Length);

                        foreach (Aspose.Slides.ISlide slide in pres.Slides)
                        {
                            foreach (Aspose.Slides.IShape shape in slide.Shapes)
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