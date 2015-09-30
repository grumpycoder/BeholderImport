//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 1/5/2013 5:40:36 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using splc.infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain
{

    /// <summary>
    /// There are no comments for splc.domain.BeholderPerson, splc.domain in the schema.
    /// </summary>
    /// 
    [Serializable]
    public class BeholderPerson : IKeyed<int>
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string SSN { get; set; }
        public virtual System.Nullable<int> PrefixId { get; set; }
        public virtual LookupType Prefix { get; set; }
        public virtual string FName { get; set; }
        public virtual string MInitial { get; set; }
        public virtual string LName { get; set; }
        public virtual System.Nullable<int> SuffixId { get; set; }
        public virtual LookupType Suffix { get; set; }
        public virtual System.Nullable<System.DateTime> DOB { get; set; }
        public virtual System.Nullable<bool> ActualEstimatedDOBIndicator { get; set; }
        public virtual string Sex { get; set; }
        public virtual System.Nullable<int> LicenseTypeId { get; set; }
        public virtual LookupType LicenseType { get; set; }
        public virtual string DriversLicenseNumber { get; set; }
        public virtual System.Nullable<int> DriversLicenseStateId { get; set; }
        public virtual System.Nullable<System.DateTime> DeceasedDate { get; set; }
        public virtual System.Nullable<bool> ActualEstimatedDeceasedDateIndicator { get; set; }
        public virtual System.Nullable<int> HairColorId { get; set; }
        public virtual LookupType HairColor { get; set; }
        public virtual System.Nullable<int> HairPatternId { get; set; }
        public virtual LookupType HairPattern { get; set; }
        public virtual System.Nullable<int> EyeColorId { get; set; }
        public virtual LookupType EyeColor { get; set; }
        public virtual System.Nullable<int> Height { get; set; }
        public virtual System.Nullable<int> Weight { get; set; }
        public virtual System.Nullable<int> RaceId { get; set; }
        public virtual LookupType Race { get; set; }
        public virtual System.Nullable<int> MartialStatusId { get; set; }
        public virtual LookupType MartialStatus { get; set; }
        public virtual System.Nullable<int> MovementClassId { get; set; }
        public virtual BeholderLookupType MovementClass { get; set; }
        public virtual System.Nullable<int> ConfidentialityTypeId { get; set; }
        public virtual BeholderLookupType ConfidentialityType { get; set; }
        public virtual string Comments { get; set; }
        public virtual System.Nullable<System.DateTime> DateCreated { get; set; }
        public virtual int CreatedUserId { get; set; }
        public virtual System.Nullable<System.DateTime> DateModified { get; set; }
        public virtual System.Nullable<int> ModifiedUserId { get; set; }
        public virtual System.Nullable<System.DateTime> DateDeleted { get; set; }
        public virtual System.Nullable<int> DeletedUserId { get; set; }

    }    
}