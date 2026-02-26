using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Directory where extracted flash data will be saved
        string outputDir = "FlashOutput";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get the collection of controls on the first slide
            Aspose.Slides.IControlCollection controls = pres.Slides[0].Controls;
            Aspose.Slides.Control flashControl = null;

            // Find the flash control by its name
            foreach (Aspose.Slides.IControl control in controls)
            {
                if (control.Name == "ShockwaveFlash1")
                {
                    flashControl = (Aspose.Slides.Control)control;
                    break;
                }
            }

            // If a flash control is found, extract its binary data
            if (flashControl != null)
            {
                byte[] data = flashControl.ActiveXControlBinary;
                string outPath = Path.Combine(outputDir, "flash.bin");
                using (FileStream fs = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    fs.Write(data, 0, data.Length);
                }
            }

            // Save the presentation before exiting (optional step)
            string savedPath = Path.Combine(outputDir, "presentation_saved.pptx");
            pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            pres.Dispose();
        }
    }
}