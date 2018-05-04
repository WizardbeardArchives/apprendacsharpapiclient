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
    /// CustomUrlCertificate
    /// </summary>
    
    public partial class CustomUrlCertificate :  IEquatable<CustomUrlCertificate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomUrlCertificate" /> class.
        /// </summary>
        /// <param name="AppAlias">AppAlias.</param>
        /// <param name="Version">Version.</param>
        /// <param name="SerialNumber">SerialNumber.</param>
        /// <param name="Issuer">Issuer.</param>
        /// <param name="ValidAfter">ValidAfter.</param>
        /// <param name="ValidBefore">ValidBefore.</param>
        /// <param name="Subject">Subject.</param>
        /// <param name="SubjectAltNames">SubjectAltNames.</param>
        /// <param name="Href">Href.</param>
        public CustomUrlCertificate(string AppAlias = default(string), int? Version = default(int?), string SerialNumber = default(string), string Issuer = default(string), DateTime? ValidAfter = default(DateTime?), DateTime? ValidBefore = default(DateTime?), string Subject = default(string), string SubjectAltNames = default(string), string Href = default(string))
        {
            this.AppAlias = AppAlias;
            this.Version = Version;
            this.SerialNumber = SerialNumber;
            this.Issuer = Issuer;
            this.ValidAfter = ValidAfter;
            this.ValidBefore = ValidBefore;
            this.Subject = Subject;
            this.SubjectAltNames = SubjectAltNames;
            this.Href = Href;
        }
        
        /// <summary>
        /// Gets or Sets AppAlias
        /// </summary>
        
        public string AppAlias { get; set; }
        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        
        public int? Version { get; set; }
        /// <summary>
        /// Gets or Sets SerialNumber
        /// </summary>
        
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or Sets Issuer
        /// </summary>
        
        public string Issuer { get; set; }
        /// <summary>
        /// Gets or Sets ValidAfter
        /// </summary>
        
        public DateTime? ValidAfter { get; set; }
        /// <summary>
        /// Gets or Sets ValidBefore
        /// </summary>
        
        public DateTime? ValidBefore { get; set; }
        /// <summary>
        /// Gets or Sets Subject
        /// </summary>
        
        public string Subject { get; set; }
        /// <summary>
        /// Gets or Sets SubjectAltNames
        /// </summary>
        
        public string SubjectAltNames { get; set; }
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
            sb.Append("class CustomUrlCertificate {\n");
            sb.Append("  AppAlias: ").Append(AppAlias).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
            sb.Append("  Issuer: ").Append(Issuer).Append("\n");
            sb.Append("  ValidAfter: ").Append(ValidAfter).Append("\n");
            sb.Append("  ValidBefore: ").Append(ValidBefore).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  SubjectAltNames: ").Append(SubjectAltNames).Append("\n");
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
            return this.Equals(obj as CustomUrlCertificate);
        }

        /// <summary>
        /// Returns true if CustomUrlCertificate instances are equal
        /// </summary>
        /// <param name="other">Instance of CustomUrlCertificate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomUrlCertificate other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AppAlias == other.AppAlias ||
                    this.AppAlias != null &&
                    this.AppAlias.Equals(other.AppAlias)
                ) && 
                (
                    this.Version == other.Version ||
                    this.Version != null &&
                    this.Version.Equals(other.Version)
                ) && 
                (
                    this.SerialNumber == other.SerialNumber ||
                    this.SerialNumber != null &&
                    this.SerialNumber.Equals(other.SerialNumber)
                ) && 
                (
                    this.Issuer == other.Issuer ||
                    this.Issuer != null &&
                    this.Issuer.Equals(other.Issuer)
                ) && 
                (
                    this.ValidAfter == other.ValidAfter ||
                    this.ValidAfter != null &&
                    this.ValidAfter.Equals(other.ValidAfter)
                ) && 
                (
                    this.ValidBefore == other.ValidBefore ||
                    this.ValidBefore != null &&
                    this.ValidBefore.Equals(other.ValidBefore)
                ) && 
                (
                    this.Subject == other.Subject ||
                    this.Subject != null &&
                    this.Subject.Equals(other.Subject)
                ) && 
                (
                    this.SubjectAltNames == other.SubjectAltNames ||
                    this.SubjectAltNames != null &&
                    this.SubjectAltNames.Equals(other.SubjectAltNames)
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
                if (this.AppAlias != null)
                    hash = hash * 59 + this.AppAlias.GetHashCode();
                if (this.Version != null)
                    hash = hash * 59 + this.Version.GetHashCode();
                if (this.SerialNumber != null)
                    hash = hash * 59 + this.SerialNumber.GetHashCode();
                if (this.Issuer != null)
                    hash = hash * 59 + this.Issuer.GetHashCode();
                if (this.ValidAfter != null)
                    hash = hash * 59 + this.ValidAfter.GetHashCode();
                if (this.ValidBefore != null)
                    hash = hash * 59 + this.ValidBefore.GetHashCode();
                if (this.Subject != null)
                    hash = hash * 59 + this.Subject.GetHashCode();
                if (this.SubjectAltNames != null)
                    hash = hash * 59 + this.SubjectAltNames.GetHashCode();
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
