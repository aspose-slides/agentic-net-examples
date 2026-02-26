using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an OLE object frame that represents an ActiveX control (e.g., WebBrowser)
            Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
                100f,    // X position
                100f,    // Y position
                300f,    // Width
                200f,    // Height
                "Shell.Explorer", // Class name of the ActiveX control
                ""       // Path to linked file (empty for embedded)
            );

            // Access the newly added ActiveX control from the slide's Controls collection
            // (Assuming the first control corresponds to the OLE object we just added)
            Aspose.Slides.IControl activeXControl = slide.Controls[0];

            // Set the control's name
            activeXControl.Name = "WebBrowserControl";

            // Assign the frame of the OLE object to the control
            activeXControl.Frame = oleObjectFrame.Frame;

            // If the control supports XML based properties, set a sample property
            if (activeXControl.Persistence == Aspose.Slides.PersistenceType.PersistPropertyBag)
            {
                activeXControl.Properties["Value"] = "https://example.com";
            }

            // Save the presentation
            presentation.Save("ActiveXControlPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}