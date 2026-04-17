using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneLayoutSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "cloned_layout.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePresentation = new Presentation(sourcePath))
                {
                    // Create a new (empty) destination presentation
                    using (Presentation destinationPresentation = new Presentation())
                    {
                        // Get the first master slide from the source presentation
                        IMasterSlide sourceMaster = sourcePresentation.Masters[0];

                        // Get the first layout slide from the source master
                        ILayoutSlide sourceLayout = sourceMaster.LayoutSlides[0];

                        // Get the first master slide from the destination presentation
                        IMasterSlide destinationMaster = destinationPresentation.Masters[0];

                        // Clone the layout slide into the destination presentation and assign it to the destination master
                        ILayoutSlide clonedLayout = destinationPresentation.LayoutSlides.AddClone(sourceLayout, destinationMaster);

                        // (Optional) Use the cloned layout to create a new slide in the destination presentation
                        // ISlide newSlide = destinationPresentation.Slides.AddClone(sourcePresentation.Slides[0], clonedLayout, true);

                        // Save the destination presentation
                        destinationPresentation.Save(destinationPath, SaveFormat.Pptx);
                    }
                }

                Console.WriteLine("Layout slide cloned successfully to: " + destinationPath);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}