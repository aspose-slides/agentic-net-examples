using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace SlidesMathMlExporter
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Dictionary<int, string> mathMlMap = ExportMathMl(inputPath);
                foreach (KeyValuePair<int, string> entry in mathMlMap)
                {
                    Console.WriteLine($"Slide {entry.Key} MathML:");
                    Console.WriteLine(entry.Value);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static Dictionary<int, string> ExportMathMl(string presentationPath)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Save presentation before exit as required
                presentation.Save("temp_saved.pptx", SaveFormat.Pptx);

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    StringBuilder slideMathMl = new StringBuilder();

                    foreach (IShape shape in slide.Shapes)
                    {
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape == null || autoShape.TextFrame == null)
                            continue;

                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                MathPortion mathPortion = portion as MathPortion;
                                if (mathPortion == null)
                                    continue;

                                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    mathParagraph.WriteAsMathMl(ms);
                                    ms.Position = 0;
                                    using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
                                    {
                                        string mathMl = reader.ReadToEnd();
                                        slideMathMl.AppendLine(mathMl);
                                    }
                                }
                            }
                        }
                    }

                    if (slideMathMl.Length > 0)
                    {
                        result.Add(i + 1, slideMathMl.ToString());
                    }
                }
            }

            return result;
        }
    }
}