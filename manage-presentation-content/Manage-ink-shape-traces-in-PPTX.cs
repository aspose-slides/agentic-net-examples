using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

namespace ManageInkShapeTraces
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Ensure there is at least one slide and one shape
                if (pres.Slides.Count > 0 && pres.Slides[0].Shapes.Count > 0)
                {
                    // Get the first shape on the first slide
                    Aspose.Slides.IShape shape = pres.Slides[0].Shapes[0];

                    // Cast the shape to an ink object
                    Aspose.Slides.Ink.IInk ink = shape as Aspose.Slides.Ink.IInk;

                    if (ink != null)
                    {
                        // Retrieve all ink traces
                        Aspose.Slides.Ink.IInkTrace[] traces = ink.Traces;

                        if (traces.Length > 0)
                        {
                            // Access the first trace's brush
                            Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;

                            // Change the brush color to red
                            brush.Color = Color.Red;
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}