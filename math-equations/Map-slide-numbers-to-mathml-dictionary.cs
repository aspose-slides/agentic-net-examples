using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathMlExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Export MathML strings for each slide
                Dictionary<int, string> slideMathMl = ExportMathMl(inputPath);

                // Display the results
                foreach (KeyValuePair<int, string> kvp in slideMathMl)
                {
                    Console.WriteLine($"Slide {kvp.Key} MathML:");
                    Console.WriteLine(kvp.Value);
                    Console.WriteLine();
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Returns a dictionary mapping slide numbers (1‑based) to MathML strings
        static Dictionary<int, string> ExportMathMl(string presentationPath)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            // Load the presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    string mathMl = string.Empty;

                    // Search for the first math shape on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IAutoShape)
                        {
                            IAutoShape autoShape = (IAutoShape)shape;
                            if (autoShape.TextFrame != null &&
                                autoShape.TextFrame.Paragraphs.Count > 0 &&
                                autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                            {
                                MathPortion mathPortion = autoShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion;
                                if (mathPortion != null)
                                {
                                    IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        mathParagraph.WriteAsMathMl(ms);
                                        ms.Position = 0;
                                        using (StreamReader reader = new StreamReader(ms))
                                        {
                                            mathMl = reader.ReadToEnd();
                                        }
                                    }
                                    break; // Math shape found, stop searching this slide
                                }
                            }
                        }
                    }

                    // Store the MathML (empty string if no math shape found)
                    result.Add(i + 1, mathMl);
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save(presentationPath, SaveFormat.Pptx);
            }

            return result;
        }
    }
}