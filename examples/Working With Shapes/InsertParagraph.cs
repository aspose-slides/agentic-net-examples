using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertPortionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

            // Add a TextFrame with initial text
            shape.AddTextFrame("Hello World");

            // Access the TextFrame
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

            // Get the first paragraph in the TextFrame
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Create a new portion using PortionFactory
            Aspose.Slides.PortionFactory portionFactory = new Aspose.Slides.PortionFactory();
            Aspose.Slides.IPortion newPortion = portionFactory.CreatePortion(" Inserted");

            // Insert the new portion at index 1 (after the first portion)
            paragraph.Portions.Insert(1, newPortion);

            // Save the presentation
            presentation.Save("InsertPortion_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}