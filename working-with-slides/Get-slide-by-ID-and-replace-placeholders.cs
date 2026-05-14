using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Simulated database values
            Dictionary<string, string> placeholderData = new Dictionary<string, string>();
            placeholderData.Add("{{Name}}", "John Doe");
            placeholderData.Add("{{Date}}", DateTime.Today.ToShortDateString());

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Specify the slide ID to retrieve
                    uint slideId = 2; // Example ID

                    // Get the slide (or master/layout) by ID
                    IBaseSlide baseSlide = presentation.GetSlideById(slideId);
                    if (baseSlide == null)
                    {
                        Console.WriteLine("Slide with ID " + slideId + " not found.");
                        return;
                    }

                    // Iterate through shapes on the slide and replace placeholders
                    foreach (IShape shape in baseSlide.Shapes)
                    {
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            string originalText = autoShape.TextFrame.Text;
                            string updatedText = originalText;

                            foreach (KeyValuePair<string, string> entry in placeholderData)
                            {
                                if (updatedText.Contains(entry.Key))
                                {
                                    updatedText = updatedText.Replace(entry.Key, entry.Value);
                                }
                            }

                            if (!updatedText.Equals(originalText))
                            {
                                autoShape.TextFrame.Text = updatedText;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported (PPTX)
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Format not supported (PPT)
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}