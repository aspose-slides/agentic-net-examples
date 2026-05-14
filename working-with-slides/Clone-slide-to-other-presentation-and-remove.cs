using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideCloneAndRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string sourcePath = "source.pptx";
            string destinationPath = "cloned.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load source presentation
                Presentation srcPres = new Presentation(sourcePath);
                // Create destination presentation
                Presentation destPres = new Presentation();

                // Clone slide with its master to destination presentation
                ISlide sourceSlide = srcPres.Slides[0];
                IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);

                // Remove the original slide from source presentation
                ISlide firstSlide = srcPres.Slides[0];
                srcPres.Slides.Remove(firstSlide);

                // Save both presentations
                destPres.Save(destinationPath, SaveFormat.Pptx);
                srcPres.Save(sourcePath, SaveFormat.Pptx);

                // Dispose presentations
                srcPres.Dispose();
                destPres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
                // Comment: format not supported.
            }
        }
    }
}