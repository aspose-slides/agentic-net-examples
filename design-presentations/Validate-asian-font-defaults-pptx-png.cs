using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateAsianFontDefaults
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPTX file
            string sourcePath = "input.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            try
            {
                // Set default Asian font via LoadOptions
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DefaultAsianFont = "Arial Unicode MS";

                // Load the presentation with the specified default Asian font
                using (Presentation presentation = new Presentation(sourcePath, loadOptions))
                {
                    // Export each slide to PNG using GetImage (GetThumbnail does not exist)
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        IImage image = slide.GetImage(); // default scaling
                        string pngPath = $"slide_{index}.png";
                        image.Save(pngPath, ImageFormat.Png);
                    }

                    // Save the presentation to a memory stream to compare with the original file
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        presentation.Save(memoryStream, SaveFormat.Pptx);
                        byte[] modifiedBytes = memoryStream.ToArray();
                        byte[] originalBytes = File.ReadAllBytes(sourcePath);
                        bool unchanged = originalBytes.SequenceEqual(modifiedBytes);
                        Console.WriteLine(unchanged ? "Presentation unchanged after export." : "Presentation was altered after export.");
                    }

                    // Save the presentation before exiting (as required)
                    presentation.Save("output_pres.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}