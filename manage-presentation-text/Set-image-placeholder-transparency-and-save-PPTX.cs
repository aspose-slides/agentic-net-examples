using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace PlaceholderTransparencyDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (var slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (var shape in slide.Shapes)
                        {
                            var placeholder = shape.Placeholder;
                            // Check if the shape is a picture placeholder
                            if (placeholder != null && placeholder.Type == Aspose.Slides.PlaceholderType.Picture)
                            {
                                var fillFormat = shape.FillFormat;
                                if (fillFormat != null)
                                {
                                    // Set fill color with desired alpha (e.g., 50% transparency)
                                    fillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.White);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}