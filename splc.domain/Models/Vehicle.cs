using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Vehicle : StateInfo
    {
        public Vehicle()
        {
            ////this.ChapterVehicleRels = new List<ChapterVehicleRel>();
            ////this.ContactVehicleRels = new List<ContactVehicleRel>();
            ////this.EventVehicleRels = new List<EventVehicleRel>();
            ////this.MediaAudioVideoVehicleRels = new List<MediaAudioVideoVehicleRel>();
            ////this.MediaCorrespondenceVehicleRels = new List<MediaCorrespondenceVehicleRel>();
            ////this.MediaImageVehicleRels = new List<MediaImageVehicleRel>();
            ////this.MediaPublishedVehicleRels = new List<MediaPublishedVehicleRel>();
            ////this.MediaWebsiteEGroupVehicleRels = new List<MediaWebsiteEGroupVehicleRel>();
            ////this.OrganizationVehicleRels = new List<OrganizationVehicleRel>();
            //this.PersonVehicleRels = new List<PersonVehicleRel>();
            ////this.SubscriptionVehicleRels = new List<SubscriptionVehicleRel>();
            ////this.VehicleNewsSourceRels = new List<VehicleNewsSourceRel>();
            //this.VehicleTags = new List<VehicleTag>();
            ////this.VehicleVehicleRels = new List<VehicleVehicleRel>();
            ////this.VehicleVehicleRels1 = new List<VehicleVehicleRel>();
            //VehicleType = new VehicleType();
            //VehicleModel = new VehicleModel();
            //VehicleMake = new VehicleMake();
            //VehicleColor = new VehicleColor();
            //this.CreatedUser = new User();
            //this.ModifiedUser = new User();
            //this.DeletedUser = new User();
        }

        public int Id { get; set; }
        [Display(Name = "Make")]
        public int? VehicleMakeId { get; set; }
        [Display(Name = "Model")]
        public int? VehicleModelId { get; set; }
        [Display(Name = "Vehicle Type")]
        public int? VehicleTypeId { get; set; }
        [Display(Name = "Color")]
        public int? VehicleColorId { get; set; }
        [Display(Name = "VIN")]
        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "VIN contains invalid characters.")]
        public string VIN { get; set; }
        [Display(Name = "Vehicle Year")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public int? VehicleYear { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual VehicleColor VehicleColor { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        //public virtual ICollection<ContactVehicleRel> ContactVehicleRels { get; set; }
        public virtual ICollection<EventVehicleRel> EventVehicleRels { get; set; }
        public virtual ICollection<MediaAudioVideoVehicleRel> MediaAudioVideoVehicleRels { get; set; }
        public virtual ICollection<MediaCorrespondenceVehicleRel> MediaCorrespondenceVehicleRels { get; set; }
        public virtual ICollection<MediaImageVehicleRel> MediaImageVehicleRels { get; set; }
        public virtual ICollection<MediaPublishedVehicleRel> MediaPublishedVehicleRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupVehicleRel> MediaWebsiteEGroupVehicleRels { get; set; }
        public virtual ICollection<VehicleTag> VehicleTags { get; set; }
        public virtual ICollection<PersonVehicleRel> PersonVehicleRels { get; set; }
        public virtual ICollection<ChapterVehicleRel> ChapterVehicleRels { get; set; }
        public virtual ICollection<OrganizationVehicleRel> OrganizationVehicleRels { get; set; }
        public virtual ICollection<VehicleComment> VehicleComments { get; set; }
        public virtual ICollection<VehicleVehicleRel> VehicleVehicleRels { get; set; }
        public virtual ICollection<VehicleVehicleRel> VehicleVehicleRels2 { get; set; }
        public virtual ICollection<SubscriptionVehicleRel> SubscriptionVehicleRels { get; set; }

        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}", VehicleYear, VehicleColor != null  ? VehicleColor.Name : "No Color", VehicleMake != null ? VehicleMake.Name : "No Make", VehicleModel != null ? VehicleModel.Name : "No Model");
        }
    }
}
