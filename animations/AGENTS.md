---

name: animations

description: C# examples for animations using Aspose.Slides for .NET

language: csharp

framework: net10.0

parent: ../agents.md

---



# AGENTS - animations



## Persona



You are a C# developer specializing in PowerPoint processing using Aspose.Slides for .NET,

working within the **animations** category.



## Scope



- This folder contains examples for **animations**

- Files are standalone `.cs` examples stored directly in this folder.



## Required Namespaces



Verified with version: 26.8.0
Total files: 31

- `using System;` (31/31 files)
- `using Aspose.Slides.Export;` (31/31 files)
- `using System.IO;` (28/31 files)
- `using Aspose.Slides;` (28/31 files)
- `using Aspose.Slides.Animation;` (20/31 files)
- `using System.Drawing;` (3/31 files)
- `using Aspose.Slides.Charts;` (1/31 files)
- `using System.Collections.Generic;` (1/31 files)
- `using System.Text.Json;` (1/31 files)
- `using System.Xml.Linq;` (1/31 files)

## Files in this folder



| File | Key APIs | Description |
|------|----------|-------------|
| [Add-animation-timing-to-PDF-metadata.cs](./Add-animation-timing-to-PDF-metadata.cs) |  | Add animation timing to PDF metadata |
| [Add-color-change-animation-sync-sound.cs](./Add-color-change-animation-sync-sound.cs) |  | Add color change animation sync sound |
| [Add-custom-bezier-motion-path-animation.cs](./Add-custom-bezier-motion-path-animation.cs) |  | Add custom bezier motion path animation |
| [Add-custom-motion-path-and-set-duration.cs](./Add-custom-motion-path-and-set-duration.cs) |  | Add custom motion path and set duration |
| [Add-fade-in-animation-to-title-placeholders.cs](./Add-fade-in-animation-to-title-placeholders.cs) |  | Add fade in animation to title placeholders |
| [Add-fade-out-animation-to-images.cs](./Add-fade-out-animation-to-images.cs) |  | Add fade out animation to images |
| [Add-fade-spin-animation-to-chart.cs](./Add-fade-spin-animation-to-chart.cs) |  | Add fade spin animation to chart |
| [Add-slide-transitions-trigger-animations.cs](./Add-slide-transitions-trigger-animations.cs) |  | Add slide transitions trigger animations |
| [Add-zoom-rotate-animation-preset.cs](./Add-zoom-rotate-animation-preset.cs) |  | Add zoom rotate animation preset |
| [Create-thumbnail-at-animation-start.cs](./Create-thumbnail-at-animation-start.cs) |  | Create thumbnail at animation start |
| [Detect-unsupported-animation-effects-for-legacy-PPTX.cs](./Detect-unsupported-animation-effects-for-legacy-PPTX.cs) |  | Detect unsupported animation effects for legacy PPTX |
| [Disable-all-animations-for-faster-transitions.cs](./Disable-all-animations-for-faster-transitions.cs) |  | Disable all animations for faster transitions |
| [Export-animation-timeline-to-CSV.cs](./Export-animation-timeline-to-CSV.cs) |  | Export animation timeline to CSV |
| [Export-presentation-to-MP4-with-animations.cs](./Export-presentation-to-MP4-with-animations.cs) |  | Export presentation to MP4 with animations |
| [Export-slide-animation-timeline-to-JSON.cs](./Export-slide-animation-timeline-to-JSON.cs) |  | Export slide animation timeline to JSON |
| [Generate-HTML-preview-with-replay-controls.cs](./Generate-HTML-preview-with-replay-controls.cs) |  | Generate HTML preview with replay controls |
| [Increase-animation-speed-by-fifty-percent.cs](./Increase-animation-speed-by-fifty-percent.cs) |  | Increase animation speed by fifty percent |
| [Load-animation-settings-from-XML-and-apply.cs](./Load-animation-settings-from-XML-and-apply.cs) |  | Load animation settings from XML and apply |
| [Log-animation-types-and-shape-names.cs](./Log-animation-types-and-shape-names.cs) |  | Log animation types and shape names |
| [Merge-presentations-preserve-all-animations.cs](./Merge-presentations-preserve-all-animations.cs) |  | Merge presentations preserve all animations |
| [Pause-animations-after-each-step-until-click.cs](./Pause-animations-after-each-step-until-click.cs) |  | Pause animations after each step until click |
| [Remove-exit-animations-keep-entrance-effects.cs](./Remove-exit-animations-keep-entrance-effects.cs) |  | Remove exit animations keep entrance effects |
| [Render-slide-frames-to-PNG.cs](./Render-slide-frames-to-PNG.cs) |  | Render slide frames to PNG |
| [Reorder-animations-according-to-shape-zorder.cs](./Reorder-animations-according-to-shape-zorder.cs) |  | Reorder animations according to shape zorder |
| [Replace-picture-fill-animation-with-wipe.cs](./Replace-picture-fill-animation-with-wipe.cs) |  | Replace picture fill animation with wipe |
| [Set-click-trigger-for-shape-animation.cs](./Set-click-trigger-for-shape-animation.cs) |  | Set click trigger for shape animation |
| [Set-easing-curve-for-animation-acceleration.cs](./Set-easing-curve-for-animation-acceleration.cs) |  | Set easing curve for animation acceleration |
| [Set-entrance-animation-delay-two-seconds.cs](./Set-entrance-animation-delay-two-seconds.cs) |  | Set entrance animation delay two seconds |
| [Set-looping-background-video-animation-infinite.cs](./Set-looping-background-video-animation-infinite.cs) |  | Set looping background video animation infinite |
| [Sync-animations-across-multiple-slides.cs](./Sync-animations-across-multiple-slides.cs) |  | Sync animations across multiple slides |
| [Validate-animations-for-PPTX-2016-compatibility.cs](./Validate-animations-for-PPTX-2016-compatibility.cs) |  | Validate animations for PPTX 2016 compatibility |

