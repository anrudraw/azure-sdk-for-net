// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SolutionType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SolutionType
    {
        [EnumMember(Value = "QuickSolution")]
        QuickSolution,
        [EnumMember(Value = "DeepInvestigation")]
        DeepInvestigation,
        [EnumMember(Value = "BestPractices")]
        BestPractices
    }
    internal static class SolutionTypeEnumExtension
    {
        internal static string ToSerializedValue(this SolutionType? value)
        {
            return value == null ? null : ((SolutionType)value).ToSerializedValue();
        }

        internal static string ToSerializedValue(this SolutionType value)
        {
            switch( value )
            {
                case SolutionType.QuickSolution:
                    return "QuickSolution";
                case SolutionType.DeepInvestigation:
                    return "DeepInvestigation";
                case SolutionType.BestPractices:
                    return "BestPractices";
            }
            return null;
        }

        internal static SolutionType? ParseSolutionType(this string value)
        {
            switch( value )
            {
                case "QuickSolution":
                    return SolutionType.QuickSolution;
                case "DeepInvestigation":
                    return SolutionType.DeepInvestigation;
                case "BestPractices":
                    return SolutionType.BestPractices;
            }
            return null;
        }
    }
}
