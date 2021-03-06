//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 1/27/2013 7:27:37 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using splc.infrastructure.Repository;

using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace splc.domain
{

    /// <summary>
    /// There are no comments for splc.domain.BeholderPersonScreenName, splc.domain in the schema.
    /// </summary>
    public partial class BeholderPersonScreenName : IKeyed<int>
    {

        private int _Id;

        private string _ScreenName;

        private string _UsedAt;

        private System.Nullable<System.DateTime> _FirstKnownUseDate;

        private System.Nullable<System.DateTime> _LastKnownUseDate;

        private System.DateTime _DateCreated;

        private System.Nullable<System.DateTime> _DateModified;

        private System.Nullable<System.DateTime> _DateDeleted;

        private string _Comments;

        private BeholderPerson _BeholderPerson;

        private SecurityUser _SecurityUser_CreatedUserId;

        private SecurityUser _SecurityUser_DeletedUserId;

        private SecurityUser _SecurityUser_ModifiedUserId;

        private CommonPrimaryStatus _CommonPrimaryStatus;
    
        #region Extensibility Method Definitions
        
        partial void OnCreated();
        
        #endregion

        public BeholderPersonScreenName()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        public virtual int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

    
        /// <summary>
        /// There are no comments for ScreenName in the schema.
        /// </summary>
        public virtual string ScreenName
        {
            get
            {
                return this._ScreenName;
            }
            set
            {
                this._ScreenName = value;
            }
        }

    
        /// <summary>
        /// There are no comments for UsedAt in the schema.
        /// </summary>
        public virtual string UsedAt
        {
            get
            {
                return this._UsedAt;
            }
            set
            {
                this._UsedAt = value;
            }
        }

    
        /// <summary>
        /// There are no comments for FirstKnownUseDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> FirstKnownUseDate
        {
            get
            {
                return this._FirstKnownUseDate;
            }
            set
            {
                this._FirstKnownUseDate = value;
            }
        }

    
        /// <summary>
        /// There are no comments for LastKnownUseDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> LastKnownUseDate
        {
            get
            {
                return this._LastKnownUseDate;
            }
            set
            {
                this._LastKnownUseDate = value;
            }
        }

    
        /// <summary>
        /// There are no comments for DateCreated in the schema.
        /// </summary>
        public virtual System.DateTime DateCreated
        {
            get
            {
                return this._DateCreated;
            }
            set
            {
                this._DateCreated = value;
            }
        }

    
        /// <summary>
        /// There are no comments for DateModified in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> DateModified
        {
            get
            {
                return this._DateModified;
            }
            set
            {
                this._DateModified = value;
            }
        }

    
        /// <summary>
        /// There are no comments for DateDeleted in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> DateDeleted
        {
            get
            {
                return this._DateDeleted;
            }
            set
            {
                this._DateDeleted = value;
            }
        }

    
        /// <summary>
        /// There are no comments for Comments in the schema.
        /// </summary>
        public virtual string Comments
        {
            get
            {
                return this._Comments;
            }
            set
            {
                this._Comments = value;
            }
        }

    
        /// <summary>
        /// There are no comments for BeholderPerson in the schema.
        /// </summary>
        public virtual BeholderPerson BeholderPerson
        {
            get
            {
                return this._BeholderPerson;
            }
            set
            {
                this._BeholderPerson = value;
            }
        }

    
        /// <summary>
        /// There are no comments for SecurityUser_CreatedUserId in the schema.
        /// </summary>
        public virtual SecurityUser SecurityUser_CreatedUserId
        {
            get
            {
                return this._SecurityUser_CreatedUserId ?? new SecurityUser();
            }
            set
            {
                this._SecurityUser_CreatedUserId = value;
            }
        }

    
        /// <summary>
        /// There are no comments for SecurityUser_DeletedUserId in the schema.
        /// </summary>
        public virtual SecurityUser SecurityUser_DeletedUserId
        {
            get
            {
                return this._SecurityUser_DeletedUserId ?? new SecurityUser();
            }
            set
            {
                this._SecurityUser_DeletedUserId = value;
            }
        }

    
        /// <summary>
        /// There are no comments for SecurityUser_ModifiedUserId in the schema.
        /// </summary>
        public virtual SecurityUser SecurityUser_ModifiedUserId
        {
            get
            {
                return this._SecurityUser_ModifiedUserId ?? new SecurityUser();
            }
            set
            {
                this._SecurityUser_ModifiedUserId = value;
            }
        }

    
        /// <summary>
        /// There are no comments for CommonPrimaryStatus in the schema.
        /// </summary>
        public virtual CommonPrimaryStatus CommonPrimaryStatus
        {
            get
            {
                return this._CommonPrimaryStatus ?? new CommonPrimaryStatus();
            }
            set
            {
                this._CommonPrimaryStatus = value;
            }
        }
    }

}
