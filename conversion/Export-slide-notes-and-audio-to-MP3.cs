using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        // Export notes (saved as .mp3 file for naming consistency)
                        INotesSlideManager notesMgr = pres.Slides[i].NotesSlideManager;
                        INotesSlide notesSlide = notesMgr.NotesSlide;
                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            string notesText = notesSlide.NotesTextFrame.Text;
                            string notesPath = Path.Combine(Environment.CurrentDirectory, $"Slide_{i}_Notes.mp3");
                            File.WriteAllBytes(notesPath, System.Text.Encoding.UTF8.GetBytes(notesText));
                        }

                        // Export embedded audio from audio frames on the slide
                        foreach (IShape shape in pres.Slides[i].Shapes)
                        {
                            if (shape is IAudioFrame)
                            {
                                IAudioFrame audioFrame = (IAudioFrame)shape;
                                IAudio embeddedAudio = audioFrame.EmbeddedAudio;
                                if (embeddedAudio != null && embeddedAudio.BinaryData != null)
                                {
                                    string audioPath = Path.Combine(Environment.CurrentDirectory, $"Slide_{i}_Audio.mp3");
                                    File.WriteAllBytes(audioPath, embeddedAudio.BinaryData);
                                }
                            }
                        }
                    }

                    // Save presentation before exit
                    string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}