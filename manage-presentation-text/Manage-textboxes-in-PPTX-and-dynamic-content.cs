using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageTextBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape (text box) to the slide
                Aspose.Slides.IAutoShape textBox1 = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 150, 75, 300, 100);
                // Add a text frame with initial text
                Aspose.Slides.ITextFrame textFrame1 = textBox1.AddTextFrame("Initial Text");
                // Set the actual text content
                Aspose.Slides.IParagraph paragraph1 = textFrame1.Paragraphs[0];
                Aspose.Slides.IPortion portion1 = paragraph1.Portions[0];
                portion1.Text = "Hello, Aspose.Slides!";

                // Add a second text box
                Aspose.Slides.IAutoShape textBox2 = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 150, 200, 300, 100);
                Aspose.Slides.ITextFrame textFrame2 = textBox2.AddTextFrame("Second Box");
                Aspose.Slides.IParagraph paragraph2 = textFrame2.Paragraphs[0];
                Aspose.Slides.IPortion portion2 = paragraph2.Portions[0];
                portion2.Text = "This box will be removed.";

                // Modify the text of the first text box dynamically
                portion1.Text = "Updated dynamic content";

                // Delete the second text box using the slide's Shapes collection
                slide.Shapes.Remove(textBox2);

                // Save the presentation
                string outputPath = System.IO.Path.Combine(
                    System.Environment.CurrentDirectory, "ManagedTextBoxes_out.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}