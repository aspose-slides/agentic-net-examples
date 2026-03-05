using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_without_binary.pptx";

            // Load options to delete embedded binary objects
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            // Load the presentation with the specified options
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}