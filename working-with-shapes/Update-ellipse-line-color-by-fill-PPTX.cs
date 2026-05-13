using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateEllipseLineColor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define the fill color to search for and the new line color
                    Color targetFillColor = Color.Blue;
                    Color newLineColor = Color.Red;

                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == ShapeType.Ellipse)
                            {
                                if (autoShape.FillFormat != null && autoShape.FillFormat.FillType == FillType.Solid)
                                {
                                    Color shapeFillColor = autoShape.FillFormat.SolidFillColor.Color;
                                    if (shapeFillColor.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        if (autoShape.LineFormat != null && autoShape.LineFormat.FillFormat != null)
                                        {
                                            // Change the line color
                                            autoShape.LineFormat.FillFormat.SolidFillColor.Color = newLineColor;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}