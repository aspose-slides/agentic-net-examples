using System;
using System.IO;
using Aspose.Slides.Export;

namespace ExportMathML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add a math shape to the first slide
                Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 300, 50);

                // Get the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;

                // Create a math block (x divided by y) using MathBlockFactory
                Aspose.Slides.MathText.MathBlockFactory blockFactory = new Aspose.Slides.MathText.MathBlockFactory();
                Aspose.Slides.MathText.IMathBlock mathBlock = blockFactory.CreateMathBlock(new Aspose.Slides.MathText.MathematicalText("x").Divide("y"));

                // Add the math block to the paragraph
                mathParagraph.Add(mathBlock);

                // UNC path where MathML will be saved
                string uncPath = @"\\Server\Share\MathML\equation.xml";

                try
                {
                    // Ensure the target directory exists
                    string directory = Path.GetDirectoryName(uncPath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    // Write MathML to the UNC path
                    using (FileStream fs = new FileStream(uncPath, FileMode.Create, FileAccess.Write))
                    {
                        mathBlock.WriteAsMathMl(fs);
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    // Handle missing directory or inaccessible network share
                    Console.WriteLine("Directory not found: " + ex.Message);
                }
                catch (IOException ex)
                {
                    // Handle other I/O errors (e.g., access denied)
                    Console.WriteLine("I/O error: " + ex.Message);
                }
                catch (NotSupportedException ex)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported: " + ex.Message);
                }

                // Save the presentation locally before exiting
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}