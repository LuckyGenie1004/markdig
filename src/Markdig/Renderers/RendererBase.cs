// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Markdig.Helpers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Markdig.Renderers
{
    /// <summary>
    /// Base class for a <see cref="IMarkdownRenderer"/>.
    /// </summary>
    /// <seealso cref="IMarkdownRenderer" />
    public abstract class RendererBase : IMarkdownRenderer
    {
        private readonly struct KeyWrapper : IEquatable<KeyWrapper>
        {
            public readonly IntPtr Key;

            public KeyWrapper(IntPtr key) => Key = key;

            public bool Equals(KeyWrapper other) => Key == other.Key;

            public override int GetHashCode() => Key.GetHashCode();

            public override bool Equals(object? obj) => throw new NotImplementedException();
        }

        private readonly Dictionary<KeyWrapper, IMarkdownObjectRenderer?> _renderersPerType = new();
        internal int _childrenDepth = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="RendererBase"/> class.
        /// </summary>
        protected RendererBase() { }

        private IMarkdownObjectRenderer? GetRendererInstance(MarkdownObject obj)
        {
            KeyWrapper key = GetKeyForType(obj);
            Type objectType = obj.GetType();

            for (int i = 0; i < ObjectRenderers.Count; i++)
            {
                var renderer = ObjectRenderers[i];
                if (renderer.Accept(this, objectType))
                {
                    _renderersPerType[key] = renderer;
                    return renderer;
                }
            }

            _renderersPerType[key] = null;
            return null;
        }

        public ObjectRendererCollection ObjectRenderers { get; } = new();

        public abstract object Render(MarkdownObject markdownObject);

        public bool IsFirstInContainer { get; private set; }

        public bool IsLastInContainer { get; private set; }

        /// <summary>
        /// Occurs when before writing an object.
        /// </summary>
        public event Action<IMarkdownRenderer, MarkdownObject>? ObjectWriteBefore;

        /// <summary>
        /// Occurs when after writing an object.
        /// </summary>
        public event Action<IMarkdownRenderer, MarkdownObject>? ObjectWriteAfter;

        /// <summary>
        /// Writes the children of the specified <see cref="ContainerBlock"/>.
        /// </summary>
        /// <param name="containerBlock">The container block.</param>
        public void WriteChildren(ContainerBlock containerBlock)
        {
            if (containerBlock is null)
            {
                return;
            }

            ThrowHelper.CheckDepthLimit(_childrenDepth++);

            bool saveIsFirstInContainer = IsFirstInContainer;
            bool saveIsLastInContainer = IsLastInContainer;

            var children = containerBlock;
            for (int i = 0; i < children.Count; i++)
            {
                IsFirstInContainer = i == 0;
                IsLastInContainer = i + 1 == children.Count;
                Write(children[i]);
            }

            IsFirstInContainer = saveIsFirstInContainer;
            IsLastInContainer = saveIsLastInContainer;

            _childrenDepth--;
        }

        /// <summary>
        /// Writes the children of the specified <see cref="ContainerInline"/>.
        /// </summary>
        /// <param name="containerInline">The container inline.</param>
        public void WriteChildren(ContainerInline containerInline)
        {
            if (containerInline is null)
            {
                return;
            }

            ThrowHelper.CheckDepthLimit(_childrenDepth++);

            bool saveIsFirstInContainer = IsFirstInContainer;
            bool saveIsLastInContainer = IsLastInContainer;

            bool isFirst = true;
            var inline = containerInline.FirstChild;
            while (inline != null)
            {
                IsFirstInContainer = isFirst;
                IsLastInContainer = inline.NextSibling is null;

                Write(inline);
                inline = inline.NextSibling;

                isFirst = false;
            }

            IsFirstInContainer = saveIsFirstInContainer;
            IsLastInContainer = saveIsLastInContainer;

            _childrenDepth--;
        }

        /// <summary>
        /// Writes the specified Markdown object.
        /// </summary>
        /// <param name="obj">The Markdown object to write to this renderer.</param>
        public void Write(MarkdownObject obj)
        {
            if (obj is null)
            {
                return;
            }

            // Calls before writing an object
            ObjectWriteBefore?.Invoke(this, obj);

            if (!_renderersPerType.TryGetValue(GetKeyForType(obj), out IMarkdownObjectRenderer? renderer))
            {
                renderer = GetRendererInstance(obj);
            }

            if (renderer is not null)
            {
                renderer.Write(this, obj);
            }
            else if (obj.IsContainerInline)
            {
                WriteChildren(Unsafe.As<ContainerInline>(obj));
            }
            else if (obj.IsContainerBlock)
            {
                WriteChildren(Unsafe.As<ContainerBlock>(obj));
            }

            // Calls after writing an object
            ObjectWriteAfter?.Invoke(this, obj);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static KeyWrapper GetKeyForType(MarkdownObject obj)
        {
#if NET
            if (s_canUseMethodTablePointer)
            {
                IntPtr methodTablePtr = Unsafe.Add(ref Unsafe.As<RawData>(obj).Data, -1);
                return new KeyWrapper(methodTablePtr);
            }
#endif

            IntPtr typeHandle = Type.GetTypeHandle(obj).Value;
            return new KeyWrapper(typeHandle);
        }

#if NET
        private sealed class RawData
        {
            public IntPtr Data;
        }

        private static readonly bool s_canUseMethodTablePointer = GetCanUseMethodTablePointer();

        private static bool GetCanUseMethodTablePointer()
        {
            if (RuntimeInformation.OSArchitecture == Architecture.Wasm)
            {
                return false;
            }

            var obj1 = new LiteralInline();
            var obj2 = new ParagraphBlock();
            var obj3 = new LiteralInline();
            IntPtr ptr1 = Unsafe.Add(ref Unsafe.As<RawData>(obj1).Data, -1);
            IntPtr ptr2 = Unsafe.Add(ref Unsafe.As<RawData>(obj2).Data, -1);
            IntPtr ptr3 = Unsafe.Add(ref Unsafe.As<RawData>(obj3).Data, -1);
            GC.KeepAlive(obj1);
            GC.KeepAlive(obj2);
            GC.KeepAlive(obj3);

            if (ptr1 == ptr2 || ptr1 != ptr3)
            {
                Debug.Fail("This platform doesn't support the MT pointer optimization");
                return false;
            }

            return true;
        }
#endif
    }
}