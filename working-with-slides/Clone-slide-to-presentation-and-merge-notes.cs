// -----------------------------------------------------------------------------
// Example: Clone Slide and Merge Speaker Notes Using Aspose.Slides for .NET
//
// Description:
// Demonstrates cloning the first slide from a source PPTX into a new presentation
// and merging its speaker notes with the notes of the cloned slide. The program
// creates a sample source file if missing, performs the clone and notes merge,
// and saves the resulting presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Merge Notes, Presentation Automation
//
// Use Cases:
// - Reuse template slides while consolidating speaker notes.
// - Build utilities that combine notes from multiple presentations.
// - Automate creation of training decks with aggregated notes.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace CloneSlideAndMergeNotes
{
    class Program
    {
        static int Main(string[] args)
        {
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";

            // Ensure source presentation exists; create a simple one if missing
            if (!File.Exists(sourcePath))
            {
                try
                {
                    using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation())
                    {
                        // Add a slide using the first layout slide
                        Aspose.Slides.ILayoutSlide layout = sourcePres.Slides[0].LayoutSlide;
                        Aspose.Slides.ISlide slide = sourcePres.Slides.AddEmptySlide(layout);

                        // Add sample notes to the slide
                        Aspose.Slides.INotesSlideManager notesMgr = slide.NotesSlideManager;
                        Aspose.Slides.INotesSlide notesSlide = notesMgr.AddNotesSlide();
                        if (notesSlide.NotesTextFrame != null)
                        {
                            notesSlide.NotesTextFrame.Text = "Sample source notes.";
                        }

                        sourcePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample source presentation: " + ex.Message);
                    return 1;
                }
            }

            // Verify source file exists after creation attempt
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return 1;
            }

            try
            {
                // Load source presentation
                using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath))
                {
                    // Create destination presentation (empty)
                    using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                    {
                        // Clone the first slide from source to destination at index 0
                        Aspose.Slides.ISlide clonedSlide = destPres.Slides.InsertClone(0, sourcePres.Slides[0]);

                        // ----- Merge speaker notes -----
                        // Get source notes text
                        Aspose.Slides.INotesSlideManager sourceNotesMgr = sourcePres.Slides[0].NotesSlideManager;
                        Aspose.Slides.INotesSlide sourceNotesSlide = sourceNotesMgr.AddNotesSlide();
                        string sourceNotesText = string.Empty;
                        if (sourceNotesSlide.NotesTextFrame != null)
                        {
                            sourceNotesText = sourceNotesSlide.NotesTextFrame.Text;
                        }

                        // Ensure destination notes slide exists
                        Aspose.Slides.INotesSlideManager destNotesMgr = clonedSlide.NotesSlideManager;
                        Aspose.Slides.INotesSlide destNotesSlide = destNotesMgr.AddNotesSlide();

                        // Append source notes to destination notes
                        if (destNotesSlide.NotesTextFrame != null)
                        {
                            if (!string.IsNullOrEmpty(destNotesSlide.NotesTextFrame.Text))
                            {
                                destNotesSlide.NotesTextFrame.Text = destNotesSlide.NotesTextFrame.Text + Environment.NewLine + sourceNotesText;
                            }
                            else
                            {
                                destNotesSlide.NotesTextFrame.Text = sourceNotesText;
                            }
                        }

                        // Save the destination presentation
                        destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }

                Console.WriteLine("Slide cloned and notes merged successfully.");
                return 0;
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The presentation format is not supported.");
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return 1;
            }
        }
    }
}
