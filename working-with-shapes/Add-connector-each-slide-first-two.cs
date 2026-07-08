using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            using (var pres = File.Exists(inputPath) ? new Presentation(inputPath) : new Presentation())
            {
                foreach (var slide in pres.Slides)
                {
                    if (slide.Shapes.Count >= 2)
                    {
                        var firstShape = slide.Shapes[0];
                        var secondShape = slide.Shapes[1];
                        var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                        connector.StartShapeConnectedTo = firstShape;
                        connector.EndShapeConnectedTo = secondShape;
                        connector.Reroute();
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}