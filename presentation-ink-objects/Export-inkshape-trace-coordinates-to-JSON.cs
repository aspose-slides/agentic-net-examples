using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace ExportInkTraces
{
    public class PointData
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class TraceInfo
    {
        public int SlideIndex { get; set; }
        public int ShapeIndex { get; set; }
        public int TraceIndex { get; set; }
        public List<PointData> Points { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string jsonOutputPath = "ink_traces.json";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<TraceInfo> allTraces = new List<TraceInfo>();

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            if (shape is Ink inkShape)
                            {
                                IInkTrace[] traces = inkShape.Traces;
                                for (int traceIndex = 0; traceIndex < traces.Length; traceIndex++)
                                {
                                    IInkTrace trace = traces[traceIndex];
                                    System.Drawing.PointF[] points = trace.Points;
                                    List<PointData> pointList = new List<PointData>();
                                    for (int p = 0; p < points.Length; p++)
                                    {
                                        PointData pointData = new PointData();
                                        pointData.X = points[p].X;
                                        pointData.Y = points[p].Y;
                                        pointList.Add(pointData);
                                    }

                                    TraceInfo traceInfo = new TraceInfo();
                                    traceInfo.SlideIndex = slideIndex;
                                    traceInfo.ShapeIndex = shapeIndex;
                                    traceInfo.TraceIndex = traceIndex;
                                    traceInfo.Points = pointList;
                                    allTraces.Add(traceInfo);
                                }
                            }
                        }
                    }

                    string jsonString = JsonSerializer.Serialize(allTraces, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonOutputPath, jsonString);
                    Console.WriteLine("Ink trace data exported to " + jsonOutputPath);

                    // Save presentation before exit
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (System.Net.WebException)
            {
                // External URL or web service error
                Console.WriteLine("Failed to access external resource.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}