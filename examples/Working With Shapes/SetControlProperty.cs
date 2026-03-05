using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first ActiveX control on the slide (assumes at least one exists)
            Aspose.Slides.IControl control = slide.Controls[0];

            // If the control stores properties as a property bag, assign a new value
            if (control.Persistence == Aspose.Slides.PersistenceType.PersistPropertyBag)
            {
                // Set the "Value" property of the ActiveX control
                control.Properties["Value"] = "NewValue";
            }

            // Save the presentation before exiting
            presentation.Save("ActiveXControl.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}