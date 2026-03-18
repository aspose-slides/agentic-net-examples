using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Insert an ActiveX control (CommandButton) as an OLE object frame
            Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                100f,    // X position
                100f,    // Y position
                200f,    // Width
                50f,     // Height
                "Forms.CommandButton.1", // ActiveX class name
                ""       // Path to linked file (empty for embedded)
            );

            // Configure the control
            oleObjectFrame.IsObjectIcon = false;
            oleObjectFrame.ObjectName = "MyButton";

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}