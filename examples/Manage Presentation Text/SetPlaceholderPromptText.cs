using System;

class Program
{
    static void Main()
    {
        // Load the presentation from file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("Presentation2.pptx"))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

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

                    // Set the text in the placeholder's text frame
                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = text;

                    // Output the change to console
                    Console.WriteLine($"Placeholder with text: {text}");
                }
            }

            // Save the modified presentation
            pres.Save("Placeholders_PromptText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}