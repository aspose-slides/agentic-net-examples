using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputCsv = "groups_alttext.csv";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create CSV file and write header
                    using (StreamWriter sw = new StreamWriter(outputCsv))
                    {
                        sw.WriteLine("SlideIndex,GroupIndex,AltText");

                        int slideIndex = 0;
                        foreach (ISlide slide in pres.Slides)
                        {
                            int groupIndex = 0;
                            foreach (IShape shape in slide.Shapes)
                            {
                                IGroupShape groupShape = shape as IGroupShape;
                                if (groupShape != null)
                                {
                                    string altText = groupShape.AlternativeText ?? string.Empty;
                                    // Escape double quotes in AltText
                                    string escapedAltText = altText.Replace("\"", "\"\"");
                                    sw.WriteLine(string.Format("{0},{1},\"{2}\"", slideIndex, groupIndex, escapedAltText));
                                    groupIndex++;
                                }
                            }
                            slideIndex++;
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    pres.Save("output.pptx", SaveFormat.Pptx);
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
}