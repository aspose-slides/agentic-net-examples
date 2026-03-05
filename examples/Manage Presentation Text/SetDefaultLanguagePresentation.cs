using System;

class Program
{
    static void Main(string[] args)
    {
        // Create load options and set the default text language
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DefaultTextLanguage = "en-US";

        // Create a new presentation using the load options
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions))
        {
            // Save the presentation as PPTX
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}