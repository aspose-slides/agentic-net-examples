using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            int targetTableIndex = 0; // zero‑based index of the table in the presentation

            using (Presentation presentation = new Presentation(inputPath))
            {
                ISlide targetSlide = null;
                int currentTableIndex = 0;

                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is ITable)
                        {
                            if (currentTableIndex == targetTableIndex)
                            {
                                targetSlide = slide;
                                break;
                            }
                            currentTableIndex++;
                        }
                    }
                    if (targetSlide != null)
                        break;
                }

                if (targetSlide != null)
                {
                    int slidePosition = presentation.Slides.IndexOf(targetSlide);
                    Console.WriteLine("Found slide containing the table at slide index: " + slidePosition);
                }
                else
                {
                    Console.WriteLine("Table with the specified index was not found.");
                }

                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}