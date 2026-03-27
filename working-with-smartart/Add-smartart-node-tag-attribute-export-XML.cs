using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "SmartArtTagOutput.pptx";
        string outputXml = "SmartArtTagMapping.xml";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram of OrganizationChart layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();
        newNode.TextFrame.Text = "Custom Node";

        // Access the first shape of the new node
        Aspose.Slides.SmartArt.ISmartArtShape nodeShape = newNode.Shapes[0];

        // Add a custom tag to the shape's custom data
        Aspose.Slides.ICustomData shapeCustomData = nodeShape.CustomData;
        shapeCustomData.Tags.Add("MyTag", "TagValue");

        // Create an XML string representing the mapping
        string xmlContent = "<Mapping><NodePosition>" + newNode.Position.ToString() + "</NodePosition><TagName>MyTag</TagName><TagValue>TagValue</TagValue></Mapping>";

        // Add the XML as a custom XML part in the presentation
        Aspose.Slides.ICustomXmlPart customXmlPart = presentation.CustomData.CustomXmlParts.Add(xmlContent);

        // Write the XML mapping to an external file
        File.WriteAllText(outputXml, xmlContent);

        // Save the presentation
        presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}