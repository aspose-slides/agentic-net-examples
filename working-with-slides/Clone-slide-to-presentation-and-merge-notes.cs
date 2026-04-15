using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideWithNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";
            string outputPath = "merged_output.pptx";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            if (!File.Exists(destinationPath))
            {
                Console.WriteLine("Destination file does not exist.");
                return;
            }

            try
            {
                using (Presentation srcPres = new Presentation(sourcePath))
                {
                    using (Presentation destPres = new Presentation(destinationPath))
                    {
                        // Clone slide with its master
                        Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                        Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                        Aspose.Slides.ISlide clonedSlide = destPres.Slides.AddClone(sourceSlide, destMaster, true);

                        // Retrieve source notes
                        string sourceNotes = string.Empty;
                        if (sourceSlide.NotesSlideManager != null &&
                            sourceSlide.NotesSlideManager.NotesSlide != null &&
                            sourceSlide.NotesSlideManager.NotesSlide.NotesTextFrame != null)
                        {
                            sourceNotes = sourceSlide.NotesSlideManager.NotesSlide.NotesTextFrame.Text;
                        }

                        // Ensure destination slide has a notes slide
                        Aspose.Slides.INotesSlideManager destNotesMgr = clonedSlide.NotesSlideManager;
                        if (destNotesMgr.NotesSlide == null)
                        {
                            destNotesMgr.AddNotesSlide();
                        }

                        // Retrieve destination notes
                        string destNotes = string.Empty;
                        if (destNotesMgr.NotesSlide != null &&
                            destNotesMgr.NotesSlide.NotesTextFrame != null)
                        {
                            destNotes = destNotesMgr.NotesSlide.NotesTextFrame.Text;
                        }

                        // Merge notes
                        string mergedNotes = destNotes;
                        if (!string.IsNullOrEmpty(mergedNotes) && !string.IsNullOrEmpty(sourceNotes))
                        {
                            mergedNotes += "\n";
                        }
                        mergedNotes += sourceNotes;

                        if (destNotesMgr.NotesSlide != null &&
                            destNotesMgr.NotesSlide.NotesTextFrame != null)
                        {
                            destNotesMgr.NotesSlide.NotesTextFrame.Text = mergedNotes;
                        }

                        // Save the merged presentation
                        destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}