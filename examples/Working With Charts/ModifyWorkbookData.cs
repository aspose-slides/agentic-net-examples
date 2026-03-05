using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide (example)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example: Access the first shape on the slide
        Aspose.Slides.IShape shape = slide.Shapes[0];

        // If the shape is a chart, you can modify its workbook data here
        // (Implementation depends on the specific chart type and data structure)
        // Aspose.Slides.IChart chart = shape as Aspose.Slides.IChart;
        // if (chart != null)
        // {
        //     // Modify chart data workbook, e.g., change cell values
        // }

        // Save the modified presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}