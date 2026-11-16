// -----------------------------------------------------------------------------
// Example: Clone Slide and Synchronize Slide Size Using Aspose.Slides for .NET
//
// Description:
// Demonstrates cloning the first slide from a source PPTX into a destination
// template PPTX and adjusting the destination presentation's slide dimensions to
// match the source using Aspose.Slides for .NET. The program creates sample
// presentations if they are missing, performs the operation, and saves the
// result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Slide Size, Presentation Merge
//
// Use Cases:
// - Copy a specific slide from one presentation to another while preserving layout.
// - Ensure consistent slide dimensions across merged presentations.
// - Automate PPTX processing for consistent rendering in .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SlideCloneAndSizeSync
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "source.pptx";
            string templatePath = "template.pptx";
            string outputPath = "cloned_output.pptx";

            try
            {
                // Create source presentation if it does not exist
                if (!File.Exists(sourcePath))
                {
                    Aspose.Slides.Presentation sourcePresCreate = new Aspose.Slides.Presentation();
                    sourcePresCreate.Slides.AddEmptySlide(sourcePresCreate.Slides[0].LayoutSlide);
                    sourcePresCreate.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    sourcePresCreate.Dispose();
                }

                // Create template presentation if it does not exist
                if (!File.Exists(templatePath))
                {
                    Aspose.Slides.Presentation templatePresCreate = new Aspose.Slides.Presentation();
                    templatePresCreate.Slides.AddEmptySlide(templatePresCreate.Slides[0].LayoutSlide);
                    templatePresCreate.Save(templatePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    templatePresCreate.Dispose();
                }

                // Load source and destination presentations
                Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);
                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation(templatePath);

                // Clone the first slide from source into destination at position 0
                destPres.Slides.InsertClone(0, sourcePres.Slides[0]);

                // Adjust destination slide size to match source presentation size
                float sourceWidth = sourcePres.SlideSize.Size.Width;
                float sourceHeight = sourcePres.SlideSize.Size.Height;
                destPres.SlideSize.SetSize(sourceWidth, sourceHeight, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Save the resulting presentation
                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose presentations
                sourcePres.Dispose();
                destPres.Dispose();

                Console.WriteLine("Slide cloned and slide size synchronized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Exit with non-zero code to indicate failure
                Environment.Exit(1);
            }
        }
    }
}
