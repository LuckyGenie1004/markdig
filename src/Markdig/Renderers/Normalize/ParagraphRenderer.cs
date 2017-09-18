// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

namespace Markdig.Renderers.Normalize
{
    /// <summary>
    /// A Normalize renderer for a <see cref="ParagraphBlock"/>.
    /// </summary>
    /// <seealso cref="Markdig.Renderers.Normalize.NormalizeObjectRenderer{Markdig.Syntax.ParagraphBlock}" />
    public class ParagraphRenderer : NormalizeObjectRenderer<ParagraphBlock>
    {
        protected override void Write(NormalizeRenderer renderer, ParagraphBlock obj)
        {
            if (!renderer.CompactParagraph)
            {
                renderer.EnsureLine();
            }
            renderer.WriteLeafInline(obj);

            renderer.FinishBlock();
        }
    }
}