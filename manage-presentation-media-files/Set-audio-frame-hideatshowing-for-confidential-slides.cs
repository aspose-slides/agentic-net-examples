// -----------------------------------------------------------------------------
// Example: Set audio frame hideatshowing for confidential slides using C#
//
// Description:
// Demonstrates how to set the HideAtShowing property of audio frames on slides
// that contain the word "confidential" using C# and Aspose.Slides for .NET.
// The example loads a presentation, scans each slide for confidential text,
// hides any audio frames on those slides, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, AudioFrame, HideAtShowing, 
// Confidential, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically hide audio frames on confidential slides before distribution.
// - Build C# utilities for PowerPoint content sanitization.
// - Integrate audio frame visibility control into .NET presentation workflows.
// - Ensure compliance with content policies in generated PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
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

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
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

                        // Check if the slide contains the word "confidential"
                        bool containsConfidential = false;
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                string text = autoShape.TextFrame.Text;
                                if (!string.IsNullOrEmpty(text) && text.IndexOf("confidential", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    containsConfidential = true;
                                    break;
                                }
                            }
                        }

                        // If confidential text is found, hide all audio frames on this slide
                        if (containsConfidential)
                        {
                            foreach (IShape shape in slide.Shapes)
                            {
                                if (shape is AudioFrame audioFrame)
                                {
                                    audioFrame.HideAtShowing = true;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
