// -----------------------------------------------------------------------------
// Example: Add smartart node with unique id using C#
//
// Description:
// Demonstrates how to add a SmartArt node with a unique identifier using C#
// and Aspose.Slides for .NET. The example loads an existing presentation,
// inserts an Organization Chart SmartArt diagram, adds a new node, assigns a
// GUID as its unique ID, optionally sets the node text, and saves the result.
// This pattern can be used for automating PowerPoint workflows that require
// tracking SmartArt nodes.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Unique ID,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes with unique identifiers.
// - Build C# tools for PowerPoint presentation manipulation.
// - Generate or modify PPTX files in .NET applications.
// - Track SmartArt elements for later processing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load presentation with exception handling for unsupported formats
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // If the format is not supported, Aspose.Slides throws an exception
                Console.WriteLine("Error loading presentation: " + ex.Message);
                // format not supported
                return;
            }

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Add a new node to the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

            // Generate a unique identifier for the node
            string uniqueId = Guid.NewGuid().ToString();

            // Store the mapping between the identifier and the node
            Dictionary<string, Aspose.Slides.SmartArt.ISmartArtNode> nodeMapping = new Dictionary<string, Aspose.Slides.SmartArt.ISmartArtNode>();
            nodeMapping.Add(uniqueId, newNode);

            // Optionally set the node's text to the unique identifier
            if (newNode.TextFrame != null)
            {
                newNode.TextFrame.Text = uniqueId;
            }

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
