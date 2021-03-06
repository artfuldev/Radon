﻿using System;
using System.Linq;

namespace Radon.UriTemplates
{
    /// <summary>
    ///     Description of URI template variable.
    /// </summary>
    public sealed class VarSpec
    {
        public VarSpec(string name)
            : this(name, false, 0, false)
        {
        }

        public VarSpec(string name, bool exploded)
            : this(name, exploded, 0, false)
        {
        }

        public VarSpec(string name, int maxLength)
            : this(name, false, maxLength, false)
        {
            if (maxLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLength), "maxLength must be greater then 0");
            }
        }

        internal VarSpec(string name, bool exploded, int maxLength, bool safe)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(name, nameof(name));

            if (!safe && !IsWellFormedName(name))
            {
                throw new ArgumentException($"Invalid variable name \"{name}\"", nameof(name));
            }

            Name = name;
            Exploded = exploded;
            MaxLength = maxLength;
        }

        public string Name { get; }

        public bool Exploded { get; }

        public int MaxLength { get; }

        public static implicit operator VarSpec(string name)
        {
            return new VarSpec(name);
        }

        public static string Escape(string name)
        {
            return PctEncoding.Escape(name, CharSpec.VarChar);
        }

        public static string Unescape(string name)
        {
            return PctEncoding.Unescape(name, CharSpec.VarChar);
        }

        private static bool IsWellFormedName(string name)
        {
            return name.All(CharSpec.IsVarChar);
        }
    }
}