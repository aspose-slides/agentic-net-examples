using Aspose.Slides;
using Aspose.Slides.Export;
using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("");

            // Access the first paragraph
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

            // Create two portions: normal and the one to be bolded
            Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion("Hello ");
            Aspose.Slides.IPortion portion2 = new Aspose.Slides.Portion("World");

            // Add portions to the paragraph
            paragraph.Portions.Add(portion1);
            paragraph.Portions.Add(portion2);

            // Apply bold formatting to the second portion while preserving other styles
            portion2.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("BoldText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}