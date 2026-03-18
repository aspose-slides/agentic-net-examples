using System;
using Aspose.Slides.Export;

namespace TextBoxDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a new text box (auto shape) to the slide
                Aspose.Slides.IAutoShape textBox = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                // Initialize text frame with initial text
                textBox.AddTextFrame("Initial Text");
                // Modify the text content
                textBox.TextFrame.Text = "Updated Text";

                // Remove the first shape on the slide (if any) as an example of removal
                if (slide.Shapes.Count > 0)
                {
                    slide.Shapes.RemoveAt(0);
                }

                // Save the updated presentation as PPTX
                presentation.Save("ModifiedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}