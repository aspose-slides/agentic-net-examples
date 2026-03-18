using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load PPTX data into a byte array (replace with actual source)
                byte[] pptData = File.ReadAllBytes("input.pptx");
                using (MemoryStream memoryStream = new MemoryStream(pptData))
                {
                    using (Presentation presentation = new Presentation(memoryStream))
                    {
                        // Initialize slide deck (example: access the first slide)
                        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                        // Additional processing can be performed here

                        // Save the presentation before exiting
                        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}