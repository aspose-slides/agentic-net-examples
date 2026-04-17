using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for source and target presentations
            var sourcePath = "source.pptx";
            var targetPath = "target.pptx";
            var outputPath = "target_with_custom_data.pptx";

            // Verify source and target files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Source file not found: {sourcePath}");
                return;
            }

            if (!File.Exists(targetPath))
            {
                Console.WriteLine($"Target file not found: {targetPath}");
                return;
            }

            try
            {
                // Load source and target presentations
                using (var sourcePres = new Aspose.Slides.Presentation(sourcePath))
                using (var targetPres = new Aspose.Slides.Presentation(targetPath))
                {
                    // Access custom data collections
                    var sourceCustomData = sourcePres.CustomData;
                    var targetCustomData = targetPres.CustomData;

                    // TODO: Iterate over sourceCustomData entries and copy them to targetCustomData
                    // Preserve data types while copying. Implementation depends on ICustomData API.

                    // Save the modified target presentation
                    targetPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}