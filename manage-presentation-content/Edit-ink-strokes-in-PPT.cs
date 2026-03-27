using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace EditInkStrokes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string outputFile = Path.Combine(dataDir, "output.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Load existing presentation if it exists; otherwise create a new one
            using (Aspose.Slides.Presentation pres = File.Exists(inputFile) ? new Aspose.Slides.Presentation(inputFile) : new Aspose.Slides.Presentation())
            {
                // If a new presentation was created, add a simulated ink shape
                if (!File.Exists(inputFile))
                {
                    Aspose.Slides.IAutoShape inkShape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 300, 0);
                    inkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    inkShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;
                }

                // Modify the first shape's sketch type and then remove it
                if (pres.Slides[0].Shapes.Count > 0)
                {
                    Aspose.Slides.IAutoShape firstShape = pres.Slides[0].Shapes[0] as Aspose.Slides.IAutoShape;
                    if (firstShape != null)
                    {
                        // Change the sketch effect to Curved
                        firstShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Curved;
                    }

                    // Remove the shape from the slide
                    pres.Slides[0].Shapes.RemoveAt(0);
                }

                // Save the presentation
                pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}