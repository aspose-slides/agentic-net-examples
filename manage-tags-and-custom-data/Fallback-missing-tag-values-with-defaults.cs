using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Default placeholder values used when a tag is missing
                Dictionary<string, string> defaultPlaceholders = new Dictionary<string, string>();
                defaultPlaceholders.Add("Title", "Default Title");
                defaultPlaceholders.Add("Author", "Default Author");

                // Access the presentation's custom tags
                TagCollection tagCollection = (TagCollection)presentation.CustomData.Tags;

                // Iterate through all slides and replace placeholders
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only AutoShapes that contain a TextFrame
                        if (shape is IAutoShape)
                        {
                            IAutoShape autoShape = (IAutoShape)shape;

                            if (autoShape.TextFrame != null)
                            {
                                string text = autoShape.TextFrame.Text;

                                // Replace each placeholder with the tag value or the default
                                foreach (KeyValuePair<string, string> kvp in defaultPlaceholders)
                                {
                                    string placeholder = "{{" + kvp.Key + "}}";
                                    string replacement;

                                    if (tagCollection.Contains(kvp.Key))
                                    {
                                        replacement = tagCollection[kvp.Key];
                                    }
                                    else
                                    {
                                        replacement = kvp.Value; // Use default if tag is missing
                                    }

                                    text = text.Replace(placeholder, replacement);
                                }

                                // Update the shape's text
                                autoShape.TextFrame.Text = text;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network issues if external resources are used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}