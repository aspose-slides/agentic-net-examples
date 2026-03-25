using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DefineConstants
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define constants for shape dimensions and text
            const string inputPath = "input.pptx";
            const string outputPath = "output.pptx";
            const float shapeX = 100f;
            const float shapeY = 100f;
            const float shapeWidth = 300f;
            const float shapeHeight = 200f;
            const string shapeText = "Constant Text";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load existing presentation if file exists, otherwise create a new one
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add an AutoShape using the defined constants
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    shapeX, shapeY, shapeWidth, shapeHeight);

                // Add a TextFrame to the shape
                autoShape.AddTextFrame(shapeText);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}