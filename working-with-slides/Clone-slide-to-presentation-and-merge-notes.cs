using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideAndMergeNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to source and destination presentations
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
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
                        // Get source notes slide (create if missing)
                        Aspose.Slides.INotesSlideManager sourceNotesMgr = sourcePres.Slides[0].NotesSlideManager;
                        Aspose.Slides.INotesSlide sourceNotesSlide = sourceNotesMgr.AddNotesSlide();

                        // Extract source notes text
                        string sourceNotesText = string.Empty;
                        if (sourceNotesSlide.NotesTextFrame != null)
                        {
                            sourceNotesText = sourceNotesSlide.NotesTextFrame.Text;
                        }

                        // Get destination notes manager and ensure a notes slide exists
                        Aspose.Slides.INotesSlideManager destNotesMgr = clonedSlide.NotesSlideManager;
                        Aspose.Slides.INotesSlide destNotesSlide = destNotesMgr.AddNotesSlide();

                        // Append source notes to destination notes (or replace)
                        if (destNotesSlide.NotesTextFrame != null)
                        {
                            // If destination already has notes, combine them
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
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}