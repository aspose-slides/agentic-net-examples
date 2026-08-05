// -----------------------------------------------------------------------------
// Example: Clone slide and set size to match using C#
//
// Description:
// Demonstrates how to clone the first slide from a source presentation into a
// destination template presentation and adjust the destination slide size to
// match the source presentation dimensions using Aspose.Slides for .NET.
// The example includes file existence checks, presentation loading, slide
// cloning, size synchronization, and saving the resulting PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Clone Slide, Slide Size, Match Size,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Copy a specific slide from one PPTX into another while preserving layout.
// - Ensure the target presentation adopts the same slide dimensions as the source.
// - Automate PPTX merging and size normalization in .NET applications.
// - Prepare presentations for consistent rendering across different devices.
// -----------------------------------------------------------------------------
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
