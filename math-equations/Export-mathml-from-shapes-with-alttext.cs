using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExportMathML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output presentation files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Presentation pres = null;
            try
            {
                // Load presentation
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate through slides and shapes
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Process only shapes that have alternative text defined
                    if (!string.IsNullOrEmpty(shape.AlternativeText))
                    {
                        // Check if shape is a math shape (IAutoShape with MathPortion)
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                        {
                            IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                            if (paragraph.Portions.Count > 0)
                            {
                                IPortion portion = paragraph.Portions[0];
                                MathPortion mathPortion = portion as MathPortion;
                                if (mathPortion != null)
                                {
                                    IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                    if (mathParagraph != null)
                                    {
                                        // Export MathML to a file named after the alternative text
                                        string safeAltText = shape.AlternativeText.Replace(Path.GetInvalidFileNameChars(), '_');
                                        string mathmlPath = safeAltText + ".xml";
                                        try
                                        {
                                            using (FileStream fs = new FileStream(mathmlPath, FileMode.Create, FileAccess.Write))
                                            {
                                                mathParagraph.WriteAsMathMl(fs);
                                            }
                                            Console.WriteLine("Exported MathML for shape with alt text '{0}' to {1}", shape.AlternativeText, mathmlPath);
                                        }
                                        catch (Exception exportEx)
                                        {
                                            Console.WriteLine("Failed to export MathML for shape '{0}': {1}", shape.AlternativeText, exportEx.Message);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Save presentation before exit
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception saveEx)
            {
                Console.WriteLine("Failed to save presentation: " + saveEx.Message);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }

    // Helper extension to replace invalid filename characters
    static class StringExtensions
    {
        public static string Replace(this string str, char[] chars, char replacement)
        {
            foreach (char c in chars)
            {
                str = str.Replace(c.ToString(), replacement.ToString());
            }
            return str;
        }
    }
}