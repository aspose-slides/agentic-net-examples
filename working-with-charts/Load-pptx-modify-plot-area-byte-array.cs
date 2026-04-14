using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation file
            string inputPath = "input.pptx";
            byte[] inputBytes;

            // Check if the input file exists
            if (File.Exists(inputPath))
            {
                inputBytes = File.ReadAllBytes(inputPath);
            }
            else
            {
                // Input file does not exist
                return;
            }

            // Load presentation from byte array using PresentationFactory
            Aspose.Slides.PresentationFactory factory = new Aspose.Slides.PresentationFactory();
            Aspose.Slides.IPresentation presentation;
            try
            {
                presentation = factory.ReadPresentation(inputBytes);
            }
            catch (Exception)
            {
                // Format not supported
                return;
            }

            // Modify the plot area of the first chart found
            if (presentation.Slides.Count > 0)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    Aspose.Slides.Charts.IChart chart = slide.Shapes[i] as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        // Set new dimensions (as fractions of the chart size)
                        chart.PlotArea.Height = 0.8f;
                        chart.PlotArea.Width = 0.8f;
                        // Optionally adjust position
                        chart.PlotArea.X = 0.1f;
                        chart.PlotArea.Y = 0.1f;
                        break;
                    }
                }
            }

            // Save the modified presentation to a memory stream and obtain the byte array
            byte[] outputBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    presentation.Save(ms, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception)
                {
                    // Handle save exception if needed
                }
                outputBytes = ms.ToArray();
            }

            // Optionally write the updated presentation to a file
            string outputPath = "output.pptx";
            File.WriteAllBytes(outputPath, outputBytes);
        }
    }
}