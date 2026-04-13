using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON file containing ink trace data
            string jsonFilePath = "inkData.json";

            // Verify that the JSON file exists
            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("Error: JSON file not found at path: " + jsonFilePath);
                return;
            }

            // Read and deserialize the JSON content.
            // Expected format: [[{ "X": 0.0, "Y": 0.0 }, ...], ...] (array of traces, each trace is an array of points)
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<List<PointF>> inkTraces = JsonSerializer.Deserialize<List<List<PointF>>>(jsonContent);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line shape that will act as a placeholder for the ink strokes
                // (Aspose.Slides does not provide a direct AddInk method)
                IShape inkShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50, 400, 0);

                // Cast to AutoShape to access line formatting
                IAutoShape autoInkShape = inkShape as IAutoShape;
                if (autoInkShape != null)
                {
                    // Configure the line to use a scribble sketch, which visually resembles ink
                    autoInkShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

                    // The following demonstrates how you might process the deserialized trace data.
                    // Direct assignment of trace points to an Ink shape is not exposed in the API,
                    // so this example only logs the points for illustration.
                    if (inkTraces != null)
                    {
                        int traceIndex = 0;
                        foreach (List<PointF> trace in inkTraces)
                        {
                            Console.WriteLine($"Trace {traceIndex}:");
                            foreach (PointF point in trace)
                            {
                                Console.WriteLine($"  Point X={point.X}, Y={point.Y}");
                            }
                            traceIndex++;
                        }
                    }
                }

                // Save the presentation
                try
                {
                    presentation.Save("Output.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}