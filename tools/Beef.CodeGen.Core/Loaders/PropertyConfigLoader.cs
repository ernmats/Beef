﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Beef.CodeGen.Loaders
{
    /// <summary>
    /// Represents an <b>Property</b> configuration loader.
    /// </summary>
    public class PropertyConfigLoader : ICodeGenConfigLoader
    {
        /// <summary>
        /// Gets the loader name.
        /// </summary>
        public string Name { get { return "Property"; } }

        /// <summary>
        /// Loads the <see cref="CodeGenConfig"/> before the corresponding <see cref="CodeGenConfig.Children"/>.
        /// </summary>
        /// <param name="config">The <see cref="CodeGenConfig"/> being loaded.</param>
        public Task LoadBeforeChildrenAsync(CodeGenConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (!config.Attributes.ContainsKey("Name"))
                throw new CodeGenException("Property element must have a Name property.");

            config.AttributeAdd("Type", "string");

            if (config.GetAttributeValue<string>("Type").StartsWith("RefDataNamespace.", StringComparison.InvariantCulture))
                config.AttributeAdd("RefDataType", "string");

            if (config.GetAttributeValue<string>("RefDataType") != null)
                config.AttributeAdd("Text", string.Format(System.Globalization.CultureInfo.InvariantCulture, "{1} (see {{{{{0}}}}})", config.Attributes["Type"], StringConversion.ToSentenceCase(config.Attributes["Name"])));
            else if (CodeGenConfig.SystemTypes.Contains(config.Attributes["Type"]!))
                config.AttributeAdd("Text", StringConversion.ToSentenceCase(config.Attributes["Name"]));
            else
                config.AttributeAdd("Text", string.Format(System.Globalization.CultureInfo.InvariantCulture, "{1} (see {{{{{0}}}}})", config.Attributes["Type"], StringConversion.ToSentenceCase(config.Attributes["Name"])));

            config.AttributeUpdate("Text", config.Attributes["Text"]);

            config.AttributeAdd("StringTrim", "UseDefault");
            config.AttributeAdd("StringTransform", "UseDefault");
            config.AttributeAdd("DateTimeTransform", "UseDefault");
            config.AttributeAdd("PrivateName", StringConversion.ToPrivateCase(config.Attributes["Name"]));
            config.AttributeAdd("ArgumentName", StringConversion.ToCamelCase(config.Attributes["Name"]));
            config.AttributeAdd("DisplayName", GenerateDisplayName(config));

            config.AttributeAdd("Nullable", CodeGenConfig.IgnoreNullableTypes.Contains(config.Attributes["Type"]!) ? "false" : "true");

            return Task.CompletedTask;
        }

        /// <summary>
        /// Generates the display name (checks for Id and handles specifically).
        /// </summary>
        private static string GenerateDisplayName(CodeGenConfig config)
        {
            var dn = StringConversion.ToSentenceCase(config.Attributes["Name"])!;
            var parts = dn.Split(' ');
            if (parts.Length == 1)
                return (parts[0] == "Id") ? "Identifier" : dn;

            if (parts.Last() != "Id")
                return dn;

            var parts2 = new string[parts.Length - 1];
            Array.Copy(parts, parts2, parts.Length - 1);
            return string.Join(" ", parts2);
        }
    }
}