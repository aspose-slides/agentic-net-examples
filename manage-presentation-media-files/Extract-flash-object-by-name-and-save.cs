// -----------------------------------------------------------------------------
// Example: Extract flash object by name and save using C#
//
// Description:
// Demonstrates how to locate a Shockwave Flash ActiveX control by its name
// within a PowerPoint presentation and extract its binary data to a .swf file
// using Aspose.Slides for .NET. The example also shows how to save the
// presentation after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Flash, ActiveX, Object, Name, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of embedded Flash objects from PPTX files.
// - Build C# utilities for managing media assets in presentations.
// - Convert or archive Flash content from PowerPoint slides.
// - Validate and process presentation files before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "flash.swf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Get the collection of controls on the slide
                IControlCollection controls = slide.Controls;
                Control flashControl = null;

                foreach (IControl control in controls)
                {
                    if (control.Name == "ShockwaveFlash1")
                    {
                        flashControl = (Control)control;
                        break;
                    }
                }

                if (flashControl != null)
                {
                    byte[] data = flashControl.ActiveXControlBinary;
                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }
                    Console.WriteLine("Flash object extracted to " + outputPath);
                }
                else
                {
                    Console.WriteLine("Flash object not found.");
                }

                // Save the presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
