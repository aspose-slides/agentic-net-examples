using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeThumbnailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (can be a local file or a URL)
            string inputPath = "input.pptx";

            // Verify that the file exists if it's a local path
            if (!Uri.IsWellFormedUriString(inputPath, UriKind.Absolute) && !File.Exists(inputPath))
            {
                Console.WriteLine("The specified presentation file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Process only group shapes
                            if (shape is IGroupShape groupShape)
                            {
                                // Get the thumbnail image of the group shape
                                IImage groupImage = groupShape.GetImage();

                                // Build an output file name
                                string safeGroupName = string.IsNullOrEmpty(groupShape.Name) ? "UnnamedGroup" : groupShape.Name.Replace(Path.GetInvalidFileNameChars(), '_');
                                string outputImagePath = $"GroupSlide_{slideIndex + 1}_{safeGroupName}.png";

                                // Save the thumbnail as PNG
                                groupImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                                Console.WriteLine("Saved group thumbnail: " + outputImagePath);
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (System.Net.WebException)
            {
                // External URL could not be accessed
                Console.WriteLine("Failed to load presentation from the specified URL.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    // Extension method to replace invalid filename characters
    static class StringExtensions
    {
        public static string Replace(this string str, char[] chars, char replacement)
        {
            foreach (char c in chars)
            {
                str = str.Replace(c, replacement);
            }
            return str;
        }
    }
}