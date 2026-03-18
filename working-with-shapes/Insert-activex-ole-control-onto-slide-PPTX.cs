using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];
                // Add an ActiveX control (CommandButton) as an OLE object frame
                string className = "Forms.CommandButton.1";
                string path = "";
                IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(100f, 100f, 200f, 50f, className, path);
                // Display the control as an icon
                oleObjectFrame.IsObjectIcon = true;
                // Save the presentation
                presentation.Save("ActiveXControl.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}