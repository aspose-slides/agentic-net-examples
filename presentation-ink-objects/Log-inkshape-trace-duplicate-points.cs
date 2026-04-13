using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace InkTraceDuplicateLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an Ink object
                            if (shape is Aspose.Slides.Ink.Ink)
                            {
                                Aspose.Slides.Ink.Ink inkShape = (Aspose.Slides.Ink.Ink)shape;
                                IInkTrace[] traces = inkShape.Traces;

                                // Process each trace
                                for (int traceIndex = 0; traceIndex < traces.Length; traceIndex++)
                                {
                                    IInkTrace trace = traces[traceIndex];
                                    PointF[] points = trace.Points;

                                    // Use a hash set to detect duplicate points
                                    HashSet<string> pointSet = new HashSet<string>();
                                    List<PointF> duplicatePoints = new List<PointF>();

                                    for (int pointIndex = 0; pointIndex < points.Length; pointIndex++)
                                    {
                                        PointF pt = points[pointIndex];
                                        string key = pt.X.ToString("R") + "_" + pt.Y.ToString("R");

                                        if (pointSet.Contains(key))
                                        {
                                            duplicatePoints.Add(pt);
                                        }
                                        else
                                        {
                                            pointSet.Add(key);
                                        }
                                    }

                                    // Log duplicates if any
                                    if (duplicatePoints.Count > 0)
                                    {
                                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1} (Ink), Trace {traceIndex + 1} contains duplicate points:");
                                        foreach (PointF dup in duplicatePoints)
                                        {
                                            Console.WriteLine($"    Duplicate Point: X={dup.X}, Y={dup.Y}");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for this operation.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}