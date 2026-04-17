using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveSectionNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input file path and section name
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: RemoveSectionNotes <input-pptx> <section-name>");
                return;
            }

            string inputPath = args[0];
            string targetSectionName = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File does not exist - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Find the section with the specified name
                    ISection targetSection = null;
                    foreach (ISection section in presentation.Sections)
                    {
                        if (section.Name == targetSectionName)
                        {
                            targetSection = section;
                            break;
                        }
                    }

                    if (targetSection == null)
                    {
                        Console.WriteLine("Error: Section not found - " + targetSectionName);
                        return;
                    }

                    // Get all slides belonging to the section
                    ISectionSlideCollection slidesInSection = targetSection.GetSlidesListOfSection();

                    // Remove notes from each slide in the section
                    foreach (ISlide slide in slidesInSection)
                    {
                        INotesSlideManager notesManager = slide.NotesSlideManager;
                        // Remove notes if they exist
                        if (notesManager.NotesSlide != null)
                        {
                            notesManager.RemoveNotesSlide();
                        }
                    }

                    // Save the modified presentation
                    string outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath),
                        Path.GetFileNameWithoutExtension(inputPath) + "_NoNotes.pptx");

                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Error: The requested save format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}