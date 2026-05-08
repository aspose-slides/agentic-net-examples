using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input byte array for the presentation
            byte[] presentationData = null;

            // If a file path is provided, load the file into a byte array after checking existence
            if (args.Length > 0)
            {
                string inputPath = args[0];
                if (File.Exists(inputPath))
                {
                    presentationData = File.ReadAllBytes(inputPath);
                }
                else
                {
                    Console.WriteLine("Input file does not exist: " + inputPath);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Please provide the path to a PPTX file as the first argument.");
                return;
            }

            // Ensure we have data to work with
            if (presentationData == null || presentationData.Length == 0)
            {
                Console.WriteLine("Presentation data is empty.");
                return;
            }

            try
            {
                // Load presentation from byte array using PresentationFactory
                IPresentationFactory factory = PresentationFactory.Instance;
                IPresentation presentation = factory.ReadPresentation(presentationData);

                // Find the first chart on the first slide (if any)
                ISlide slide = presentation.Slides[0];
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    chart = shape as IChart;
                    if (chart != null)
                    {
                        break;
                    }
                }

                if (chart != null)
                {
                    // Modify the plot area: set new position and size as fractions of the chart dimensions
                    IChartPlotArea plotArea = chart.PlotArea;
                    plotArea.X = 0.1f; // 10% from left
                    plotArea.Y = 0.1f; // 10% from top
                    plotArea.Width = 0.8f; // 80% of chart width
                    plotArea.Height = 0.8f; // 80% of chart height
                }
                else
                {
                    Console.WriteLine("No chart found in the presentation.");
                }

                // Save the modified presentation to a memory stream
                using (MemoryStream outputStream = new MemoryStream())
                {
                    presentation.Save(outputStream, SaveFormat.Pptx);
                    byte[] updatedData = outputStream.ToArray();

                    // Optionally write the updated presentation to a file for verification
                    string outputPath = "updated_presentation.pptx";
                    File.WriteAllBytes(outputPath, updatedData);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}