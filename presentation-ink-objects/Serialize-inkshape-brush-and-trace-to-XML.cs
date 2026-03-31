using System;
using System.IO;
using System.Xml;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string xmlPath = "inkData.xml";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Prepare XML document to store ink data
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement root = xmlDoc.CreateElement("Inks");
                xmlDoc.AppendChild(root);

                // Iterate through slides and shapes
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        IShape shape = slide.Shapes[j];
                        Ink inkShape = shape as Ink;
                        if (inkShape != null)
                        {
                            // Create XML element for the ink shape
                            XmlElement inkElement = xmlDoc.CreateElement("Ink");
                            inkElement.SetAttribute("SlideIndex", (i + 1).ToString());
                            inkElement.SetAttribute("ShapeName", inkShape.Name);
                            root.AppendChild(inkElement);

                            // Serialize each trace
                            IInkTrace[] traces = inkShape.Traces;
                            for (int t = 0; t < traces.Length; t++)
                            {
                                IInkTrace trace = traces[t];
                                XmlElement traceElement = xmlDoc.CreateElement("Trace");
                                traceElement.SetAttribute("Index", t.ToString());
                                inkElement.AppendChild(traceElement);

                                // Serialize brush information
                                IInkBrush brush = trace.Brush;
                                XmlElement brushElement = xmlDoc.CreateElement("Brush");
                                brushElement.SetAttribute("Color", brush.Color.ToArgb().ToString());
                                brushElement.SetAttribute("Size", brush.Size.ToString());
                                brushElement.SetAttribute("InkEffect", brush.InkEffect.ToString());
                                traceElement.AppendChild(brushElement);

                                // Serialize points
                                XmlElement pointsElement = xmlDoc.CreateElement("Points");
                                foreach (PointF pt in trace.Points)
                                {
                                    XmlElement pointElement = xmlDoc.CreateElement("Point");
                                    pointElement.SetAttribute("X", pt.X.ToString());
                                    pointElement.SetAttribute("Y", pt.Y.ToString());
                                    pointsElement.AppendChild(pointElement);
                                }
                                traceElement.AppendChild(pointsElement);
                            }
                        }
                    }
                }

                // Save the XML data
                xmlDoc.Save(xmlPath);

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}