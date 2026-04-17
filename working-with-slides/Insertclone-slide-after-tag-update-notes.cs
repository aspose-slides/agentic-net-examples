using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertCloneSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Tag to search for
                    string targetTagName = "MyTag";
                    string targetTagValue = "CloneAfterMe";

                    // Find the slide with the specific tag
                    ISlide sourceSlide = null;
                    int sourceIndex = -1;
                    ISlideCollection slides = presentation.Slides;
                    for (int i = 0; i < slides.Count; i++)
                    {
                        ISlide slide = slides[i];
                        // Access tags via CustomData.Tags (slide.Tags does not exist)
                        ITagCollection tags = slide.CustomData.Tags;
                        if (tags != null && tags.Contains(targetTagName) && tags[targetTagName] == targetTagValue)
                        {
                            sourceSlide = slide;
                            sourceIndex = i;
                            break;
                        }
                    }

                    if (sourceSlide == null)
                    {
                        Console.WriteLine("No slide with the specified tag was found.");
                        return;
                    }

                    // Insert a clone of the found slide after it
                    int insertIndex = sourceIndex + 1;
                    ISlide clonedSlide = slides.InsertClone(insertIndex, sourceSlide);

                    // Update notes of the cloned slide
                    INotesSlideManager notesManager = clonedSlide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.AddNotesSlide();
                    notesSlide.NotesTextFrame.Text = "Notes for the cloned slide.";

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}