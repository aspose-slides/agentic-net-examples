using System;

class Program
{
    static void Main()
    {
        // Output file path
        System.String outputPath = "EndParagraphRunProperties_out.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape to the first slide
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 10, 10, 200, 250);

        // Ensure the shape has a text frame
        shape.AddTextFrame("");

        // Create the first paragraph with a portion
        Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
        para1.Portions.Add(new Aspose.Slides.Portion("First paragraph text."));

        // Create the second paragraph with a portion
        Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
        para2.Portions.Add(new Aspose.Slides.Portion("Second paragraph text."));

        // Define the end paragraph portion format
        Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
        portionFormat.FontHeight = 48;
        portionFormat.LatinFont = new Aspose.Slides.FontData("Arial");

        // Assign the end paragraph portion format to the second paragraph
        para2.EndParagraphPortionFormat = portionFormat;

        // Add paragraphs to the shape's text frame
        shape.TextFrame.Paragraphs.Add(para1);
        shape.TextFrame.Paragraphs.Add(para2);

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}