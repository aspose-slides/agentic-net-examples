using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Set load options with default text language
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DefaultTextLanguage = "fr-FR";

            // Load the presentation with the specified load options
            Presentation presentation = new Presentation("input.pptx", loadOptions);

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Retrieve the first shape and ensure it supports text
            IShape shape = slide.Shapes[0];
            IAutoShape autoShape = shape as IAutoShape;
            if (autoShape != null)
            {
                // Update the text content of the shape
                autoShape.AddTextFrame("Updated text content");
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