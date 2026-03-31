using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace RemoveInkTraces
{
    class Program
    {
        static void Main(string[] args)
        {
            const string inputPath = "input.pptx";
            const string outputPath = "output.pptx";
            const int pointThreshold = 100; // remove traces with more than this number of points

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Collect shapes to remove to avoid modifying collection during iteration
                        var shapesToRemove = new System.Collections.Generic.List<IShape>();

                        foreach (IShape shape in slide.Shapes)
                        {
                            // Identify Ink shapes using the correct Ink class
                            Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                            if (inkShape != null)
                            {
                                bool removeShape = false;
                                foreach (IInkTrace trace in inkShape.Traces)
                                {
                                    if (trace.Points != null && trace.Points.Length > pointThreshold)
                                    {
                                        removeShape = true;
                                        break;
                                    }
                                }

                                if (removeShape)
                                {
                                    shapesToRemove.Add(shape);
                                }
                            }
                        }

                        // Remove identified Ink shapes
                        foreach (IShape shape in shapesToRemove)
                        {
                            slide.Shapes.Remove(shape);
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
                // Handle other exceptions (e.g., network errors if URLs were used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}