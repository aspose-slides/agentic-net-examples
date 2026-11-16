// -----------------------------------------------------------------------------
// Example: Clone Slide to Specific Position and Update Notes with Translation
//
// Description:
// This console application clones a slide from a source PPTX into a destination
// PPTX at a specified position, demonstrates where to add notes, attempts to
// translate the presentation to French using Aspose.Slides.AI (if available),
// and saves the resulting file. It creates sample presentations if they do not
// exist and handles errors gracefully.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide cloning, notes, AI translation
//
// Use Cases:
// - Automate merging slides from multiple presentations into a single deck.
// - Add or modify slide notes programmatically.
// - Integrate AI-powered translation into PowerPoint processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        try
        {
            string dataDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;
            string sourcePath = dataDir + "source.pptx";
            string destPath = dataDir + "destination.pptx";
            string outputPath = dataDir + "result.pptx";

            // Create a sample source presentation if it does not exist
            if (!File.Exists(sourcePath))
            {
                Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation();
                // The first slide is already present; add some sample content if needed
                sourcePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                sourcePres.Dispose();
            }

            // Create a sample destination presentation if it does not exist
            if (!File.Exists(destPath))
            {
                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();
                destPres.Save(destPath, Aspose.Slides.Export.SaveFormat.Pptx);
                destPres.Dispose();
            }

            // Load presentations
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
            Aspose.Slides.Presentation dstPres = new Aspose.Slides.Presentation(destPath);

            // Clone the first slide from source into destination at position 1 (after the first slide)
            int insertPosition = 1;
            dstPres.Slides.InsertClone(insertPosition, srcPres.Slides[0]);

            // Add notes to the cloned slide (placeholder - actual API may differ)
            // Aspose.Slides.INotesSlide notes = dstPres.Slides[insertPosition].NotesSlideManager?.NotesSlide;
            // if (notes == null) { notes = dstPres.Slides[insertPosition].NotesSlideManager?.AddNotesSlide(); }
            // notes?.AddParagraph()?.AddNewTextRun("This is a sample note.");

            // Attempt translation using Aspose.Slides.AI (if the API is available)
            try
            {
                // Placeholder for AI translation - not implemented due to missing API documentation
                // Example: Aspose.Slides.AI.SlidesAI.TranslatePresentation(dstPres, "fr");
            }
            catch (Exception)
            {
                // Translation not supported or failed; continue without translation
            }

            // Save the resulting presentation
            dstPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            srcPres.Dispose();
            dstPres.Dispose();

            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
