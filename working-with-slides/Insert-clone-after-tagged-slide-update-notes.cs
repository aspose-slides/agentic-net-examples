// -----------------------------------------------------------------------------
// Example: Insert clone after tagged slide and update notes using C#
//
// Description:
// Demonstrates how to locate a slide by a custom tag, clone that slide,
// insert the clone immediately after the original, add a notes slide to the
// cloned slide, set custom notes text, and save the presentation using
// Aspose.Slides for .NET. The example is a self‑contained console application
// suitable for automating PPTX workflows.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, InsertClone, CustomData, Tags, NotesSlide, Presentation Automation
//
// Use Cases:
// - Clone a slide identified by a custom tag and modify its notes.
// - Build .NET utilities for PowerPoint slide duplication and annotation.
// - Automate presentation preparation tasks that require tagged slide handling.
// - Integrate slide cloning and notes updating into larger document processing pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertCloneAfterTaggedSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Tag name and value to search for
                    string tagName = "MyTag";
                    string tagValue = "CloneAfterMe";

                    // Find the slide with the specified tag
                    int sourceIndex = -1;
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Tags are stored in the slide's custom data
                        if (slide.CustomData.Tags.Contains(tagName) &&
                            slide.CustomData.Tags[tagName] == tagValue)
                        {
                            sourceIndex = i;
                            break;
                        }
                    }

                    if (sourceIndex == -1)
                    {
                        Console.WriteLine("No slide with the specified tag was found.");
                        return;
                    }

                    // Clone the slide and insert it after the source slide
                    ISlide sourceSlide = presentation.Slides[sourceIndex];
                    int insertIndex = sourceIndex + 1;
                    ISlide clonedSlide = presentation.Slides.InsertClone(insertIndex, sourceSlide);

                    // Add or get the notes slide for the cloned slide
                    INotesSlideManager notesManager = clonedSlide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.AddNotesSlide();

                    // Update the notes text
                    notesSlide.NotesTextFrame.Text = "These are the notes for the cloned slide.";

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
