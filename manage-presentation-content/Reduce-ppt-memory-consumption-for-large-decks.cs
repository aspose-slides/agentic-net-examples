using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OptimizeLargePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourcePath = Path.Combine(Environment.CurrentDirectory, "LargePresentation.pptx");
            string copyPath = Path.Combine(Environment.CurrentDirectory, "LargePresentation_Copy.pptx");

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Source file not found: {sourcePath}");
                return;
            }

            // Configure load options to keep the source file locked and reduce memory usage
            LoadOptions loadOptions = new LoadOptions
            {
                BlobManagementOptions = new BlobManagementOptions
                {
                    PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked
                }
            };

            // Open the large presentation with the specified load options
            using (Presentation presentation = new Presentation(sourcePath, loadOptions))
            {
                // Example operation: rename the first slide
                if (presentation.Slides.Count > 0)
                {
                    presentation.Slides[0].Name = "RenamedSlide";
                }

                // Save a copy of the presentation
                presentation.Save(copyPath, SaveFormat.Pptx);
            }

            // Delete the original file after the presentation has been disposed
            File.Delete(sourcePath);
            Console.WriteLine("Processing completed successfully.");
        }
    }
}