using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputCsv = Path.Combine(Directory.GetCurrentDirectory(), "SmartArtText.csv");

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        using (StreamWriter writer = new StreamWriter(outputCsv, false))
        {
            writer.WriteLine("Presentation,SlideIndex,SmartArtText");
            string[] files = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    continue;
                }

                try
                {
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[i];
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.SmartArt.ISmartArt)
                            {
                                Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                                Aspose.Slides.SmartArt.ISmartArtNodeCollection nodes = smartArt.AllNodes;
                                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in nodes)
                                {
                                    foreach (Aspose.Slides.SmartArt.ISmartArtShape nodeShape in node.Shapes)
                                    {
                                        if (nodeShape.TextFrame != null)
                                        {
                                            sb.Append(nodeShape.TextFrame.Text);
                                            sb.Append(" ");
                                        }
                                    }
                                }
                            }
                        }
                        string lineText = sb.ToString().Trim();
                        if (lineText.Length > 0)
                        {
                            string csvLine = string.Format("{0},{1},{2}", Path.GetFileName(filePath), i, lineText.Replace(",", " "));
                            writer.WriteLine(csvLine);
                        }
                    }
                    pres.Dispose();
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    // Format not supported: {0}
                    Console.WriteLine("Error processing file {0}: {1}", filePath, ex.Message);
                }
            }
        }
    }
}