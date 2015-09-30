﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 1/5/2013 5:40:36 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using splc.infrastructure.Repository;

namespace splc.domain
{

    /// <summary>
    /// There are no comments for splc.domain.BeholderLookupType, splc.domain in the schema.
    /// </summary>
    public partial class BeholderLookupType : IKeyed<int>
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual int LookupGroupId { get; set; }

        public virtual string Name { get; set; }

        public virtual System.DateTime DateCreated { get; set; }

        public virtual int CreatedUserId { get; set; }

        public virtual System.Nullable<System.DateTime> DateModified { get; set; }

        public virtual System.Nullable<int> ModifiedUserId { get; set; }

        public virtual System.Nullable<System.DateTime> DateDeleted { get; set; }

        public virtual System.Nullable<int> DeletedUserId { get; set; }

        public virtual Iesi.Collections.ISet ConfidentialityType { get; set; }

        public virtual Iesi.Collections.ISet MovementClass { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion

        public BeholderLookupType()
        {
            this.ConfidentialityType = new Iesi.Collections.HashedSet();
            this.MovementClass = new Iesi.Collections.HashedSet();
            OnCreated();
        }


    }
}
