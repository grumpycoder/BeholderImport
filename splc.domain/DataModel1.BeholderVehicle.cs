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
    /// There are no comments for splc.domain.BeholderVehicle, splc.domain in the schema.
    /// </summary>
    public partial class BeholderVehicle : IKeyed<int>
    {

        private int _Id;

        private string _VIN;

        private System.Nullable<int> _VehicleYear;

        private System.DateTime _DateCreated;

        private System.Nullable<System.DateTime> _DateModified;

        private System.Nullable<System.DateTime> _DateDeleted;

        private Iesi.Collections.ISet _BeholderVehicleTags;

        private SecurityUser _SecurityUser_CreatedUserId;

        private SecurityUser _SecurityUser_DeletedUserId;

        private SecurityUser _SecurityUser_ModifiedUserId;

        private CommonVehicleColor _CommonVehicleColor;

        private CommonVehicleMake _CommonVehicleMake;

        private CommonVehicleModel _CommonVehicleModel;

        private CommonVehicleType _CommonVehicleType;
    
        #region Extensibility Method Definitions
        
        partial void OnCreated();
        
        #endregion

        public BeholderVehicle()
        {
            this._BeholderVehicleTags = new Iesi.Collections.HashedSet();
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
        /// There are no comments for VIN in the schema.
        /// </summary>
        public virtual string VIN
        {
            get
            {
                return this._VIN;
            }
            set
            {
                this._VIN = value;
            }
        }

    
        /// <summary>
        /// There are no comments for VehicleYear in the schema.
        /// </summary>
        public virtual System.Nullable<int> VehicleYear
        {
            get
            {
                return this._VehicleYear;
            }
            set
            {
                this._VehicleYear = value;
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
        /// There are no comments for BeholderVehicleTags in the schema.
        /// </summary>
        public virtual Iesi.Collections.ISet BeholderVehicleTags
        {
            get
            {
                return this._BeholderVehicleTags;
            }
            set
            {
                this._BeholderVehicleTags = value;
            }
        }

    
        /// <summary>
        /// There are no comments for SecurityUser_CreatedUserId in the schema.
        /// </summary>
        public virtual SecurityUser SecurityUser_CreatedUserId
        {
            get
            {
                return this._SecurityUser_CreatedUserId;
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
                return this._SecurityUser_DeletedUserId;
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
                return this._SecurityUser_ModifiedUserId;
            }
            set
            {
                this._SecurityUser_ModifiedUserId = value;
            }
        }

    
        /// <summary>
        /// There are no comments for CommonVehicleColor in the schema.
        /// </summary>
        public virtual CommonVehicleColor CommonVehicleColor
        {
            get
            {
                return this._CommonVehicleColor;
            }
            set
            {
                this._CommonVehicleColor = value;
            }
        }

    
        /// <summary>
        /// There are no comments for CommonVehicleMake in the schema.
        /// </summary>
        public virtual CommonVehicleMake CommonVehicleMake
        {
            get
            {
                return this._CommonVehicleMake;
            }
            set
            {
                this._CommonVehicleMake = value;
            }
        }

    
        /// <summary>
        /// There are no comments for CommonVehicleModel in the schema.
        /// </summary>
        public virtual CommonVehicleModel CommonVehicleModel
        {
            get
            {
                return this._CommonVehicleModel;
            }
            set
            {
                this._CommonVehicleModel = value;
            }
        }

    
        /// <summary>
        /// There are no comments for CommonVehicleType in the schema.
        /// </summary>
        public virtual CommonVehicleType CommonVehicleType
        {
            get
            {
                return this._CommonVehicleType;
            }
            set
            {
                this._CommonVehicleType = value;
            }
        }
    }

}
