// -----------------------------------------------------------------------------
// Example: Export Math Paragraph to MathML with Exception Handling
//
// Description:
// This console application creates a PowerPoint presentation using Aspose.Slides for .NET,
// adds a mathematical shape, and attempts to export the math paragraph to MathML.
// It catches and logs any exceptions thrown for unsupported MathBlock types during
// the WriteAsMathMl operation. The resulting presentation is saved as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, WriteAsMathMl, exception handling
//
// Use Cases:
// - Developers need to programmatically export equations from slides to MathML.
// - Handling scenarios where certain math elements are not supported for MathML export.
// - Automating creation and export of mathematical content in presentations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathMlExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputPath = "MathExportDemo.pptx";
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
            Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
            Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
            Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
            Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

            mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    mathParagraph.WriteAsMathMl(memoryStream);
                    memoryStream.Position = 0;
                    using (StreamReader reader = new StreamReader(memoryStream))
                    {
                        string mathMl = reader.ReadToEnd();
                        Console.WriteLine("MathML Export Successful:");
                        Console.WriteLine(mathMl);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error exporting MathML: " + ex.Message);
                }
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            presentation.Dispose();
        }
    }
}
