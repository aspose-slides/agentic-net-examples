using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace InkValidationExample
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
                    foreach (ISlide slide in pres.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            Ink inkShape = shape as Ink;
                            if (inkShape != null)
                            {
                                IInkTrace[] traces = inkShape.Traces;
                                foreach (IInkTrace trace in traces)
                                {
                                    if (trace.Points != null && trace.Points.Length < 10)
                                    {
                                        Console.WriteLine("Ink trace on slide {0} has fewer than 10 points.", slide.SlideNumber);
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation after validation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}