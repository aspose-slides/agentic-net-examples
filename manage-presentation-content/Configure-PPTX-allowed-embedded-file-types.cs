using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load presentation with default options
                var loadOptions = new LoadOptions();
                // Configure to keep embedded objects (do not delete them)
                loadOptions.DeleteEmbeddedBinaryObjects = false;

                // Open the presentation
                using (var presentation = new Presentation("input.pptx", loadOptions))
                {
                    // Save the presentation preserving embedded objects
                    presentation.Save("output.pptx", SaveFormat.Ppt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}