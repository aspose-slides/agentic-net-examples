// -----------------------------------------------------------------------------
// Example: Export Group Alternative Text to CSV from PPTX using C#
//
// Description:
// This console application loads a PowerPoint PPTX file, extracts the
// AlternativeText of each group shape on every slide, and writes the data to
// a CSV file. If the input PPTX does not exist, a sample presentation with a
// group shape and alt text is created automatically. The resulting CSV can be
// used for accessibility audits or metadata reporting.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export Group AltText CSV
//
// Use Cases:
// - Automate extraction of group alt text for accessibility compliance.
// - Generate CSV reports of presentation metadata for content management.
// - Integrate PowerPoint analysis into .NET batch processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputCsv = "groups_alttext.csv";

            try
            {
                if (!File.Exists(inputPath))
                {
                    // Create a sample presentation with a group shape containing alt text
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IGroupShape sampleGroup = sampleSlide.Shapes.AddGroupShape((Aspose.Slides.ISvgImage) null, 50, 50, 400, 300);
                    sampleGroup.AlternativeText = "Sample group alt text";

                    // Add a rectangle inside the group (optional visual content)
                    Aspose.Slides.IAutoShape rect = (Aspose.Slides.IAutoShape) sampleGroup.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0, 0, 200, 100);
                    rect.AlternativeText = "Rectangle inside group";

                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation for processing
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    using (StreamWriter sw = new StreamWriter(outputCsv))
                    {
                        sw.WriteLine("SlideIndex,GroupIndex,AltText");
                        int slideIndex = 0;
                        foreach (Aspose.Slides.ISlide slide in pres.Slides)
                        {
                            int groupIndex = 0;
                            foreach (Aspose.Slides.IShape shape in slide.Shapes)
                            {
                                Aspose.Slides.IGroupShape group = shape as Aspose.Slides.IGroupShape;
                                if (group != null)
                                {
                                    string altText = group.AlternativeText ?? string.Empty;
                                    string escapedAltText = altText.Replace("\"", "\"\"");
                                    sw.WriteLine(string.Format("{0},{1},\"{2}\"", slideIndex, groupIndex, escapedAltText));
                                    groupIndex++;
                                }
                            }
                            slideIndex++;
                        }
                    }

                    // Save the presentation (no modifications made, but required by spec)
                    pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (System.NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
