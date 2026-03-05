using System;

class Program
{
    static void Main()
    {
        // Create load options and set the format to PPTX
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.LoadFormat = Aspose.Slides.LoadFormat.Pptx;

        // Load the presentation with the custom load options
        Aspose.Slides.IPresentation presentation = Aspose.Slides.PresentationFactory.Instance.ReadPresentation("input.pptx", loadOptions);

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}