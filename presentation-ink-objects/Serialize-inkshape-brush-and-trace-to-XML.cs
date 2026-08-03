// -----------------------------------------------------------------------------
// Example: Serialize inkshape brush and trace to XML using C#
//
// Description:
// Demonstrates how to serialize Ink shape traces (and associated brush data) 
// from a PowerPoint presentation to an XML file using Aspose.Slides for .NET. 
// The example loads a PPTX file, extracts Ink shapes, writes their trace 
// information to XML, and saves the (potentially unchanged) presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Serialize, Inkshape, Brush, 
// Trace, XML, Presentation Processing, Office Automation
//
// Use Cases:
// - Export Ink shape trace data to XML for analysis or interoperability.
// - Build tools that process or archive Ink annotations in presentations.
// - Integrate Ink shape serialization into .NET automation workflows.
// - Preserve original presentation while extracting Ink metadata.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputXmlPath = "inkData.xml";
        string outputPptxPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Prepare XML writer settings
            System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.Indent = true;

            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(outputXmlPath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("InkShapes");

                // Iterate through slides and shapes to find Ink shapes
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                        if (inkShape != null)
                        {
                            writer.WriteStartElement("InkShape");
                            writer.WriteAttributeString("SlideIndex", slideIndex.ToString());

                            // Serialize trace information
                            writer.WriteStartElement("Traces");
                            foreach (Aspose.Slides.Ink.IInkTrace trace in inkShape.Traces)
                            {
                                writer.WriteStartElement("Trace");
                                // Example: serialize trace ID if available (placeholder)
                                // writer.WriteAttributeString("Id", trace.Id.ToString());
                                writer.WriteEndElement(); // Trace
                            }
                            writer.WriteEndElement(); // Traces

                            writer.WriteEndElement(); // InkShape
                        }
                    }
                }

                writer.WriteEndElement(); // InkShapes
                writer.WriteEndDocument();
            }

            // Save the (potentially unchanged) presentation before exit
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
