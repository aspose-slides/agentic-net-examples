using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Iterate through shapes to find placeholders
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IPlaceholder placeholder = shape.Placeholder;
                    string text = "";

                    // Set custom prompt text based on placeholder type
                    if (placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                    {
                        text = "Custom Title";
                    }
                    else if (placeholder.Type == Aspose.Slides.PlaceholderType.Subtitle)
                    {
                        text = "Custom Subtitle";
                    }

                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;
                }
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}