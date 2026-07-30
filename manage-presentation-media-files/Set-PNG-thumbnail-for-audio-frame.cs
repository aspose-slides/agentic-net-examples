// -----------------------------------------------------------------------------
// Example: Set PNG thumbnail for audio frame using C#
//
// Description:
// Demonstrates how to set a custom PNG thumbnail for an audio frame using C# 
// and Aspose.Slides for .NET. The example creates a new presentation, adds an 
// embedded audio frame, configures its playback settings, assigns a PNG image 
// as the thumbnail, and saves the result as a PPTX file. This pattern can be 
// used to automate PowerPoint media handling, customize audio presentation 
// visuals, or integrate media processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Thumbnail, Audio, Frame, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a PNG thumbnail for an audio frame in a presentation.
// - Build C# tools for PowerPoint media management and customization.
// - Generate or modify PPTX files with embedded audio and custom visuals.
// - Validate and test presentation workflows involving audio assets.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioFrameThumbnailExample
{
    class Program
    {
        static void Main()
        {
            // Input files
            string audioFilePath = "sampleaudio.wav";
            string thumbnailFilePath = "thumbnail.png";
            // Output presentation
            string outputFilePath = "AudioFrameWithThumbnail.pptx";

            // Verify input files exist
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine("Audio file not found: " + audioFilePath);
                return;
            }
            if (!File.Exists(thumbnailFilePath))
            {
                Console.WriteLine("Thumbnail image file not found: " + thumbnailFilePath);
                return;
            }

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add an audio frame to the slide
                    using (FileStream audioStream = new FileStream(audioFilePath, FileMode.Open, FileAccess.Read))
                    {
                        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                        // Configure audio playback
                        audioFrame.PlayAcrossSlides = true;
                        audioFrame.RewindAudio = true;
                        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                        // Hide the audio frame during slide show
                        audioFrame.HideAtShowing = true;

                        // Add custom PNG thumbnail and assign it to the audio frame
                        using (FileStream imageStream = new FileStream(thumbnailFilePath, FileMode.Open, FileAccess.Read))
                        {
                            Aspose.Slides.IPPImage pngImage = presentation.Images.AddImage(imageStream);
                            // Set the picture of the audio frame to the custom image
                            audioFrame.PictureFormat.Picture.Image = pngImage;
                        }

                        // Save the presentation
                        presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
