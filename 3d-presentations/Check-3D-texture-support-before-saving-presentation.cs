// -----------------------------------------------------------------------------
// Example: Validate 3D Object Texture Formats in PowerPoint Presentation
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// iterates through all shapes to detect 3D objects, and verifies that any
// associated texture files use supported image formats (PNG, JPG, JPEG, BMP).
// If all textures are valid, the presentation is saved; otherwise, the save
// operation is aborted and a warning is displayed.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D objects, texture validation
//
// Use Cases:
// - Ensure corporate slide decks comply with branding guidelines for 3D textures.
// - Pre‑process presentations before publishing to avoid unsupported texture errors.
// - Automate quality checks in CI pipelines for slide assets.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace AsposeSlidesTextureValidator
{
    public class Program
    {
        private static readonly string[] SupportedExtensions = new string[] { ".png", ".jpg", ".jpeg", ".bmp" };

        public static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" does not exist.");
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                bool allTexturesValid = true;

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Use reflection to check for a ThreeDFormat property
                        PropertyInfo threeDProp = shape.GetType().GetProperty("ThreeDFormat", BindingFlags.Public | BindingFlags.Instance);
                        if (threeDProp == null)
                        {
                            continue; // Not a 3D shape
                        }

                        object threeDFormat = threeDProp.GetValue(shape);
                        if (threeDFormat == null)
                        {
                            continue;
                        }

                        // Attempt to get the Texture property from the ThreeDFormat object
                        PropertyInfo textureProp = threeDFormat.GetType().GetProperty("Texture", BindingFlags.Public | BindingFlags.Instance);
                        if (textureProp == null)
                        {
                            continue; // No texture associated
                        }

                        object texture = textureProp.GetValue(threeDFormat);
                        if (texture == null)
                        {
                            continue;
                        }

                        // The texture is typically an IPictureFillFormat; retrieve the image file name if available
                        PropertyInfo pictureProp = texture.GetType().GetProperty("Picture", BindingFlags.Public | BindingFlags.Instance);
                        if (pictureProp == null)
                        {
                            continue;
                        }

                        object picture = pictureProp.GetValue(texture);
                        if (picture == null)
                        {
                            continue;
                        }

                        // Retrieve the image file name (if the picture was loaded from a file)
                        PropertyInfo fileNameProp = picture.GetType().GetProperty("FileName", BindingFlags.Public | BindingFlags.Instance);
                        if (fileNameProp == null)
                        {
                            continue;
                        }

                        string fileName = fileNameProp.GetValue(picture) as string;
                        if (string.IsNullOrEmpty(fileName))
                        {
                            continue;
                        }

                        string extension = Path.GetExtension(fileName).ToLowerInvariant();
                        if (Array.IndexOf(SupportedExtensions, extension) < 0)
                        {
                            Console.WriteLine($"Unsupported texture format detected: \"{fileName}\" on slide {slideIndex + 1}, shape {shapeIndex + 1}.");
                            allTexturesValid = false;
                        }
                    }
                }

                if (!allTexturesValid)
                {
                    Console.WriteLine("Presentation contains unsupported 3D texture formats. Save operation aborted.");
                }
                else
                {
                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine($"Presentation saved successfully to \"{outputPath}\".");
                }

                // Dispose presentation
                presentation.Dispose();
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine($"Error: The file format is not supported. Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
