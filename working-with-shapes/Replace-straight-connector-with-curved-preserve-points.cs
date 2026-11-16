// -----------------------------------------------------------------------------
// Example: Replace Straight Connectors with Curved Connectors Preserving Points
//
// Description:
// Demonstrates how to replace straight line connectors with bent (curved) connectors
// in a PowerPoint presentation using C# and Aspose.Slides for .NET while preserving
// their start and end connection points. The program creates a sample PPTX if none
// exists, performs the conversion, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Straight Connector, Curved Connector, Preserve Points
//
// Use Cases:
// - Automate conversion of straight connectors to curved ones in existing presentations.
// - Build tools that adjust diagram aesthetics programmatically.
// - Validate connector transformations during PPTX generation pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ConnectorsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IConnector straightConnector = (Aspose.Slides.IConnector)sampleSlide.Shapes.AddConnector(
                        Aspose.Slides.ShapeType.Line,
                        100, 100, 300, 100);
                    straightConnector.LineFormat.Width = 2;
                    straightConnector.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    straightConnector.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation for processing
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];
                        if (shape is Aspose.Slides.IConnector)
                        {
                            Aspose.Slides.IConnector connector = (Aspose.Slides.IConnector)shape;
                            if (connector.ShapeType == Aspose.Slides.ShapeType.Line)
                            {
                                // Replace straight connector with a bent (curved) connector while preserving connection points
                                connector.ShapeType = Aspose.Slides.ShapeType.BentConnector2;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Connector conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // The provided file format may not be supported by Aspose.Slides.
                Environment.Exit(1);
            }
        }
    }
}
