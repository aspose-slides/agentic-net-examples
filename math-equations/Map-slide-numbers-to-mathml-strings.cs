// -----------------------------------------------------------------------------
// Example: Export MathML from each slide in a PowerPoint presentation using Aspose.Slides
//
// Description:
// This console application opens a PPTX file, iterates through its slides,
// extracts MathML from all math shapes on each slide, and returns a dictionary
// mapping slide numbers (1‑based) to the concatenated MathML strings. It uses
// Aspose.Slides for .NET to access math paragraphs and writes the presentation
// back before exiting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, export, slide iteration
//
// Use Cases:
// - Generate MathML for downstream processing or web rendering.
// - Validate mathematical content across presentation slides.
// - Integrate PowerPoint math extraction into automated documentation pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;

namespace AsposeSlidesMathMlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            try
            {
                Dictionary<int, string> slideMathMlMap = ExportMathMlBySlide(inputPath);
                foreach (KeyValuePair<int, string> kvp in slideMathMlMap)
                {
                    Console.WriteLine("Slide {0} MathML:", kvp.Key);
                    Console.WriteLine(kvp.Value);
                    Console.WriteLine(new string('-', 40));
                }

                // Save the presentation (no modifications made, but required by specification)
                string outputPath = "output.pptx";
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static Dictionary<int, string> ExportMathMlBySlide(string presentationPath)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath);

            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                System.Text.StringBuilder slideMathMlBuilder = new System.Text.StringBuilder();

                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                    if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                        if (paragraph.Portions.Count > 0)
                        {
                            Aspose.Slides.IPortion firstPortion = paragraph.Portions[0];
                            Aspose.Slides.MathText.MathPortion mathPortion = firstPortion as Aspose.Slides.MathText.MathPortion;

                            if (mathPortion != null)
                            {
                                Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    mathParagraph.WriteAsMathMl(ms);
                                    ms.Position = 0;
                                    using (StreamReader reader = new StreamReader(ms))
                                    {
                                        string mathMl = reader.ReadToEnd();
                                        slideMathMlBuilder.AppendLine(mathMl);
                                    }
                                }
                            }
                        }
                    }
                }

                result.Add(slideIndex + 1, slideMathMlBuilder.ToString().Trim());
            }

            return result;
        }
    }
}
