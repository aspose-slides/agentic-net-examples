using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the PPTX template while preserving its layout and formatting
                using (Presentation presentation = new Presentation("Template.pptx"))
                {
                    // Save the loaded presentation to a new file
                    presentation.Save("Output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}