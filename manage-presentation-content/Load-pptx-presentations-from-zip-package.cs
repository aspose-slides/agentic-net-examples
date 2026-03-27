using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationZipExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourcePath = "input.pptx";
            string copyPath = "output.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            // Configure load options to keep the source file locked during processing
            LoadOptions loadOptions = new LoadOptions
            {
                BlobManagementOptions = new BlobManagementOptions
                {
                    PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked
                }
            };

            // Load the presentation from the ZIP package (PPTX file)
            using (Presentation presentation = new Presentation(sourcePath, loadOptions))
            {
                // Manipulate the presentation (rename the first slide)
                presentation.Slides[0].Name = "RenamedSlide";

                // Save the modified presentation to a new file
                presentation.Save(copyPath, SaveFormat.Pptx);
            }

            // Delete the original file now that the presentation is unlocked
            File.Delete(sourcePath);
        }
    }
}