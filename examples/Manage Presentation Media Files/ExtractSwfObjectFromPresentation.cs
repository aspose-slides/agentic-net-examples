using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Input PPTX file containing the Flash (ActiveX) control
        string inputPath = "input.pptx";
        // Output PPTX file (saved after processing)
        string outputPath = "output.pptx";
        // Path to save the extracted SWF binary data
        string flashOutputPath = "flash.swf";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the collection of ActiveX controls on the first slide
        Aspose.Slides.IControlCollection controls = pres.Slides[0].Controls;

        // Variable to hold the Flash control once found
        Aspose.Slides.Control flashControl = null;

        // Iterate through controls to find the one named "ShockwaveFlash1"
        foreach (Aspose.Slides.IControl control in controls)
        {
            if (control.Name == "ShockwaveFlash1")
            {
                flashControl = (Aspose.Slides.Control)control;
                break;
            }
        }

        // If the Flash control is found, extract its binary data and write to a file
        if (flashControl != null)
        {
            byte[] data = flashControl.ActiveXControlBinary;
            using (FileStream fs = new FileStream(flashOutputPath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }
        }

        // Save the presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}