using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Iterate through all shapes on the slide
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            // Check if the shape has a placeholder and is an AutoShape
            if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
            {
                string text = "";

                // Determine placeholder type and set appropriate prompt text
                if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                {
                    text = "Add Title";
                }
                else if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Subtitle)
                {
                    text = "Add Subtitle";
                }

                // Set the prompt text in the placeholder
                ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;
                Console.WriteLine($"Placeholder with text: {text}");
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}