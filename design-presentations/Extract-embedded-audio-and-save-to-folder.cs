using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation
        string inputPath = "input.pptx";
        // Folder where extracted audio files will be saved
        string outputFolder = "ExtractedAudios";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(outputFolder);

                // Iterate through all embedded audio clips
                for (int i = 0; i < pres.Audios.Count; i++)
                {
                    Aspose.Slides.IAudio audio = pres.Audios[i];
                    if (audio != null && audio.BinaryData != null)
                    {
                        // Determine a file name for the extracted audio
                        string outPath = Path.Combine(outputFolder, "audio_" + i + ".wav");
                        // Write the audio binary data to disk
                        File.WriteAllBytes(outPath, audio.BinaryData);
                    }
                }

                // Save the presentation before exiting (overwrites the original file)
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}