using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    System.Collections.Generic.List<Aspose.Slides.IConnector> toReplace = new System.Collections.Generic.List<Aspose.Slides.IConnector>();

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IConnector connector = shape as Aspose.Slides.IConnector;
                        if (connector != null && connector.ShapeType == Aspose.Slides.ShapeType.StraightConnector1)
                        {
                            toReplace.Add(connector);
                        }
                    }

                    foreach (Aspose.Slides.IConnector oldConnector in toReplace)
                    {
                        Aspose.Slides.IShape startShape = oldConnector.StartShapeConnectedTo;
                        uint startSite = oldConnector.StartShapeConnectionSiteIndex;
                        Aspose.Slides.IShape endShape = oldConnector.EndShapeConnectedTo;
                        uint endSite = oldConnector.EndShapeConnectionSiteIndex;

                        // Remove the straight connector
                        slide.Shapes.Remove(oldConnector);

                        // Add a curved connector at the same position and size
                        Aspose.Slides.IConnector newConnector = slide.Shapes.AddConnector(
                            Aspose.Slides.ShapeType.CurvedConnector2,
                            oldConnector.X,
                            oldConnector.Y,
                            oldConnector.Width,
                            oldConnector.Height);

                        // Preserve attachment points
                        newConnector.StartShapeConnectedTo = startShape;
                        newConnector.StartShapeConnectionSiteIndex = startSite;
                        newConnector.EndShapeConnectedTo = endShape;
                        newConnector.EndShapeConnectionSiteIndex = endSite;

                        // Adjust the path
                        newConnector.Reroute();
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}