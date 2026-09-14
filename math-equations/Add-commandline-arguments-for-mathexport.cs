// -----------------------------------------------------------------------------
// Example: Export Math Paragraphs to LaTeX or MathML via Command-Line
//
// Description:
// This console application loads a PowerPoint PPTX file, locates mathematical
// shapes, and exports their content either as LaTeX strings or MathML XML
// based on a command‑line argument. It demonstrates Aspose.Slides for .NET
// handling of IMathParagraph, MathPortion, and file I/O while ensuring the
// presentation is saved before the program exits.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathParagraph, LaTeX, MathML, export
//
// Use Cases:
// - Generate LaTeX equations from a PPTX for inclusion in scientific documents.
// - Convert PowerPoint math objects to MathML for web publishing.
// - Automate batch processing of presentations to extract mathematical content.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace MathExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 3)
            {
                Console.WriteLine("Usage: MathExportExample <input.pptx> <outputFolder> <mode>");
                Console.WriteLine("Mode: paragraph (export LaTeX) or block (export MathML)");
                return;
            }

            string inputPath = args[0];
            string outputFolder = args[1];
            string mode = args[2].ToLowerInvariant();

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" does not exist.");
                return;
            }

            string extension = Path.GetExtension(inputPath);
            if (!string.Equals(extension, ".pptx", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Error: Unsupported file format. Only .pptx files are supported.");
                return;
            }

            try
            {
                Directory.CreateDirectory(outputFolder);

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        object shapeObj = slide.Shapes[shapeIndex];
                        if (shapeObj is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shapeObj;
                            if (autoShape.TextFrame != null &&
                                autoShape.TextFrame.Paragraphs.Count > 0 &&
                                autoShape.TextFrame.Paragraphs[0].Portions.Count > 0 &&
                                autoShape.TextFrame.Paragraphs[0].Portions[0] is Aspose.Slides.MathText.MathPortion)
                            {
                                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                                string fileNameBase = $"slide{slideIndex + 1}_shape{shapeIndex + 1}";
                                if (mode == "paragraph")
                                {
                                    string latex = mathParagraph.ToLatex();
                                    string outputFile = Path.Combine(outputFolder, fileNameBase + ".tex");
                                    File.WriteAllText(outputFile, latex);
                                    Console.WriteLine($"LaTeX exported to: {outputFile}");
                                }
                                else if (mode == "block")
                                {
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        mathParagraph.WriteAsMathMl(ms);
                                        ms.Position = 0;
                                        using (StreamReader reader = new StreamReader(ms))
                                        {
                                            string mathMl = reader.ReadToEnd();
                                            string outputFile = Path.Combine(outputFolder, fileNameBase + ".xml");
                                            File.WriteAllText(outputFile, mathMl);
                                            Console.WriteLine($"MathML exported to: {outputFile}");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error: Invalid mode specified. Use \"paragraph\" or \"block\".");
                                    presentation.Dispose();
                                    return;
                                }
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                string savedPresentationPath = Path.Combine(outputFolder, "modified.pptx");
                presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine($"Presentation saved to: {savedPresentationPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
