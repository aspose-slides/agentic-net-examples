using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

namespace ReplaceFlashBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            string newSwfPath = "newFlash.swf";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(newSwfPath))
            {
                Console.WriteLine("SWF file not found: " + newSwfPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through shapes to find an OleObjectFrame (Flash object)
                    OleObjectFrame flashFrame = null;
                    foreach (IShape shape in presentation.Slides[0].Shapes)
                    {
                        flashFrame = shape as OleObjectFrame;
                        if (flashFrame != null)
                        {
                            break;
                        }
                    }

                    if (flashFrame == null)
                    {
                        Console.WriteLine("No Flash (OleObjectFrame) found on the first slide.");
                    }
                    else
                    {
                        // Read new SWF binary data
                        byte[] swfData = File.ReadAllBytes(newSwfPath);
                        // Create embedded data info for the new SWF
                        IOleEmbeddedDataInfo newDataInfo = new OleEmbeddedDataInfo(swfData, "swf");
                        // Replace the embedded data while preserving position
                        flashFrame.SetEmbeddedData(newDataInfo);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}