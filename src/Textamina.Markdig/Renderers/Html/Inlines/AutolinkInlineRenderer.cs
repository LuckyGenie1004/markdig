// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Textamina.Markdig.Syntax.Inlines;

namespace Textamina.Markdig.Renderers.Html.Inlines
{
    /// <summary>
    /// A HTML renderer for an <see cref="AutolinkInline"/>.
    /// </summary>
    /// <seealso cref="Textamina.Markdig.Renderers.Html.HtmlObjectRenderer{Textamina.Markdig.Syntax.Inlines.AutolinkInline}" />
    public class AutolinkInlineRenderer : HtmlObjectRenderer<AutolinkInline>
    {
        protected override void Write(HtmlRenderer renderer, AutolinkInline obj)
        {
            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("<a href=\"");
                if (obj.IsEmail)
                {
                    renderer.Write("mailto:");
                }
                renderer.WriteEscapeUrl(obj.Url);
                renderer.WriteAttributes(obj);
                renderer.Write("\">");
            }

            renderer.WriteEscape(obj.Url);

            if (renderer.EnableHtmlForInline)
            {
                renderer.Write("</a>");
            }
        }
    }
}