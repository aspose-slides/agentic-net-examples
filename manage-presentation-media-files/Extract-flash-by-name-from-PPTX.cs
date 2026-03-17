using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractFlashExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input presentation path
                string inputPath = "input.pptx";
                // Name of the Flash control to extract
                string flashControlName = "ShockwaveFlash1";
                // Output SWF file path
                string outputSwfPath = "extracted_flash.swf";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get controls collection from the first slide (index 0)
                    Aspose.Slides.IControlCollection controls = presentation.Slides[0].Controls;
                    Aspose.Slides.Control flashControl = null;

                    // Find the control by name
                    foreach (Aspose.Slides.IControl control in controls)
                    {
                        if (control.Name == flashControlName)
                        {
                            flashControl = (Aspose.Slides.Control)control;
                            break;
                        }
                    }

                    if (flashControl != null)
                    {
                        // Retrieve the binary data of the ActiveX (Flash) control
                        byte[] flashData = flashControl.ActiveXControlBinary;

                        // Write the SWF data to a file
                        using (FileStream fileStream = new FileStream(outputSwfPath, FileMode.Create, FileAccess.Write))
                        {
                            fileStream.Write(flashData, 0, flashData.Length);
                        }

                        Console.WriteLine("Flash control extracted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Flash control with the specified name was not found.");
                    }

                    // Save the presentation before exiting (optional, as per requirement)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}