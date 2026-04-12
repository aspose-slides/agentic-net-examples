using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputXmlPath = "textFrames.xml";
        string outputPresPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Retrieve all text frames, including those on master slides
            Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pres, true);

            XElement root = new XElement("TextFrames");

            foreach (Aspose.Slides.ITextFrame tf in textFrames)
            {
                // Get effective formatting data for the text frame
                Aspose.Slides.ITextFrameFormatEffectiveData effective = tf.TextFrameFormat.GetEffective();

                XElement tfElement = new XElement("TextFrame",
                    new XElement("Text", tf.Text),
                    new XElement("AnchoringType", effective.AnchoringType.ToString()),
                    new XElement("AutofitType", effective.AutofitType.ToString()),
                    new XElement("TextVerticalType", effective.TextVerticalType.ToString()),
                    new XElement("MarginLeft", effective.MarginLeft),
                    new XElement("MarginTop", effective.MarginTop),
                    new XElement("MarginRight", effective.MarginRight),
                    new XElement("MarginBottom", effective.MarginBottom)
                );

                root.Add(tfElement);
            }

            XDocument doc = new XDocument(root);
            doc.Save(outputXmlPath);

            // Save the presentation (no modifications made)
            pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
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