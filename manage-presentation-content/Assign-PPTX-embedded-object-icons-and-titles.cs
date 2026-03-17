using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through shapes on the first slide
                foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
                {
                    Aspose.Slides.OleObjectFrame oleObject = shape as Aspose.Slides.OleObjectFrame;
                    if (oleObject != null)
                    {
                        // Display the OLE object as an icon
                        oleObject.IsObjectIcon = true;

                        // Set custom title for the icon
                        oleObject.SubstitutePictureTitle = "Custom Icon Title";

                        // Optionally set alternative text title
                        oleObject.AlternativeTextTitle = "Custom Alt Title";
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}