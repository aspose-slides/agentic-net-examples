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
                // Configure load options to delete embedded binary objects
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                // Load the presentation with the specified options
                using (Presentation presentation = new Presentation("input.pptx", loadOptions))
                {
                    // Save the presentation after loading
                    presentation.Save("output_without_binaries.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}