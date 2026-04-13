using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main(string[] args)
    {
        string presentationPath = "input.pptx";
        string jsonOutputPath = "ink_traces.json";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found: " + presentationPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
            {
                List<object> allTraces = new List<object>();

                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IInk inkShape = shape as IInk;
                        if (inkShape != null)
                        {
                            IInkTrace[] traces = inkShape.Traces;
                            foreach (IInkTrace trace in traces)
                            {
                                List<Dictionary<string, float>> pointsList = new List<Dictionary<string, float>>();
                                foreach (PointF point in trace.Points)
                                {
                                    Dictionary<string, float> pointDict = new Dictionary<string, float>();
                                    pointDict["X"] = point.X;
                                    pointDict["Y"] = point.Y;
                                    pointsList.Add(pointDict);
                                }
                                Dictionary<string, object> traceDict = new Dictionary<string, object>();
                                traceDict["Points"] = pointsList;
                                allTraces.Add(traceDict);
                            }
                        }
                    }
                }

                string jsonString = JsonSerializer.Serialize(allTraces, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonOutputPath, jsonString);
                Console.WriteLine("Ink trace data exported to " + jsonOutputPath);

                // Save the presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}