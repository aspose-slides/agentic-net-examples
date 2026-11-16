// -----------------------------------------------------------------------------
// Example: Clone Slide with Animations and Master to New Presentation
//
// Description:
// This console program loads a source PPTX file, clones its first slide together
// with the associated master and any animations, removes the default empty slide
// from the new presentation, and saves the result as a new PPTX file. It creates
// a sample source file if none exists and demonstrates slide reuse across
// presentations using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide, animations, master slide
//
// Use Cases:
// - Reusing a slide with its animation effects in multiple presentations.
// - Automating slide duplication while preserving design templates.
// - Building a library of animated slides for dynamic content generation.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
public class Program
{
    public static void Main()
    {
        string sourcePath = "source.pptx";
        string destPath = "cloned.pptx";

        try
        {
            if (!System.IO.File.Exists(sourcePath))
            {
                Aspose.Slides.Presentation sourcePresCreate = new Aspose.Slides.Presentation();
                sourcePresCreate.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                sourcePresCreate.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                sourcePresCreate.Dispose();
            }

            Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];
            Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
            Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
            destPres.Slides.AddClone(sourceSlide, destMaster, true);
            destPres.Slides.RemoveAt(0);

            destPres.Save(destPath, Aspose.Slides.Export.SaveFormat.Pptx);

            sourcePres.Dispose();
            destPres.Dispose();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
            System.Environment.ExitCode = 1;
        }
    }
}
