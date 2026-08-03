// -----------------------------------------------------------------------------
// Example: Extract text to CSV by slide using C#
//
// Description:
// Demonstrates how to extract all textual content from each slide of a PowerPoint
// presentation and write it to a CSV file using C# and Aspose.Slides for .NET.
// The example iterates through slides, shapes, and grouped shapes, handling
// text extraction and proper CSV escaping. It can be used as a basis for
// automating PPTX content analysis or reporting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Text, Slide, CSV,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of slide text into CSV reports.
// - Build C# utilities for PowerPoint content auditing.
// - Generate data files for downstream analysis from PPTX presentations.
// - Validate and document presentation content before publishing.
// -----------------------------------------------------------------------------
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
