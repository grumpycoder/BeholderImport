using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ApprovalStatus : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Status")]
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<OrganizationMediaImageRel> OrganizationMediaImageRels { get; set; }
        public virtual ICollection<OrganizationMediaAudioVideoRel> OrganizationMediaAudioVideoRels { get; set; }
        public virtual ICollection<ChapterMediaImageRel> ChapterMediaImageRels { get; set; }
        public virtual ICollection<ChapterMediaAudioVideoRel> ChapterMediaAudioVideoRels { get; set; }

        public virtual ICollection<PersonMediaImageRel> PersonMediaImageRels { get; set; }
        public virtual ICollection<PersonMediaAudioVideoRel> PersonMediaAudioVideoRels { get; set; }
        public virtual ICollection<PersonEventRel> PersonEventRels { get; set; }
        public virtual ICollection<PersonPersonRel> PersonPersonRels { get; set; }
        public virtual ICollection<PersonContactRel> PersonContactRels { get; set; }
        public virtual ICollection<PersonMediaCorrespondenceRel> PersonMediaCorrespondenceRels { get; set; }

        public virtual ICollection<ChapterOrganizationRel> ChapterOrganizationRels { get; set; }
        public virtual ICollection<ChapterPersonRel> ChapterPersonRels { get; set; }
        public virtual ICollection<ChapterContactRel> ChapterContactRels { get; set; }
        public virtual ICollection<ChapterEventRel> ChapterEventRels { get; set; }
        public virtual ICollection<OrganizationPersonRel> OrganizationPersonRels { get; set; }
        public virtual ICollection<OrganizationEventRel> OrganizationEventRels { get; set; }
        public virtual ICollection<OrganizationVehicleRel> OrganizationVehicleRels { get; set; }
        public virtual ICollection<OrganizationMediaCorrespondenceRel> OrganizationMediaCorrespondenceRels { get; set; }

        public virtual ICollection<EventMediaImageRel> EventMediaImageRels { get; set; }
        public virtual ICollection<EventMediaAudioVideoRel> EventMediaAudioVideoRels { get; set; }
        public virtual ICollection<EventEventRel> EventEventRels { get; set; }
        public virtual ICollection<EventVehicleRel> EventVehicleRels { get; set; }
        public virtual ICollection<PersonVehicleRel> PersonVehicleRels { get; set; }
        public virtual ICollection<ChapterVehicleRel> ChapterVehicleRels { get; set; }
        public virtual ICollection<ChapterChapterRel> ChapterChapterRels { get; set; }
        public virtual ICollection<OrganizationOrganizationRel> OrganizationOrganizationRels { get; set; }
        public virtual ICollection<MediaImageVehicleRel> MediaImageVehicleRels { get; set; }
        public virtual ICollection<MediaImageMediaAudioVideoRel> MediaImageMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaImageMediaImageRel> MediaImageMediaImageRels { get; set; }
        public virtual ICollection<VehicleVehicleRel> VehicleVehicleRels { get; set; }
        public virtual ICollection<MediaAudioVideoVehicleRel> MediaAudioVideoVehicleRels { get; set; }
        public virtual ICollection<ContactMediaImageRel> ContactMediaImageRels { get; set; }
        public virtual ICollection<ContactContactRel> ContactContactRels { get; set; }
        public virtual ICollection<ChapterMediaCorrespondenceRel> ChapterMediaCorrespondenceRels { get; set; }
        public virtual ICollection<ContactMediaCorrespondenceRel> ContactMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaCorrespondenceEventRel> MediaCorrespondenceEventRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaAudioVideoRel> MediaCorrespondenceMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaCorrespondenceRel> MediaCorrespondenceMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaImageRel> MediaCorrespondenceMediaImageRels { get; set; }
        public virtual ICollection<MediaCorrespondenceSubscriptionRel> MediaCorrespondenceSubscriptionRels { get; set; }
        public virtual ICollection<MediaCorrespondenceVehicleRel> MediaCorrespondenceVehicleRels { get; set; }

        public virtual ICollection<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }
        public virtual ICollection<OrganizationMediaPublishedRel> OrganizationMediaPublishedRels { get; set; }
        public virtual ICollection<PersonMediaPublishedRel> PersonMediaPublishedRels { get; set; }
        public virtual ICollection<MediaPublishedEventRel> MediaPublishedEventRels { get; set; }
        public virtual ICollection<MediaPublishedMediaAudioVideoRel> MediaPublishedMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaPublishedMediaCorrespondenceRel> MediaPublishedMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaPublishedMediaImageRel> MediaPublishedMediaImageRels { get; set; }
        public virtual ICollection<MediaPublishedMediaPublishedRel> MediaPublishedMediaPublishedRels { get; set; }
        public virtual ICollection<MediaPublishedVehicleRel> MediaPublishedVehicleRels { get; set; }

        public virtual ICollection<ChapterSubscriptionRel> ChapterSubscriptionRels { get; set; }
        public virtual ICollection<ContactSubscriptionRel> ContactSubscriptionRels { get; set; }
        public virtual ICollection<EventSubscriptionRel> EventSubscriptionRels { get; set; }
        public virtual ICollection<MediaImageSubscriptionRel> MediaImageSubscriptionRels { get; set; }
        public virtual ICollection<MediaPublishedSubscriptionRel> MediaPublishedSubscriptionRels { get; set; }
        public virtual ICollection<OrganizationSubscriptionRel> OrganizationSubscriptionRels { get; set; }
        public virtual ICollection<SubscriptionSubscriptionRel> SubscriptionSubscriptionRels { get; set; }
        public virtual ICollection<SubscriptionVehicleRel> SubscriptionVehicleRels { get; set; }

        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public virtual ICollection<ChapterMediaWebsiteEGroupRel> ChapterMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<OrganizationMediaWebsiteEGroupRel> OrganizationMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<PersonMediaWebsiteEGroupRel> PersonMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<EventMediaWebsiteEGroupRel> EventMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupMediaAudioVideoRel> MediaWebsiteEGroupMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaWebsiteEGroupRel> MediaCorrespondenceMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaImageMediaWebsiteEGroupRel> MediaImageMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaPublishedMediaWebsiteEGroupRel> MediaPublishedMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupMediaWebsiteEGroupRel> MediaWebsiteEGroupMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupSubscriptionRel> MediaWebsiteEGroupSubscriptionRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupVehicleRel> MediaWebsiteEGroupVehicleRels { get; set; }

    }
}
