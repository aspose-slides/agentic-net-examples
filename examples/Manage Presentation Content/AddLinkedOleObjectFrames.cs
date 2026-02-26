using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define position and size for the OLE object frame
        float x = 50f;
        float y = 50f;
        float width = 400f;
        float height = 300f;

        // Define the OLE class name (ProgID) and the path to the linked file
        string className = "Excel.Sheet";
        string linkedFilePath = "sample.xlsx";

        // Add a linked OLE object frame to the slide
        Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(x, y, width, height, className, linkedFilePath);

        // Set the object to update automatically when the presentation is opened
        oleFrame.UpdateAutomatic = true;

        // Save the presentation in PPT format
        presentation.Save("LinkedOleObject.ppt", SaveFormat.Ppt);
    }
}