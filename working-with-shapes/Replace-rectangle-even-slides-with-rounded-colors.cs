using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReplaceRectangleWithRounded
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path (first argument or default)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Process only even-numbered slides (1‑based indexing)
                        if ((slideIndex + 1) % 2 == 0)
                        {
                            IShapeCollection shapes = presentation.Slides[slideIndex].Shapes;

                            // Iterate through each shape on the slide
                            foreach (IShape shape in shapes)
                            {
                                // Work only with AutoShape objects
                                if (shape is IAutoShape autoShape)
                                {
                                    // Identify rectangle shapes
                                    if (autoShape.ShapeType == ShapeType.Rectangle)
                                    {
                                        // Preserve existing fill settings
                                        IFillFormat originalFill = autoShape.FillFormat;
                                        FillType fillType = originalFill.FillType;
                                        Color? solidColor = null;

                                        if (fillType == FillType.Solid)
                                        {
                                            solidColor = originalFill.SolidFillColor.Color;
                                        }

                                        // Change shape type to rounded rectangle
                                        autoShape.ShapeType = ShapeType.RoundCornerRectangle;

                                        // Reapply the preserved fill
                                        autoShape.FillFormat.FillType = fillType;
                                        if (solidColor.HasValue)
                                        {
                                            autoShape.FillFormat.SolidFillColor.Color = solidColor.Value;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported file formats or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}