using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        // Output directory for extracted audio files
        string outputDir = Path.Combine(Environment.CurrentDirectory, "ExtractedAudios");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file does not exist: " + inputPath);
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all embedded audios
            Aspose.Slides.IAudioCollection audioCollection = pres.Audios;
            for (int i = 0; i < audioCollection.Count; i++)
            {
                Aspose.Slides.IAudio audio = audioCollection[i];
                if (audio != null && audio.BinaryData != null)
                {
                    // Determine file extension from content type if possible
                    string extension = "bin";
                    try
                    {
                        string contentType = audio.ContentType; // e.g., "audio/mpeg"
                        int slashIndex = contentType.LastIndexOf('/');
                        if (slashIndex >= 0 && slashIndex < contentType.Length - 1)
                        {
                            extension = contentType.Substring(slashIndex + 1);
                        }
                    }
                    catch
                    {
                        // Fallback to default extension
                    }

                    // Build output file path
                    string outFile = Path.Combine(outputDir, $"audio_{i}.{extension}");
                    // Write audio bytes to file
                    File.WriteAllBytes(outFile, audio.BinaryData);
                }
            }

            // Save the presentation before exiting (as required)
            string savedPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
            pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}