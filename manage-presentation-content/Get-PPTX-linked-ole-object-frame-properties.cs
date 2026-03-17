using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = presentation.Slides[0];
                var oleFrame = slide.Shapes[0] as Aspose.Slides.IOleObjectFrame;

                if (oleFrame != null)
                {
                    Console.WriteLine("Is linked: " + oleFrame.IsObjectLink);
                    Console.WriteLine("Long link path: " + oleFrame.LinkPathLong);
                    Console.WriteLine("Relative link path: " + oleFrame.LinkPathRelative);
                    Console.WriteLine("Update automatically: " + oleFrame.UpdateAutomatic);

                    // Modify writable properties
                    oleFrame.UpdateAutomatic = false;
                    oleFrame.LinkPathLong = @"C:\NewFolder\newfile.xlsx";
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}