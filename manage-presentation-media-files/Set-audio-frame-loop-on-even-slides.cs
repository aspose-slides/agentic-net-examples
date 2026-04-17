using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioLoopExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input audio file path
            string audioFilePath = "sample.wav";

            // Check if the audio file exists
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine("Audio file not found: " + audioFilePath);
                return;
            }

            // Output presentation path
            string outputPath = "output.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a few slides and embed an audio frame in each slide
                for (int slideIndex = 0; slideIndex < 4; slideIndex++)
                {
                    // Ensure the slide exists (Presentation starts with one slide)
                    ISlide slide;
                    if (presentation.Slides.Count > slideIndex)
                    {
                        slide = presentation.Slides[slideIndex];
                    }
                    else
                    {
                        slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                    }

                    // Open audio stream
                    FileStream audioStream = new FileStream(audioFilePath, FileMode.Open, FileAccess.Read);
                    // Add audio frame (embedded)
                    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                    // Close the stream after embedding
                    audioStream.Close();
                }

                // Set PlayLoopMode = true for audio frames on even-indexed slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IAudioFrame)
                        {
                            IAudioFrame audioFrame = (IAudioFrame)shape;
                            if (slideIndex % 2 == 0)
                            {
                                audioFrame.PlayLoopMode = true;
                            }
                            else
                            {
                                audioFrame.PlayLoopMode = false;
                            }
                        }
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}