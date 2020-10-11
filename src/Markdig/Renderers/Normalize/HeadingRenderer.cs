// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

namespace Markdig.Renderers.Normalize
{
    /// <summary>
    /// An Normalize renderer for a <see cref="HeadingBlock"/>.
    /// </summary>
    /// <seealso cref="NormalizeObjectRenderer{HeadingBlock}" />
    public class HeadingRenderer : NormalizeObjectRenderer<HeadingBlock>
    {
        private static readonly string[] HeadingTexts = {
            "#",
            "##",
            "###",
            "####",
            "#####",
            "######",
        };

        protected override void Write(NormalizeRenderer renderer, HeadingBlock obj)
        {
            if (obj.IsSetext)
            {
                renderer.RenderLinesBefore(obj);

                var headingChar = obj.Level == 1 ? '=' : '-';
                var line = new string(headingChar, obj.HeaderCharCount);

                renderer.WriteLeafInline(obj);
                renderer.WriteLine(obj.SetextNewline);
                renderer.Write(obj.BeforeWhitespace);
                renderer.Write(line);
                renderer.WriteLine(obj.Newline);
                renderer.Write(obj.AfterWhitespace);

                renderer.RenderLinesAfter(obj);
            }
            else
            {
                renderer.RenderLinesBefore(obj);

                var headingText = obj.Level > 0 && obj.Level <= 6
                    ? HeadingTexts[obj.Level - 1]
                    : new string('#', obj.Level);

                renderer.Write(obj.BeforeWhitespace);
                renderer.Write(headingText).Write(' ');
                renderer.WriteLeafInline(obj);

                renderer.RenderLinesAfter(obj);
            }
        }
    }
}