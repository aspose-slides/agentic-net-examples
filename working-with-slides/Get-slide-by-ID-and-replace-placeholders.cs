// -----------------------------------------------------------------------------
// Example: Replace placeholders on a slide retrieved by ID using Aspose.Slides
//
// Description:
// This console program loads a PowerPoint PPTX file, retrieves a specific slide
// by its unique identifier, replaces text placeholders within shapes on that
// slide using values from a dictionary, and saves the modified presentation.
// It creates a sample input file if none exists, demonstrating automated PPTX
// content updates with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide ID, Placeholder Replacement
//
// Use Cases:
// - Update specific slides in a presentation based on slide ID.
// - Replace dynamic text placeholders (e.g., {{Name}}, {{Date}}) with runtime data.
// - Automate generation of personalized PowerPoint files in .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; create a simple presentation if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ILayoutSlide layout = samplePresentation.Slides[0].LayoutSlide;
                    Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides.AddEmptySlide(layout);
                    Aspose.Slides.IAutoShape placeholderShape = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                    placeholderShape.TextFrame.Text = "Hello {{Name}}, today is {{Date}}.";
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample input file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify that the input file now exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                Environment.Exit(1);
            }

            // Placeholder values
            Dictionary<string, string> placeholderData = new Dictionary<string, string>();
            placeholderData.Add("{{Name}}", "John Doe");
            placeholderData.Add("{{Date}}", DateTime.Today.ToShortDateString());

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the ID of the first slide (or any desired slide)
                    uint slideId = presentation.Slides[0].SlideId;

                    // Get slide by ID (GetSlideById returns IBaseSlide, cast to ISlide)
                    Aspose.Slides.ISlide targetSlide = presentation.GetSlideById(slideId) as Aspose.Slides.ISlide;
                    if (targetSlide == null)
                    {
                        Console.WriteLine("Slide with ID " + slideId + " not found.");
                        Environment.Exit(1);
                    }

                    // Replace placeholders in text frames
                    foreach (Aspose.Slides.IShape shape in targetSlide.Shapes)
                    {
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
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
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                Environment.Exit(1);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
