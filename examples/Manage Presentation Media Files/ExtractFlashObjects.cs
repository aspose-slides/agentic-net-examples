using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        System.String inputPath = "input.pptx";
        // Directory to save extracted flash data
        System.String outputDir = "ExtractedFlash";
        System.IO.Directory.CreateDirectory(outputDir);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get controls from the first slide
            Aspose.Slides.IControlCollection controls = pres.Slides[0].Controls;
            Aspose.Slides.Control flashControl = null;

            // Find the Shockwave Flash control
            foreach (Aspose.Slides.IControl control in controls)
            {
                if (control.Name == "ShockwaveFlash1")
                {
                    flashControl = (Aspose.Slides.Control)control;
                    break;
                }
            }

            // Extract and save the flash binary data
            if (flashControl != null)
            {
                System.Byte[] data = flashControl.ActiveXControlBinary;
                System.String outPath = System.IO.Path.Combine(outputDir, "flash.bin");
                using (System.IO.FileStream fs = new System.IO.FileStream(outPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }
            }
        }
        finally
        {
            // Save the presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}