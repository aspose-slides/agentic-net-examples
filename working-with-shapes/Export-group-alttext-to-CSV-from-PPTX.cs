using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputCsvPath = "groups_alttext.csv";
        string outputPresPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                using (StreamWriter sw = new StreamWriter(outputCsvPath))
                {
                    sw.WriteLine("SlideIndex,GroupIndex,AltText");
                    int slideIndex = 0;
                    foreach (ISlide slide in pres.Slides)
                    {
                        slideIndex++;
                        int groupIndex = 0;
                        foreach (IShape shape in slide.Shapes)
                        {
                            IGroupShape groupShape = shape as IGroupShape;
                            if (groupShape != null)
                            {
                                groupIndex++;
                                string altText = groupShape.AlternativeText ?? "";
                                altText = altText.Replace("\"", "\"\"");
                                sw.WriteLine($"{slideIndex},{groupIndex},\"{altText}\"");
                            }
                        }
                    }
                }

                pres.Save(outputPresPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}