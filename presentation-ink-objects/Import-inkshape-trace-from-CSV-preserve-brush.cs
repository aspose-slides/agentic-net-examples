using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkShapeImport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input CSV file containing trace data
            string csvPath = "traces.csv";
            // Output presentation file
            string outputPath = "ImportedInk.pptx";

            // Verify that the CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Read all lines from the CSV
                    string[] csvLines = File.ReadAllLines(csvPath);

                    foreach (string line in csvLines)
                    {
                        // Expected format:
                        // point1X,point1Y;point2X,point2Y;...;ColorHex;Size
                        // Example: 100,150;200,250;#FF0000;5
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = line.Split(';');
                        if (parts.Length < 3)
                            continue; // Not enough data

                        // Parse points (all parts except last two)
                        System.Collections.Generic.List<System.Drawing.PointF> points = new System.Collections.Generic.List<System.Drawing.PointF>();
                        for (int i = 0; i < parts.Length - 2; i++)
                        {
                            string[] xy = parts[i].Split(',');
                            if (xy.Length != 2)
                                continue;
                            float x = float.Parse(xy[0]);
                            float y = float.Parse(xy[1]);
                            points.Add(new System.Drawing.PointF(x, y));
                        }

                        // Parse brush color (hex string)
                        string colorHex = parts[parts.Length - 2];
                        Color brushColor = ColorTranslator.FromHtml(colorHex);

                        // Parse brush size (single float, used as line width)
                        float brushSize = float.Parse(parts[parts.Length - 1]);

                        // Create a line shape that approximates the ink trace
                        // Use the first and last points to define the line segment
                        if (points.Count < 2)
                            continue;

                        System.Drawing.PointF start = points[0];
                        System.Drawing.PointF end = points[points.Count - 1];
                        float deltaX = end.X - start.X;
                        float deltaY = end.Y - start.Y;
                        float length = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                        float angle = (float)(Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI);

                        // Add a line shape
                        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Line,
                            start.X,
                            start.Y,
                            length,
                            0);

                        // Rotate the line to match the direction of the trace
                        shape.Rotation = angle;

                        // Configure the line to look like ink
                        Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;
                        lineFormat.Width = brushSize;
                        lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        lineFormat.FillFormat.SolidFillColor.Color = brushColor;
                        lineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;
                    }

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file I/O, parsing errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}