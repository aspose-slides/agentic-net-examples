using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outFilePath = "ColumnsDemo.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a rectangle auto shape to the first slide
        IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

        // Add a text frame with sample text
        shape.AddTextFrame("This is a sample text that will be split into two columns.");

        // Get the text frame format and set the number of columns to 2
        TextFrameFormat format = (TextFrameFormat)shape.TextFrame.TextFrameFormat;
        format.ColumnCount = 2;

        // Save the presentation
        pres.Save(outFilePath, SaveFormat.Pptx);
    }
}