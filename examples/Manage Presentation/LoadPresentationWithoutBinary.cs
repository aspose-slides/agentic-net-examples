using System;
using Aspose.Slides;

namespace ManagePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "output_without_binaries.pptx";

            // Load options to delete embedded binary objects
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            // Load the presentation with the specified options
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Save the presentation after removing embedded binaries
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}