using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ColumnSpacingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "ColumnSpacingDemo.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle auto shape to the first slide
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300);

            // Add an empty text frame to the shape
            shape.AddTextFrame(string.Empty);

            // Configure text frame columns and spacing
            Aspose.Slides.TextFrameFormat format = (Aspose.Slides.TextFrameFormat)shape.TextFrame.TextFrameFormat;
            format.ColumnCount = 2;          // Set number of columns
            format.ColumnSpacing = 20;       // Set spacing between columns (points)

            // Set sample text
            shape.TextFrame.Text = "This is sample text that will be split into columns with custom spacing. " +
                                   "The text will automatically adjust to the defined column layout.";

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}