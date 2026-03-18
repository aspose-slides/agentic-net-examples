using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteVbaMacro
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFile = "input.pptx";
                string outputFile = "output_without_macros.pptx";

                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile, loadOptions))
                {
                    presentation.Save(outputFile, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}