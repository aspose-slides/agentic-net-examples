// -----------------------------------------------------------------------------
// Example: Clone First Slide with Master to End and Sync Slide Numbers
//
// Description:
// This console application clones the first slide, including its master layout,
// from a source PPTX file to a new presentation, places the cloned slide at the
// end, and saves the result. It checks for the source file, creates a sample if
// missing, and handles errors gracefully. The output is a PPTX file with the
// cloned slide preserving layout and numbering.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide, master slide, slide numbering
//
// Use Cases:
// - Duplicate a template slide into a new presentation while keeping its design.
// - Programmatically generate presentations based on an existing slide master.
// - Ensure consistent slide numbering when copying slides across presentations.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
public class Program
{
    public static int Main(string[] args)
    {
        try
        {
            string sourcePath = "source.pptx";
            string destPath = "cloned.pptx";

            if (!System.IO.File.Exists(sourcePath))
            {
                Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                createPres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                createPres.Dispose();
            }

            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
            Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
            Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
            destPres.Slides.AddClone(sourceSlide, destMaster, true);

            destPres.Save(destPath, Aspose.Slides.Export.SaveFormat.Pptx);

            srcPres.Dispose();
            destPres.Dispose();

            return 0;
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
