using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string inputPath = "sample.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Retrieve all values of the SaveFormat enumeration (supported export formats)
            Array formatValues = Enum.GetValues(typeof(Aspose.Slides.Export.SaveFormat));

            // List each supported format
            foreach (object value in formatValues)
            {
                Aspose.Slides.Export.SaveFormat format = (Aspose.Slides.Export.SaveFormat)value;
                Console.WriteLine(format.ToString());
            }

            // Save the presentation before exiting (required)
            string outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}