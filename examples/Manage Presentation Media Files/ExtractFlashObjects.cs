using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output file for extracted flash binary
        string outputPath = "flash.bin";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the collection of controls on the first slide
        Aspose.Slides.IControlCollection controls = pres.Slides[0].Controls;

        // Variable to hold the flash control if found
        Aspose.Slides.Control flashControl = null;

        // Iterate through controls to find the ShockwaveFlash object
        foreach (Aspose.Slides.IControl control in controls)
        {
            if (control.Name == "ShockwaveFlash1")
            {
                flashControl = (Aspose.Slides.Control)control;
                break;
            }
        }

        // If flash control is found, extract its binary data
        if (flashControl != null)
        {
            byte[] data = flashControl.ActiveXControlBinary;
            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }
        }

        // Save the (potentially unchanged) presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}