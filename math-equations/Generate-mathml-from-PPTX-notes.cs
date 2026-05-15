using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathMlExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder containing presentations
            string inputFolder = args.Length > 0 ? args[0] : "Presentations";
            // Output folder for MathML files
            string outputFolder = args.Length > 1 ? args[1] : "MathML";

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            Directory.CreateDirectory(outputFolder);

            string[] presentationFiles = Directory.GetFiles(inputFolder);
            foreach (string filePath in presentationFiles)
            {
                try
                {
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.ITextFrame textFrame = shape as Aspose.Slides.ITextFrame;
                            if (textFrame != null)
                            {
                                for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                                {
                                    IMathParagraph mathParagraph = textFrame.Paragraphs[paraIndex] as IMathParagraph;
                                    if (mathParagraph != null)
                                    {
                                        string mathFileName = Path.GetFileNameWithoutExtension(filePath) +
                                            $"_slide{slideIndex + 1}_para{paraIndex + 1}.mathml";
                                        string mathFilePath = Path.Combine(outputFolder, mathFileName);

                                        using (FileStream fs = new FileStream(mathFilePath, FileMode.Create, FileAccess.Write))
                                        {
                                            mathParagraph.WriteAsMathMl(fs);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation (no modifications) before exiting
                    pres.Save(filePath, SaveFormat.Pptx);
                    pres.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("File format not supported: " + filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
                }
            }
        }
    }
}