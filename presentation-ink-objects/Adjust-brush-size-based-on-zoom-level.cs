using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace AdjustInkBrushSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get current slide view zoom percentage (default 100)
                    int zoomPercent = pres.ViewProperties.SlideViewProperties.Scale;
                    float zoomFactor = zoomPercent / 100f;

                    // Iterate all slides
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];

                        // Iterate all shapes on the slide
                        for (int j = 0; j < slide.Shapes.Count; j++)
                        {
                            // Check if the shape is an Ink object
                            Ink inkShape = slide.Shapes[j] as Ink;
                            if (inkShape != null)
                            {
                                // Iterate all ink traces
                                IInkTrace[] traces = inkShape.Traces;
                                for (int k = 0; k < traces.Length; k++)
                                {
                                    IInkBrush brush = traces[k].Brush;
                                    // Adjust brush size based on zoom factor
                                    SizeF originalSize = brush.Size;
                                    SizeF newSize = new SizeF(originalSize.Width * zoomFactor, originalSize.Height * zoomFactor);
                                    brush.Size = newSize;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors if a URL was used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}