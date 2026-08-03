// -----------------------------------------------------------------------------
// Example: Clone presentation in memory for MathML export using C#
//
// Description:
// Demonstrates how to clone a PowerPoint presentation in memory and export
// any mathematical equations to MathML using Aspose.Slides for .NET. The
// example loads an existing PPTX, creates a deep clone of its slides and
// masters, saves the cloned presentation, and writes MathML for each math
// paragraph found in the cloned slides to an output file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Presentation, Memory,
// MathML, Math equations, Presentation processing, Office automation
//
// Use Cases:
// - Clone a presentation while preserving slide masters for further processing.
// - Export mathematical equations from PowerPoint slides to MathML.
// - Build .NET tools that manipulate PPTX files and extract MathML content.
// - Validate or transform presentations containing math equations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputMathMlPath = "output.mathml";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            for (int i = 0; i < srcPres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide sourceSlide = srcPres.Slides[i];
                Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);
            }

            destPres.Save("cloned.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            using (FileStream mathMlStream = new FileStream(outputMathMlPath, FileMode.Create, FileAccess.Write))
            {
                foreach (Aspose.Slides.ISlide slide in destPres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.MathText.IMathParagraph)
                        {
                            Aspose.Slides.MathText.IMathParagraph mathParagraph = (Aspose.Slides.MathText.IMathParagraph)shape;
                            mathParagraph.WriteAsMathMl(mathMlStream);
                        }
                    }
                }
            }

            srcPres.Dispose();
            destPres.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception)
        {
            // handle other exceptions
        }
    }
}
