/* 
 * Apprenda.DeveloperPortal.Web
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    /// <summary>
    /// CustomPropertyModel
    /// </summary>
    
    public partial class CustomPropertyModel :  IEquatable<CustomPropertyModel>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPropertyModel" /> class.
        /// </summary>
        /// <param name="Name">Name.</param>
        /// <param name="DisplayName">DisplayName.</param>
        /// <param name="Description">Description.</param>
        /// <param name="ArbitraryValuesAllowed">ArbitraryValuesAllowed.</param>
        /// <param name="MultiSelectAllowed">MultiSelectAllowed.</param>
        /// <param name="Editable">Editable.</param>
        /// <param name="Values">Values.</param>
        /// <param name="DefaultValues">DefaultValues.</param>
        /// <param name="Href">Href.</param>
        public CustomPropertyModel(string Name = default(string), string DisplayName = default(string), string Description = default(string), bool? ArbitraryValuesAllowed = default(bool?), bool? MultiSelectAllowed = default(bool?), bool? Editable = default(bool?), List<string> Values = default(List<string>), List<string> DefaultValues = default(List<string>), string Href = default(string))
        {
            this.Name = Name;
            this.DisplayName = DisplayName;
            this.Description = Description;
            this.ArbitraryValuesAllowed = ArbitraryValuesAllowed;
            this.MultiSelectAllowed = MultiSelectAllowed;
            this.Editable = Editable;
            this.Values = Values;
            this.DefaultValues = DefaultValues;
            this.Href = Href;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets DisplayName
        /// </summary>
        
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        
        public string Description { get; set; }
        /// <summary>
        /// Gets or Sets ArbitraryValuesAllowed
        /// </summary>
        
        public bool? ArbitraryValuesAllowed { get; set; }
        /// <summary>
        /// Gets or Sets MultiSelectAllowed
        /// </summary>
        
        public bool? MultiSelectAllowed { get; set; }
        /// <summary>
        /// Gets or Sets Editable
        /// </summary>
        
        public bool? Editable { get; set; }
        /// <summary>
        /// Gets or Sets Values
        /// </summary>
        
        public List<string> Values { get; set; }
        /// <summary>
        /// Gets or Sets DefaultValues
        /// </summary>
        
        public List<string> DefaultValues { get; set; }
        /// <summary>
        /// Gets or Sets Href
        /// </summary>
        
        public string Href { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomPropertyModel {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ArbitraryValuesAllowed: ").Append(ArbitraryValuesAllowed).Append("\n");
            sb.Append("  MultiSelectAllowed: ").Append(MultiSelectAllowed).Append("\n");
            sb.Append("  Editable: ").Append(Editable).Append("\n");
            sb.Append("  Values: ").Append(Values).Append("\n");
            sb.Append("  DefaultValues: ").Append(DefaultValues).Append("\n");
            sb.Append("  Href: ").Append(Href).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as CustomPropertyModel);
        }

        /// <summary>
        /// Returns true if CustomPropertyModel instances are equal
        /// </summary>
        /// <param name="other">Instance of CustomPropertyModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomPropertyModel other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.DisplayName == other.DisplayName ||
                    this.DisplayName != null &&
                    this.DisplayName.Equals(other.DisplayName)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.ArbitraryValuesAllowed == other.ArbitraryValuesAllowed ||
                    this.ArbitraryValuesAllowed != null &&
                    this.ArbitraryValuesAllowed.Equals(other.ArbitraryValuesAllowed)
                ) && 
                (
                    this.MultiSelectAllowed == other.MultiSelectAllowed ||
                    this.MultiSelectAllowed != null &&
                    this.MultiSelectAllowed.Equals(other.MultiSelectAllowed)
                ) && 
                (
                    this.Editable == other.Editable ||
                    this.Editable != null &&
                    this.Editable.Equals(other.Editable)
                ) && 
                (
                    this.Values == other.Values ||
                    this.Values != null &&
                    this.Values.SequenceEqual(other.Values)
                ) && 
                (
                    this.DefaultValues == other.DefaultValues ||
                    this.DefaultValues != null &&
                    this.DefaultValues.SequenceEqual(other.DefaultValues)
                ) && 
                (
                    this.Href == other.Href ||
                    this.Href != null &&
                    this.Href.Equals(other.Href)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.DisplayName != null)
                    hash = hash * 59 + this.DisplayName.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.ArbitraryValuesAllowed != null)
                    hash = hash * 59 + this.ArbitraryValuesAllowed.GetHashCode();
                if (this.MultiSelectAllowed != null)
                    hash = hash * 59 + this.MultiSelectAllowed.GetHashCode();
                if (this.Editable != null)
                    hash = hash * 59 + this.Editable.GetHashCode();
                if (this.Values != null)
                    hash = hash * 59 + this.Values.GetHashCode();
                if (this.DefaultValues != null)
                    hash = hash * 59 + this.DefaultValues.GetHashCode();
                if (this.Href != null)
                    hash = hash * 59 + this.Href.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
