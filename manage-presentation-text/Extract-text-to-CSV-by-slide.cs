using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractTextToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputCsv = "output.csv";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    using (StreamWriter writer = new StreamWriter(outputCsv, false))
                    {
                        writer.WriteLine("SlideNumber,ShapeName,Text");
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                            ISlide slide = presentation.Slides[i];
                            int slideNumber = slide.SlideNumber;

                            foreach (IShape shape in slide.Shapes)
                            {
                                string shapeName = shape.Name;
                                string text = string.Empty;

                                if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                                {
                                    text = autoShape.TextFrame.Text;
                                }
                                else if (shape is IGroupShape groupShape)
                                {
                                    foreach (IShape innerShape in groupShape.Shapes)
                                    {
                                        if (innerShape is IAutoShape innerAuto && innerAuto.TextFrame != null)
                                        {
                                            string innerName = innerShape.Name;
                                            string innerText = innerAuto.TextFrame.Text;
                                            writer.WriteLine($"{slideNumber},\"{innerName}\",\"{innerText.Replace("\"", "\"\"")}\"");
                                        }
                                    }
                                    continue;
                                }

                                if (!string.IsNullOrEmpty(text))
                                {
                                    writer.WriteLine($"{slideNumber},\"{shapeName}\",\"{text.Replace("\"", "\"\"")}\"");
                                }
                            }
                        }
                    }

                    // Save the presentation (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}