using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the normal view properties (read‑only property, but its members are writable)
        Aspose.Slides.INormalViewProperties normalViewProps = presentation.ViewProperties.NormalViewProperties;

        // Access the restored top region properties
        Aspose.Slides.INormalViewRestoredProperties restoredTop = normalViewProps.RestoredTop;

        // Modify the restored top properties
        restoredTop.AutoAdjust = true;
        restoredTop.DimensionSize = 80f;

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}