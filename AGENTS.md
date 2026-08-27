---
name: aspose-slides-examples
version: 26.8.0
description: AI-friendly C# code examples for Aspose.Slides for .NET
language: csharp
framework: net10.0
package: Aspose.Slides
---

# Aspose.Slides for .NET Examples

AI-friendly repository containing validated C# examples for Aspose.Slides.


## Persona

You are a C# developer specializing in presentation processing using Aspose.Slides for .NET.
When working in this repository:
- Each `.cs` file is a **standalone Console Application**
- Do not create multi-file projects
- All examples must compile with `dotnet build`
- All examples must run with `dotnet run`
- Follow the repository conventions and boundaries strictly
- Use the **Command Reference** section for build and run commands



## Repository Overview

This repository contains **2272** working code examples demonstrating Aspose.Slides for .NET capabilities.

**Statistics** (as of 2026-08-25):
- Version: 26.8.0
- Total Examples: 2272
- Categories: 19

## Category Details

### 3d-presentations
- Examples: 29
- Guide: [AGENTS.md](./3d-presentations/AGENTS.md)

### animations
- Examples: 34
- Guide: [AGENTS.md](./animations/AGENTS.md)

### comments-and-notes
- Examples: 120
- Guide: [AGENTS.md](./comments-and-notes/AGENTS.md)

### conversion
- Examples: 397
- Guide: [AGENTS.md](./conversion/AGENTS.md)

### design-presentations
- Examples: 161
- Guide: [AGENTS.md](./design-presentations/AGENTS.md)

### manage-presentation
- Examples: 64
- Guide: [AGENTS.md](./manage-presentation/AGENTS.md)

### manage-presentation-content
- Examples: 101
- Guide: [AGENTS.md](./manage-presentation-content/AGENTS.md)

### manage-presentation-media-files
- Examples: 149
- Guide: [AGENTS.md](./manage-presentation-media-files/AGENTS.md)

### manage-presentation-text
- Examples: 104
- Guide: [AGENTS.md](./manage-presentation-text/AGENTS.md)

### manage-tags-and-custom-data
- Examples: 40
- Guide: [AGENTS.md](./manage-tags-and-custom-data/AGENTS.md)

### math-equations
- Examples: 29
- Guide: [AGENTS.md](./math-equations/AGENTS.md)

### presentation-ink-objects
- Examples: 35
- Guide: [AGENTS.md](./presentation-ink-objects/AGENTS.md)

### secure-presentations
- Examples: 29
- Guide: [AGENTS.md](./secure-presentations/AGENTS.md)

### vba-macros
- Examples: 34
- Guide: [AGENTS.md](./vba-macros/AGENTS.md)

### working-with-charts
- Examples: 463
- Guide: [AGENTS.md](./working-with-charts/AGENTS.md)

### working-with-shapes
- Examples: 208
- Guide: [AGENTS.md](./working-with-shapes/AGENTS.md)

### working-with-slides
- Examples: 123
- Guide: [AGENTS.md](./working-with-slides/AGENTS.md)

### working-with-smartart
- Examples: 121
- Guide: [AGENTS.md](./working-with-smartart/AGENTS.md)

### working-with-tables
- Examples: 31
- Guide: [AGENTS.md](./working-with-tables/AGENTS.md)



## Boundaries

### ✅ Always

These rules are mandatory for every example.

#### Use explicit types where clarity matters
```csharp
Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
Aspose.Slides.ISlide slide = presentation.Slides[0];
```

#### Use fully qualified namespaces where ambiguity exists
```csharp
Aspose.Slides.Export.SaveFormat format = Aspose.Slides.Export.SaveFormat.Pptx;
```

#### Use using blocks for disposable objects
```csharp
using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
{
    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

#### Save the presentation after modifications
```csharp
presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### ⚠️ Ask First

Check with a human before doing any of these:

- Creating multi-file projects
- Adding NuGet packages other than Aspose.Slides
- Using deprecated APIs
- Modifying repository infrastructure


### 🚫 Never

- Never use `Aspose.Slides.SaveFormat`
- Never mix chart APIs from incorrect namespaces
- Never rely on `System.Drawing.Image` when Slides APIs exist
- Never modify generated `agents.md` files
- Never modify generated `.csproj` templates



## Common Mistakes (Anti-Patterns)



## Domain Knowledge

- **Replace fonts explicitly before saving the presentation.**  
  Use `IFontData`, `FontData`, and `FontsManager.ReplaceFont(...)` to swap one font family with another across the deck, then save the updated file.  
  **Example:** Create `IFontData sourceFont = new FontData("Arial");`, `IFontData destFont = new FontData("Times New Roman");`, call `presentation.FontsManager.ReplaceFont(sourceFont, destFont);`, and save as `output.pptx`.