## Category Statistics



- Total examples: 31

## Key API Surface



- `Aspose.Slides.Export`

- `Aspose.Slides`

- `Aspose.Slides.Presentation`

- `Aspose.Slides.Animation`

- `Aspose.Slides.Export.SaveFormat.Pptx`

- `Aspose.Slides.ISlide`

- `Aspose.Slides.Animation.IEffect`

- `Aspose.Slides.Animation.EffectSubtype.None`

- `Aspose.Slides.ShapeType.Rectangle`

- `Aspose.Slides.Paragraph`

- `Aspose.Slides.Animation.EffectTriggerType.AfterPrevious`

- `Aspose.Slides.Export.PresentationAnimationsGenerator`

- `Aspose.Slides.Animation.EffectType`

- `Aspose.Slides.IAutoShape`

- `Aspose.Slides.Animation.EffectTriggerType.OnClick`



## Common Code Pattern



Most examples follow a pattern similar to:



```csharp

using (Presentation pres = new Presentation("input.pptx"))

{

    // operations

    pres.Save("output.pptx", SaveFormat.Pptx);

}

```



## Category-Specific Tips



- Load presentations using `new Presentation("file.pptx")`.

- Modify slides through the `Slides` collection.

- Save the presentation using `Presentation.Save(...)`.



<!-- AUTOGENERATED:START -->

Updated: 2026-04-07

<!-- AUTOGENERATED:END -->



<!-- SEO-FAQ:BEGIN -->

## Developer FAQ for Coding Agents



Use these Q&A entries when selecting examples from `animations` for user prompts.



### How do I convert PowerPoint PPTX files to PDF, HTML, SVG, PNG, or JPEG in C#?

Use the conversion and export examples to load a `Presentation`, configure format-specific options when needed, and call `presentation.Save(...)` or slide image APIs with the correct `Aspose.Slides.Export.SaveFormat`.



### How do I create or edit PowerPoint charts in C# with Aspose.Slides?

Use chart examples to add chart shapes, access `Aspose.Slides.Charts.IChart`, update chart data, format series, configure axes, and save the presentation.



### How do I add, clone, reorder, or remove PowerPoint slides in .NET?

Use slide management examples to work with `ISlide`, slide collections, layouts, masters, and sections while preserving presentation structure.



### How do I edit PowerPoint shapes, text, tables, or SmartArt in C#?

Use the shape, text, table, and SmartArt examples to locate shapes on a slide, cast to the appropriate Aspose.Slides interfaces, update content or formatting, and save the modified PPTX.



### How do I add or inspect PowerPoint animations in C#?

Use animation examples to work with slide timelines, animation sequences, effect types, triggers, and animated shapes through Aspose.Slides APIs.



### How do I extract presentation metadata, comments, notes, tags, VBA, or security information?

Use the inspection and management examples to access document properties, comments, notes slides, custom tags, VBA projects, signatures, protection settings, and related metadata.



<!-- SEO-FAQ:END -->

