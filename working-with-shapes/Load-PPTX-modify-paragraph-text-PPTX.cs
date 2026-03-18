using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a rectangle auto shape
                    Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                    // Add a text frame to the shape
                    autoShape.AddTextFrame("Placeholder");

                    // Access the first paragraph and its first portion
                    Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                    Aspose.Slides.IPortion portion = paragraph.Portions[0];

                    // Set the desired text
                    portion.Text = "Your text";

                    // Save the modified presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}