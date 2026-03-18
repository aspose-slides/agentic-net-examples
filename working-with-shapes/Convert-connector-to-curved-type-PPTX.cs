using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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

                            // Identify connector shapes
                            if (shape is Aspose.Slides.IConnector)
                            {
                                Aspose.Slides.IConnector connector = (Aspose.Slides.IConnector)shape;

                                // Set the connector's line sketch type to Curved
                                connector.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Curved;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}