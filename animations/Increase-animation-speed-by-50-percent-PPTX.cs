using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace IncreaseAnimationSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input folder and output folder
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: IncreaseAnimationSpeed <inputFolder> <outputFolder>");
                return;
            }

            string inputFolder = args[0];
            string outputFolder = args[1];

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"Input folder does not exist: {inputFolder}");
                return;
            }

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Process each supported presentation file in the input folder
            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".potx", ".potm" };
            foreach (string filePath in Directory.GetFiles(inputFolder))
            {
                string extension = Path.GetExtension(filePath);
                if (Array.IndexOf(supportedExtensions, extension.ToLowerInvariant()) < 0)
                {
                    // Skip unsupported formats
                    Console.WriteLine($"Skipping unsupported file format: {filePath}");
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Iterate through all slides
                        int slideCount = presentation.Slides.Count;
                        for (int i = 0; i < slideCount; i++)
                        {
                            ISlide slide = presentation.Slides[i];

                            // Access the main animation sequence of the slide
                            ISequence mainSequence = slide.Timeline.MainSequence;
                            int effectCount = mainSequence.Count;

                            // Increase speed of each effect by 50%
                            for (int j = 0; j < effectCount; j++)
                            {
                                IEffect effect = mainSequence[j];
                                float currentSpeed = effect.Timing.Speed;
                                // Multiply by 1.5 to increase speed by 50%
                                effect.Timing.Speed = currentSpeed * 1.5f;
                            }
                        }

                        // Save the modified presentation to the output folder
                        string outputFilePath = Path.Combine(outputFolder, Path.GetFileName(filePath));
                        presentation.Save(outputFilePath, SaveFormat.Pptx);
                    }

                    Console.WriteLine($"Processed: {Path.GetFileName(filePath)}");
                }
                catch (NotSupportedException)
                {
                    // Format not supported for saving
                    Console.WriteLine($"Format not supported for file: {filePath}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }
    }
}