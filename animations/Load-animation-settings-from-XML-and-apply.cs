// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load animation settings from XML and apply using C#

//

// Description:

// Demonstrates loading animation definitions from an XML file and applying

// them to a PowerPoint presentation using Aspose.Slides for .NET. The console

// application reads a PPTX file, parses animation parameters (shape index,

// effect type, subtype, trigger) from XML, adds the corresponding effects to

// the first slide, and saves the modified presentation.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, XML, Animation, Effect, Timeline, 

// Presentation Automation, Office Automation

//

// Use Cases:

// - Apply batch animation settings defined in XML to existing PPTX files.

// - Create command‑line tools for updating slide animations programmatically.

// - Integrate XML‑driven animation configuration into .NET presentation workflows.

// - Validate and test animation definitions before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Xml.Linq;

using Aspose.Slides.Export;



namespace AnimationFromXml

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect three arguments: presentation file, XML settings file, output file

            if (args.Length < 3)

            {

                Console.WriteLine("Usage: AnimationFromXml <presentation.pptx> <settings.xml> <output.pptx>");

                return;

            }



            string presentationPath = args[0];

            string xmlPath = args[1];

            string outputPath = args[2];



            // Verify input files exist

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine($"Presentation file not found: {presentationPath}");

                return;

            }



            if (!File.Exists(xmlPath))

            {

                Console.WriteLine($"XML settings file not found: {xmlPath}");

                return;

            }



            Aspose.Slides.Presentation presentation = null;

            try

            {

                // Load the presentation

                presentation = new Aspose.Slides.Presentation(presentationPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or loading errors

                Console.WriteLine($"Failed to load presentation: {ex.Message}");

                // format not supported

                return;

            }



            try

            {

                // Load XML settings

                XDocument doc = XDocument.Load(xmlPath);

                // Assume settings are under <Animations><Animation .../></Animations>

                foreach (XElement animElem in doc.Root.Elements("Animation"))

                {

                    // Parse attributes

                    int shapeIndex = (int)animElem.Attribute("ShapeIndex");

                    string effectTypeStr = (string)animElem.Attribute("EffectType");

                    string subtypeStr = (string)animElem.Attribute("Subtype");

                    string triggerStr = (string)animElem.Attribute("Trigger");



                    // Convert strings to enum values

                    Aspose.Slides.Animation.EffectType effectType = (Aspose.Slides.Animation.EffectType)Enum.Parse(typeof(Aspose.Slides.Animation.EffectType), effectTypeStr);

                    Aspose.Slides.Animation.EffectSubtype subtype = (Aspose.Slides.Animation.EffectSubtype)Enum.Parse(typeof(Aspose.Slides.Animation.EffectSubtype), subtypeStr);

                    Aspose.Slides.Animation.EffectTriggerType trigger = (Aspose.Slides.Animation.EffectTriggerType)Enum.Parse(typeof(Aspose.Slides.Animation.EffectTriggerType), triggerStr);



                    // Apply to the first slide (adjust as needed)

                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    if (shapeIndex < 0 || shapeIndex >= slide.Shapes.Count)

                    {

                        Console.WriteLine($"Invalid shape index: {shapeIndex}");

                        continue;

                    }



                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Add animation effect

                    slide.Timeline.MainSequence.AddEffect(shape, effectType, subtype, trigger);

                }

            }

            catch (Exception ex)

            {

                // Handle XML parsing or other errors

                Console.WriteLine($"Error processing XML: {ex.Message}");

                presentation.Dispose();

                return;

            }



            try

            {

                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle save errors (e.g., unsupported format)

                Console.WriteLine($"Failed to save presentation: {ex.Message}");

                // format not supported

            }

            finally

            {

                // Ensure resources are released

                presentation.Dispose();

            }

        }

    }

}

