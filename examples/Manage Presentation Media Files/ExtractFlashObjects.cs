using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            System.String inputPath = "input.pptx";
            // Output file for extracted flash binary
            System.String outputPath = "flash.bin";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            try
            {
                // Get the collection of controls from the first slide
                Aspose.Slides.IControlCollection controls = pres.Slides[0].Controls;
                Aspose.Slides.Control flashControl = null;

                // Find the flash control by name
                foreach (Aspose.Slides.IControl control in controls)
                {
                    if (control.Name == "ShockwaveFlash1")
                    {
                        flashControl = (Aspose.Slides.Control)control;
                        break;
                    }
                }

                // If found, write its binary data to a file
                if (flashControl != null)
                {
                    System.Byte[] data = flashControl.ActiveXControlBinary;
                    using (System.IO.FileStream fs = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read))
                    {
                        fs.Write(data, 0, data.Length);
                    }
                }
            }
            finally
            {
                // Save the presentation (if any modifications were made) before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
        }
    }
}