- **Clone a slide into a specific section to preserve presentation structure.**  
  When duplicating slides, create or append the destination section first and use `Slides.AddClone(...)` with the target `ISection`.  
  **Example:** Add a rectangle to `presentation.Slides[0]`, create `ISection section2 = presentation.Sections.AppendEmptySection("Section 2");`, then call `presentation.Slides.AddClone(presentation.Slides[0], section2);`.

- **Replace placeholder text by iterating shapes and updating only auto shapes.**  
  Loop through `slide.Shapes`, check `shape.Placeholder != null`, cast the shape to `IAutoShape`, and update `TextFrame.Text`.  
  **Example:** Iterate the first slide’s shapes and set `((IAutoShape)shape).TextFrame.Text = "Updated title";` only for placeholder shapes before saving.

- **Animate chart categories element-by-element through the slide timeline.**  
  Access the chart from the slide’s shape collection, add a base effect to `Timeline.MainSequence`, then loop through categories and series to add `ByElementInCategory` effects.  
  **Example:** Cast `slide.Shapes[0]` to `Aspose.Slides.Charts.IChart`, add a `Fade` effect, then use nested loops over `chart.ChartData.Categories.Count` and `chart.ChartData.Series.Count` to add `Appear` animations.

- **Export a shape as a PNG thumbnail without exporting the whole slide.**  
  Create a shape, style it, call `shape.GetImage(...)`, and save the returned `IImage` with `Aspose.Slides.ImageFormat.Png`.  
  **Example:** Add a rectangle, set `FillFormat.FillType = NoFill`, set `LineFormat.SketchFormat.SketchType = Scribble`, then call `shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 2f, 2f)` and save it as `shape.png`.

- **Access SmartArt by walking the slide’s shape collection and casting matching shapes.**  
  To inspect or process SmartArt content, iterate `slide.Shapes`, detect SmartArt shapes, and cast them to `Aspose.Slides.SmartArt.ISmartArt` or `SmartArt`.  
  **Example:** Loop through `slide.Shapes`, check `if (shape is Aspose.Slides.SmartArt.ISmartArt)`, cast it, then inspect `smartArt.AllNodes` to read node text and hierarchy.

- **Read SmartArt child nodes when you need hierarchy, level, and position data.**  
  For tree-style processing, iterate `AllNodes`, then iterate each node’s `ChildNodes` to access nested content and metadata like `Level` and `Position`.  
  **Example:** Cast a SmartArt shape to `SmartArt`, loop over `smart.AllNodes`, then for each parent node loop over `parentNode.ChildNodes` and read `childNode.TextFrame.Text`.

- **Embed audio in a slide and configure playback behavior directly on the audio frame.**  
  After creating an embedded audio frame, set playback options such as `PlayAcrossSlides`, `RewindAudio`, `Volume`, and `PlayMode`.  
  **Example:** Call `slide.Shapes.AddAudioFrameEmbedded(...)`, then set `audioFrame.PlayAcrossSlides = true;`, `audioFrame.RewindAudio = true;`, and `audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;`.

- **Add hyperlinks through text portions inside an auto shape rather than on the shape itself.**  
  Create an auto shape, add text, then attach the hyperlink to the first text portion using `PortionFormat.HyperlinkClick`.  
  **Example:** Create a rectangle, call `shape.AddTextFrame("Open site");`, then set `shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://example.com");`.

- **Store images inside table cells by using picture fill formatting on the target cell.**  
  Add a table, load an image, insert it into the presentation image collection, and assign it through `CellFormat.FillFormat.PictureFillFormat.Picture.Image`.  
  **Example:** Create a table with `slide.Shapes.AddTable(...)`, load an image with `Aspose.Slides.Images.FromFile("input.jpg")`, add it via `presentation.Images.AddImage(...)`, then set the first cell’s fill type to `Picture` and apply the image.




## Command Reference

### Build and Run
```bash
# Create a new project
dotnet new console -n ExampleProject --framework net10.0

# Add Aspose.Slides
dotnet add package Aspose.Slides

# Build
dotnet build --configuration Release --verbosity minimal

# Run
dotnet run
```

### Project File (.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Aspose.Slides" />
  </ItemGroup>
</Project>
```

### Environment

- .NET SDK 10.0 or higher
- NuGet package Aspose.Slides
- Each example is a standalone console application


---
Generated: 2026-08-25

<!-- latest-slides-verification:start -->
## Latest Aspose.Slides Verification

Generated examples were tested with Aspose.Slides for .NET 26.8.0 on 2026-08-25.

No examples are currently quarantined.
<!-- latest-slides-verification:end -->
