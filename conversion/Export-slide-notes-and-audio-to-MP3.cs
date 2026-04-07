using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];

                    // Export notes to a text file
                    Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
                    if (notesSlide != null && notesSlide.NotesTextFrame != null)
                    {
                        string notesText = notesSlide.NotesTextFrame.Text;
                        string notesPath = Path.Combine(Environment.CurrentDirectory, $"Slide_{i + 1}_Notes.txt");
                        File.WriteAllText(notesPath, notesText);
                    }

                    // Export embedded audio from audio frames
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];
                        Aspose.Slides.IAudioFrame audioFrame = shape as Aspose.Slides.IAudioFrame;
                        if (audioFrame != null && audioFrame.EmbeddedAudio != null && audioFrame.EmbeddedAudio.BinaryData != null)
                        {
                            byte[] audioData = audioFrame.EmbeddedAudio.BinaryData;
                            string audioPath = Path.Combine(Environment.CurrentDirectory, $"Slide_{i + 1}_Audio.mp3");
                            File.WriteAllBytes(audioPath, audioData);
                        }
                    }
                }

                // Save the presentation before exiting
                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}