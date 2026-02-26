using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide (adjust index as needed)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Find the index of the first table shape on the slide
        int tableShapeIndex = -1;
        for (int i = 0; i < slide.Shapes.Count; i++)
        {
            if (slide.Shapes[i] is Aspose.Slides.ITable)
            {
                tableShapeIndex = i;
                break;
            }
        }

        // If a table was found, remove it from the slide
        if (tableShapeIndex != -1)
        {
            slide.Shapes.RemoveAt(tableShapeIndex);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}