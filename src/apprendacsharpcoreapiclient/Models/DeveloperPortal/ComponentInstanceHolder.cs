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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace ApprendaAPIClient.Models.DeveloperPortal
{
    /// <summary>
    /// ComponentInstanceHolder
    /// </summary>

    public class ComponentInstanceHolder :  IEquatable<ComponentInstanceHolder>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentInstanceHolder" /> class.
        /// </summary>
        /// <param name="Count">Count.</param>
        /// <param name="Href">Href.</param>
        public ComponentInstanceHolder(int? Count = default(int?), string Href = default(string))
        {
            this.Count = Count;
            this.Href = Href;
        }
        
        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        
        public int? Count { get; set; }
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
            sb.Append("class ComponentInstanceHolder {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
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
            return this.Equals(obj as ComponentInstanceHolder);
        }

        /// <summary>
        /// Returns true if ComponentInstanceHolder instances are equal
        /// </summary>
        /// <param name="other">Instance of ComponentInstanceHolder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ComponentInstanceHolder other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Count == other.Count ||
                    this.Count != null &&
                    this.Count.Equals(other.Count)
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
                if (this.Count != null)
                    hash = hash * 59 + this.Count.GetHashCode();
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
