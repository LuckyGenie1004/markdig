// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Textamina.Markdig.Parsers.Inlines;
using Textamina.Markdig.Renderers;
using Textamina.Markdig.Renderers.Html.Inlines;

namespace Textamina.Markdig.Extensions.Mathematics
{
    /// <summary>
    /// Extension for adding inline mathematics $...$
    /// </summary>
    /// <seealso cref="Textamina.Markdig.IMarkdownExtension" />
    public class MathExtension : IMarkdownExtension
    {
        public void Setup(MarkdownPipeline pipeline)
        {
            // Adds the inline parser
            if (!pipeline.InlineParsers.Contains<MathInlineParser>())
            {
                pipeline.InlineParsers.Insert(0, new MathInlineParser());
            }

            // Adds the block parser
            if (!pipeline.BlockParsers.Contains<MathBlockParser>())
            {
                // Insert before EmphasisInlineParser to take precedence
                pipeline.BlockParsers.Insert(0, new MathBlockParser());
            }

            var htmlRenderer = pipeline.Renderer as HtmlRenderer;
            if (htmlRenderer != null)
            {
                if (!htmlRenderer.ObjectRenderers.Contains<HtmlMathInlineRenderer>())
                {
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlMathInlineRenderer());
                }
                if (!htmlRenderer.ObjectRenderers.Contains<HtmlMathBlockRenderer>())
                {
                    htmlRenderer.ObjectRenderers.Insert(0, new HtmlMathBlockRenderer());
                }
            }
        }
    }
}