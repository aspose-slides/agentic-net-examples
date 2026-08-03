// -----------------------------------------------------------------------------
// Example: Extract text by language and save files using C#
//
// Description:
// Demonstrates how to extract text portions grouped by language identifier from
// a PowerPoint presentation and save each language's text into separate files.
// The example also shows how to save a copy of the processed presentation.
// It uses Aspose.Slides for .NET in a standalone console application.
// Developers can adapt this pattern to automate PPTX text extraction, language‑
// specific processing, or batch export scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Text, Language, Save,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Extract and export presentation text by language for localization.
// - Build tools that generate language‑specific text files from PPTX.
// - Automate saving modified presentations after processing.
// - Integrate language‑aware text extraction into .NET workflows.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExtractTextByLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation (lifecycle rule)
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Dictionary to hold extracted text grouped by language identifier
                Dictionary<string, StringBuilder> languageTexts = new Dictionary<string, StringBuilder>();

                // Retrieve all text frames from the presentation (including slides only)
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pres, false);

                // Iterate through each text frame, paragraph, and portion to collect language metadata
                foreach (Aspose.Slides.ITextFrame tf in textFrames)
                {
                    foreach (Aspose.Slides.IParagraph para in tf.Paragraphs)
                    {
                        foreach (Aspose.Slides.IPortion portion in para.Portions)
                        {
                            string languageId = portion.PortionFormat.LanguageId;
                            if (string.IsNullOrEmpty(languageId))
                            {
                                languageId = "unknown";
                            }

                            if (!languageTexts.ContainsKey(languageId))
                            {
                                languageTexts[languageId] = new StringBuilder();
                            }

                            languageTexts[languageId].AppendLine(portion.Text);
                        }
                    }
                }

                // Ensure output directory exists
                string outputDir = "output";
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Write each language group to a separate text file
                foreach (KeyValuePair<string, StringBuilder> kvp in languageTexts)
                {
                    string safeLanguageId = kvp.Key.Replace(Path.GetInvalidFileNameChars(), '_');
                    string outputPath = Path.Combine(outputDir, "text_" + safeLanguageId + ".txt");
                    File.WriteAllText(outputPath, kvp.Value.ToString());
                }

                // Save the presentation before exiting (lifecycle rule)
                string savedPresentationPath = Path.Combine(outputDir, "presentation_saved.pptx");
                pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported file format or other errors
                // Format not supported or other exception occurred
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    // Extension method to replace invalid filename characters
    static class StringExtensions
    {
        public static string Replace(this string str, char[] chars, char replacement)
        {
            foreach (char c in chars)
            {
                str = str.Replace(c, replacement);
            }
            return str;
        }
    }
}
