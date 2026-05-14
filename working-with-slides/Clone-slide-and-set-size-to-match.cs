using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string sourcePath = "source.pptx";
            string destinationTemplatePath = "template.pptx";
            string outputPath = "cloned_output.pptx";

            // Verify input files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            if (!File.Exists(destinationTemplatePath))
            {
                Console.WriteLine("Destination template file does not exist: " + destinationTemplatePath);
                return;
            }

            try
            {
                // Load source and destination presentations
                Presentation sourcePres = new Presentation(sourcePath);
                Presentation destPres = new Presentation(destinationTemplatePath);

                // Clone the first slide from source into destination at position 0
                destPres.Slides.InsertClone(0, sourcePres.Slides[0]);

                // Adjust destination slide size to match source presentation size
                float sourceWidth = sourcePres.SlideSize.Size.Width;
                float sourceHeight = sourcePres.SlideSize.Size.Height;
                destPres.SlideSize.SetSize(sourceWidth, sourceHeight, SlideSizeScaleType.EnsureFit);

                // Save the resulting presentation
                destPres.Save(outputPath, SaveFormat.Pptx);

                // Dispose presentations
                sourcePres.Dispose();
                destPres.Dispose();

                Console.WriteLine("Slide cloned and slide size adjusted successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported by Aspose.Slides, an exception will be thrown.
            }
        }
    }
}