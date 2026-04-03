using System;
using System.IO;
using System.Xml;
using Aspose.Slides.Export;

namespace AnimationFromXml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, XML configuration and output presentation
            string presentationPath = "input.pptx";
            string xmlPath = "animConfig.xml";
            string outputPath = "output.pptx";

            // Verify that the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found.");
                return;
            }

            // Verify that the XML configuration file exists
            if (!File.Exists(xmlPath))
            {
                Console.WriteLine("XML configuration file not found.");
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(presentationPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                // Format not supported
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Load the XML configuration
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading XML configuration: " + ex.Message);
                presentation.Dispose();
                return;
            }

            // Assume animations are defined for the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAnimationTimeLine timeline = slide.Timeline;

            // Iterate over each Animation node in the XML
            XmlNodeList animationNodes = xmlDoc.SelectNodes("//Animation");
            foreach (XmlNode node in animationNodes)
            {
                // Expected attributes: ShapeIndex, EffectType, Subtype, Trigger
                int shapeIndex = int.Parse(node.Attributes["ShapeIndex"].Value);
                string effectTypeStr = node.Attributes["EffectType"].Value;
                string subtypeStr = node.Attributes["Subtype"].Value;
                string triggerStr = node.Attributes["Trigger"].Value;

                // Retrieve the target shape
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Parse enum values from strings
                Aspose.Slides.Animation.EffectType effectType = (Aspose.Slides.Animation.EffectType)Enum.Parse(typeof(Aspose.Slides.Animation.EffectType), effectTypeStr);
                Aspose.Slides.Animation.EffectSubtype subtype = (Aspose.Slides.Animation.EffectSubtype)Enum.Parse(typeof(Aspose.Slides.Animation.EffectSubtype), subtypeStr);
                Aspose.Slides.Animation.EffectTriggerType trigger = (Aspose.Slides.Animation.EffectTriggerType)Enum.Parse(typeof(Aspose.Slides.Animation.EffectTriggerType), triggerStr);

                // Add the effect to the main sequence
                timeline.MainSequence.AddEffect(shape, effectType, subtype, trigger);
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}