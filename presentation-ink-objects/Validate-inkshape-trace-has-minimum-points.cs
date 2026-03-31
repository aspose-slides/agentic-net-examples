using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace AsposeSlidesInkValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                using (var presentation = new Presentation(inputPath))
                {
                    foreach (var slide in presentation.Slides)
                    {
                        foreach (var shape in slide.Shapes)
                        {
                            if (shape is Ink inkShape)
                            {
                                var traces = inkShape.Traces;
                                var allTracesValid = true;

                                foreach (var trace in traces)
                                {
                                    if (trace.Points.Length < 10)
                                    {
                                        allTracesValid = false;
                                        break;
                                    }
                                }

                                if (!allTracesValid)
                                {
                                    Console.WriteLine($"Ink shape on slide {slide.SlideNumber} contains a trace with fewer than 10 points.");
                                    // Optionally handle invalid ink shape here (e.g., remove or skip)
                                }
                            }
                        }
                    }

                    // Save the presentation after validation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}