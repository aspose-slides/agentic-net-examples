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
        // Directory to store extracted flash files
        string outputDir = "ExtractedFlash";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            int flashIndex = 0;
            // Iterate through each slide
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                // Get the collection of controls on the slide
                Aspose.Slides.IControlCollection controls = slide.Controls;
                Aspose.Slides.Control flashControl = null;

                // Find the flash (Shockwave Flash) control
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
                    string outPath = Path.Combine(outputDir, "flash_" + flashIndex + ".swf");
                    using (FileStream fs = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        fs.Write(data, 0, data.Length);
                    }
                    flashIndex++;
                }
            }
        }
        finally
        {
            // Save the (unchanged) presentation before exiting
            string savedPath = Path.Combine(outputDir, "presentation_saved.pptx");
            pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}