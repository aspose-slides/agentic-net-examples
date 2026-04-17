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
            // Paths for source and destination presentations
            string sourcePath = "source.pptx";
            string destinationPath = "output.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation sourcePresentation = new Presentation(sourcePath))
                {
                    // Create a new destination presentation
                    using (Presentation destinationPresentation = new Presentation())
                    {
                        // Clone the master slide from the first source slide
                        ISlide sourceFirstSlide = sourcePresentation.Slides[0];
                        IMasterSlide sourceMaster = sourceFirstSlide.LayoutSlide.MasterSlide;
                        IMasterSlide clonedMaster = destinationPresentation.Masters.AddClone(sourceMaster);

                        // Clone each slide from source to destination using the cloned master
                        for (int i = 0; i < sourcePresentation.Slides.Count; i++)
                        {
                            ISlide sourceSlide = sourcePresentation.Slides[i];
                            destinationPresentation.Slides.AddClone(sourceSlide, clonedMaster, true);
                        }

                        // Remove unused master slides from the destination presentation
                        destinationPresentation.Masters.RemoveUnused(true);

                        // Save the resulting presentation
                        destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}