// -----------------------------------------------------------------------------
// Example: Load pptx modify plot area byte array using C#
//
// Description:
// Demonstrates how to load a PPTX presentation from a byte array, locate the
// first chart on the first slide, modify its plot area dimensions and position,
// and then save the updated presentation back to a byte array (and optionally
// to a file) using Aspose.Slides for .NET. This example illustrates the typical
// steps for binary presentation manipulation in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Byte Array, Modify, Plot Area,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Load a PPTX from memory for processing without file system dependency.
// - Adjust chart plot area programmatically in bulk or automated workflows.
// - Save modified presentations back to byte arrays for further transmission or storage.
// - Integrate PPTX chart adjustments into .NET tools or services.
// -----------------------------------------------------------------------------
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
