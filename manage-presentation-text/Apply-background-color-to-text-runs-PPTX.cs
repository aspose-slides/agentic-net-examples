using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Hello World! This is a test.");

            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shp in slide.Shapes)
            {
                // Process only shapes that support text
                Aspose.Slides.IAutoShape autoShape = shp as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                    {
                        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                        {
                            // Set background fill for the text run (portion)
                            portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
                        }
                    }
                }
            }

            // Save the presentation
            presentation.Save("TextRunBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}