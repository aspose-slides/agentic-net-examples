using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesMathMLExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "input.pptx";
            string tempPath = "temp_clone.pptx";
            string mathMlPath = "output.xml";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            try
            {
                using (Presentation srcPres = new Presentation(sourcePath))
                {
                    using (Presentation tempPres = new Presentation())
                    {
                        // Clone slide with its master to temporary presentation
                        ISlide sourceSlide = srcPres.Slides[0];
                        IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                        IMasterSlide destMaster = tempPres.Masters.AddClone(sourceMaster);
                        tempPres.Slides.AddClone(sourceSlide, destMaster, true);

                        // Save temporary presentation before exit
                        tempPres.Save(tempPath, SaveFormat.Pptx);

                        // Attempt to export MathML from the first shape if it is a MathParagraph
                        IMathParagraph mathParagraph = tempPres.Slides[0].Shapes[0] as IMathParagraph;
                        if (mathParagraph != null)
                        {
                            using (FileStream fs = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write))
                            {
                                mathParagraph.WriteAsMathMl(fs);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No MathParagraph found on the cloned slide.");
                        }
                    }
                }

                // Clean up temporary file if desired
                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}