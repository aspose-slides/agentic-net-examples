// -----------------------------------------------------------------------------
// Example: Clone First Slide and Rename Title Placeholder
//
// Description:
// This console program loads a source PPTX file, creates a new destination
// presentation, clones the first slide from the source into the destination,
// updates the title placeholder text, and saves the result. It demonstrates
// slide reuse and title customization using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide, rename title
//
// Use Cases:
// - Automate creation of customized presentations from a template slide.
// - Generate personalized decks by cloning and retitling slides.
// - Streamline slide reuse in batch PowerPoint processing.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        string sourcePath = "source.pptx";
        string destinationPath = "result.pptx";

        try
        {
            // Ensure source presentation exists; create a simple one if missing.
            if (!File.Exists(sourcePath))
            {
                Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                // Add a title slide (default layout contains a title placeholder).
                Aspose.Slides.ISlide titleSlide = createPres.Slides[0];
                // Set default title text.
                foreach (Aspose.Slides.IShape shape in titleSlide.Shapes)
                {
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        autoShape.TextFrame.Text = "Original Title";
                        break;
                    }
                }
                createPres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                createPres.Dispose();
            }

            // Load source presentation.
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);

            // Create empty destination presentation.
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Clone the first slide (index 0) from source into destination at position 0.
            destPres.Slides.InsertClone(0, srcPres.Slides[0]);

            // Retrieve the cloned slide.
            Aspose.Slides.ISlide clonedSlide = destPres.Slides[0];

            // Find the title placeholder (first shape with a TextFrame) and rename it.
            bool titleRenamed = false;
            foreach (Aspose.Slides.IShape shape in clonedSlide.Shapes)
            {
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.TextFrame != null)
                {
                    autoShape.TextFrame.Text = "New Customized Title";
                    titleRenamed = true;
                    break;
                }
            }

            if (!titleRenamed)
            {
                Console.WriteLine("Warning: Title placeholder not found on the cloned slide.");
            }

            // Save the destination presentation.
            destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up.
            srcPres.Dispose();
            destPres.Dispose();

            Console.WriteLine("Slide cloned and title renamed successfully. Output saved to: " + destinationPath);
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
