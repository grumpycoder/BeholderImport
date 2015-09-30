using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace splc.domain.Models
{
    public partial class User: StateInfo
    {
        public User()
        {
            //this.AddressSubscriptionsRelsCreated = new List<AddressSubscriptionsRel>();
            //this.AddressSubscriptionsRelsModified = new List<AddressSubscriptionsRel>();
            //this.AddressSubscriptionsRelsDeleted = new List<AddressSubscriptionsRel>();

            //this.SubscriptionsCreated = new List<Subscription>();
            //this.SubscriptionsModified = new List<Subscription>();
            //this.SubscriptionsDeleted = new List<Subscription>();
            //this.SubscriptionCommentsCreated = new List<SubscriptionComment>();
            //this.SubscriptionCommentsModified = new List<SubscriptionComment>();
            //this.SubscriptionCommentsDeleted = new List<SubscriptionComment>();

            //this.OrganizationCommentsCreated = new List<OrganizationComment>();
            //this.OrganizationCommentsModified = new List<OrganizationComment>();
            //this.OrganizationCommentsDeleted = new List<OrganizationComment>();
            //this.ChapterCommentsCreated = new List<ChapterComment>();
            //this.ChapterCommentsModified = new List<ChapterComment>();
            //this.ChapterCommentsDeleted = new List<ChapterComment>();
            //this.PersonCommentsCreated = new List<PersonComment>();
            //this.PersonCommentsModified = new List<PersonComment>();
            //this.PersonCommentsDeleted = new List<PersonComment>();
            //this.VehicleCommentsCreated = new List<VehicleComment>();
            //this.VehicleCommentsModified = new List<VehicleComment>();
            //this.VehicleCommentsDeleted = new List<VehicleComment>();
            //this.ContactCommentsCreated = new List<ContactComment>();
            //this.ContactCommentsModified = new List<ContactComment>();
            //this.ContactCommentsDeleted = new List<ContactComment>();
            //this.MediaCorrespondenceCommentsCreated = new List<MediaCorrespondenceComment>();
            //this.MediaCorrespondenceCommentsModified = new List<MediaCorrespondenceComment>();
            //this.MediaCorrespondenceCommentsDeleted = new List<MediaCorrespondenceComment>();
            //this.NewsSourceCommentsCreated = new List<NewsSourceComment>();
            //this.NewsSourceCommentsModified = new List<NewsSourceComment>();
            //this.NewsSourceCommentsDeleted = new List<NewsSourceComment>();
            //this.UserTypesCreated = new List<UserType>();
            //this.UserTypesModified = new List<UserType>();
            //this.UserTypesDeleted = new List<UserType>();
            //this.EventCommentsCreated = new List<EventComment>();
            //this.EventCommentsModified = new List<EventComment>();
            //this.EventCommentsDeleted = new List<EventComment>();
            //this.MediaPublishedCommentsCreated = new List<MediaPublishedComment>();
            //this.MediaPublishedCommentsModified = new List<MediaPublishedComment>();
            //this.MediaPublishedCommentsDeleted = new List<MediaPublishedComment>();
        }
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime? LastLoginDate { get; set; }
        [Display(Name = "Username")]
        //[Remote("UserNameAlreadyExists", "Validation", AdditionalFields = "Id, UserName", ErrorMessage = "Username already has exists.", HttpMethod = "POST")]
        [Required(ErrorMessage = "Username required.")]
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public int? ActiveStatusId { get; set; }
        public int? UserTypeId { get; set; }
        public int? SecurityId { get; set; }        
        public bool Disabled { get; set; }

        public virtual CommonPerson CommonPerson { get; set; }
        public virtual UserType UserType { get; set; }
        
        public virtual ICollection<ActiveStatus> ActiveStatusesCreated { get; set; }
        public virtual ICollection<ActiveStatus> ActiveStatusesModified { get; set; }
        public virtual ICollection<ActiveStatus> ActiveStatusesDeleted { get; set; }
        public virtual ICollection<AddressType> AddressTypesCreated { get; set; }
        public virtual ICollection<AddressType> AddressTypesModified { get; set; }
        public virtual ICollection<AddressType> AddressTypesDeleted { get; set; }
        public virtual ICollection<ApprovalStatus> ApprovalStatusesCreated { get; set; }
        public virtual ICollection<ApprovalStatus> ApprovalStatusesModified { get; set; }
        public virtual ICollection<ApprovalStatus> ApprovalStatusesDeleted { get; set; }
        public virtual ICollection<AudioVideoType> AudioVideoTypesCreated { get; set; }
        public virtual ICollection<AudioVideoType> AudioVideoTypesModified { get; set; }
        public virtual ICollection<AudioVideoType> AudioVideoTypesDeleted { get; set; }
        public virtual ICollection<ChapterType> ChapterTypesCreated { get; set; }
        public virtual ICollection<ChapterType> ChapterTypesModified { get; set; }
        public virtual ICollection<ChapterType> ChapterTypesDeleted { get; set; }
        public virtual ICollection<ConfidentialityType> ConfidentialityTypesCreated { get; set; }
        public virtual ICollection<ConfidentialityType> ConfidentialityTypesModified { get; set; }
        public virtual ICollection<ConfidentialityType> ConfidentialityTypesDeleted { get; set; }
        public virtual ICollection<ContactInfoType> ContactInfoTypesCreated { get; set; }
        public virtual ICollection<ContactInfoType> ContactInfoTypesModified { get; set; }
        public virtual ICollection<ContactInfoType> ContactInfoTypesDeleted { get; set; }
        public virtual ICollection<ContactTopic> ContactTopicsCreated { get; set; }
        public virtual ICollection<ContactTopic> ContactTopicsModified { get; set; }
        public virtual ICollection<ContactTopic> ContactTopicsDeleted { get; set; }
        public virtual ICollection<ContactType> ContactTypesCreated { get; set; }
        public virtual ICollection<ContactType> ContactTypesModified { get; set; }
        public virtual ICollection<ContactType> ContactTypesDeleted { get; set; }
        public virtual ICollection<CorrespondenceType> CorrespondenceTypesCreated { get; set; }
        public virtual ICollection<CorrespondenceType> CorrespondenceTypesModified { get; set; }
        public virtual ICollection<CorrespondenceType> CorrespondenceTypesDeleted { get; set; }
        public virtual ICollection<EventDocumentationType> EventDocumentationTypesCreated { get; set; }
        public virtual ICollection<EventDocumentationType> EventDocumentationTypesModified { get; set; }
        public virtual ICollection<EventDocumentationType> EventDocumentationTypesDeleted { get; set; }
        public virtual ICollection<EventType> EventTypesCreated { get; set; }
        public virtual ICollection<EventType> EventTypesModified { get; set; }
        public virtual ICollection<EventType> EventTypesDeleted { get; set; }
        public virtual ICollection<EyeColor> EyeColorsCreated { get; set; }
        public virtual ICollection<EyeColor> EyeColorsModified { get; set; }
        public virtual ICollection<EyeColor> EyeColorsDeleted { get; set; }
        public virtual ICollection<Gender> GendersCreated { get; set; }
        public virtual ICollection<Gender> GendersModified { get; set; }
        public virtual ICollection<Gender> GendersDeleted { get; set; }
        public virtual ICollection<HairColor> HairColorsCreated { get; set; }
        public virtual ICollection<HairColor> HairColorsModified { get; set; }
        public virtual ICollection<HairColor> HairColorsDeleted { get; set; }
        public virtual ICollection<HairPattern> HairPatternsCreated { get; set; }
        public virtual ICollection<HairPattern> HairPatternsModified { get; set; }
        public virtual ICollection<HairPattern> HairPatternsDeleted { get; set; }
        public virtual ICollection<ImageType> ImageTypesCreated { get; set; }
        public virtual ICollection<ImageType> ImageTypesModified { get; set; }
        public virtual ICollection<ImageType> ImageTypesDeleted { get; set; }
        public virtual ICollection<LibraryCategoryType> LibraryCategoryTypesCreated { get; set; }
        public virtual ICollection<LibraryCategoryType> LibraryCategoryTypesModified { get; set; }
        public virtual ICollection<LibraryCategoryType> LibraryCategoryTypesDeleted { get; set; }
        public virtual ICollection<LicenseType> LicenseTypesCreated { get; set; }
        public virtual ICollection<LicenseType> LicenseTypesModified { get; set; }
        public virtual ICollection<LicenseType> LicenseTypesDeleted { get; set; }
        public virtual ICollection<MaritialStatus> MaritialStatusesCreated { get; set; }
        public virtual ICollection<MaritialStatus> MaritialStatusesModified { get; set; }
        public virtual ICollection<MaritialStatus> MaritialStatusesDeleted { get; set; }
        public virtual ICollection<MediaType> MediaTypesCreated { get; set; }
        public virtual ICollection<MediaType> MediaTypesModified { get; set; }
        public virtual ICollection<MediaType> MediaTypesDeleted { get; set; }
        public virtual ICollection<MimeType> MimeTypesCreated { get; set; }
        public virtual ICollection<MimeType> MimeTypesModified { get; set; }
        public virtual ICollection<MimeType> MimeTypesDeleted { get; set; }
        public virtual ICollection<MovementClass> MovementClassesCreated { get; set; }
        public virtual ICollection<MovementClass> MovementClassesModified { get; set; }
        public virtual ICollection<MovementClass> MovementClassesDeleted { get; set; }
        public virtual ICollection<NewsSourceType> NewsSourceTypesCreated { get; set; }
        public virtual ICollection<NewsSourceType> NewsSourceTypesModified { get; set; }
        public virtual ICollection<NewsSourceType> NewsSourceTypesDeleted { get; set; }
        public virtual ICollection<OrganizationType> OrganizationTypesCreated { get; set; }
        public virtual ICollection<OrganizationType> OrganizationTypesModified { get; set; }
        public virtual ICollection<OrganizationType> OrganizationTypesDeleted { get; set; }
        public virtual ICollection<Prefix> PrefixesCreated { get; set; }
        public virtual ICollection<Prefix> PrefixesModified { get; set; }
        public virtual ICollection<Prefix> PrefixesDeleted { get; set; }
        public virtual ICollection<PrimaryStatus> PrimaryStatusesCreated { get; set; }
        public virtual ICollection<PrimaryStatus> PrimaryStatusesModified { get; set; }
        public virtual ICollection<PrimaryStatus> PrimaryStatusesDeleted { get; set; }
        public virtual ICollection<PublishedType> PublishedTypesCreated { get; set; }
        public virtual ICollection<PublishedType> PublishedTypesModified { get; set; }
        public virtual ICollection<PublishedType> PublishedTypesDeleted { get; set; }
        public virtual ICollection<Race> RacesCreated { get; set; }
        public virtual ICollection<Race> RacesModified { get; set; }
        public virtual ICollection<Race> RacesDeleted { get; set; }
        public virtual ICollection<RelationshipType> RelationshipTypesCreated { get; set; }
        public virtual ICollection<RelationshipType> RelationshipTypesModified { get; set; }
        public virtual ICollection<RelationshipType> RelationshipTypesDeleted { get; set; }
        public virtual ICollection<RemovalStatus> RemovalStatusesCreated { get; set; }
        public virtual ICollection<RemovalStatus> RemovalStatusesModified { get; set; }
        public virtual ICollection<RemovalStatus> RemovalStatusesDeleted { get; set; }
        public virtual ICollection<RenewalPermmisionType> RenewalPermmisionTypesCreated { get; set; }
        public virtual ICollection<RenewalPermmisionType> RenewalPermmisionTypesModified { get; set; }
        public virtual ICollection<RenewalPermmisionType> RenewalPermmisionTypesDeleted { get; set; }
        public virtual ICollection<State> StatesCreated { get; set; }
        public virtual ICollection<State> StatesModified { get; set; }
        public virtual ICollection<Suffix> SuffixesCreated { get; set; }
        public virtual ICollection<Suffix> SuffixesModified { get; set; }
        public virtual ICollection<Suffix> SuffixesDeleted { get; set; }
        public virtual ICollection<TagType> TagTypesCreated { get; set; }
        public virtual ICollection<TagType> TagTypesModified { get; set; }
        public virtual ICollection<TagType> TagTypesDeleted { get; set; }
        public virtual ICollection<VehicleColor> VehicleColorsCreated { get; set; }
        public virtual ICollection<VehicleColor> VehicleColorsModified { get; set; }
        public virtual ICollection<VehicleColor> VehicleColorsDeleted { get; set; }
        public virtual ICollection<VehicleMake> VehicleMakesCreated { get; set; }
        public virtual ICollection<VehicleMake> VehicleMakesModified { get; set; }
        public virtual ICollection<VehicleMake> VehicleMakesDeleted { get; set; }
        public virtual ICollection<VehicleModel> VehicleModelsCreated { get; set; }
        public virtual ICollection<VehicleModel> VehicleModelsModified { get; set; }
        public virtual ICollection<VehicleModel> VehicleModelsDeleted { get; set; }
        public virtual ICollection<VehicleType> VehicleTypesCreated { get; set; }
        public virtual ICollection<VehicleType> VehicleTypesModified { get; set; }
        public virtual ICollection<VehicleType> VehicleTypesDeleted { get; set; }
        public virtual ICollection<WebIncidentType> WebIncidentTypesCreated { get; set; }
        public virtual ICollection<WebIncidentType> WebIncidentTypesModified { get; set; }
        public virtual ICollection<WebIncidentType> WebIncidentTypesDeleted { get; set; }
        public virtual ICollection<WebsiteGroupType> WebsiteGroupTypesCreated { get; set; }
        public virtual ICollection<WebsiteGroupType> WebsiteGroupTypesModified { get; set; }
        public virtual ICollection<WebsiteGroupType> WebsiteGroupTypesDeleted { get; set; }

        public virtual ICollection<Address> AddressesCreated { get; set; }
        public virtual ICollection<Address> AddressesModified { get; set; }
        public virtual ICollection<Address> AddressesDeleted { get; set; }
        public virtual ICollection<AddressSubscriptionsRel> AddressSubscriptionsRelsCreated { get; set; }
        public virtual ICollection<AddressSubscriptionsRel> AddressSubscriptionsRelsModified { get; set; }
        public virtual ICollection<AddressSubscriptionsRel> AddressSubscriptionsRelsDeleted { get; set; }
        public virtual ICollection<AddressChapterRel> AddressChapterRelsCreated { get; set; }
        public virtual ICollection<AddressChapterRel> AddressChapterRelsModified { get; set; }
        public virtual ICollection<AddressChapterRel> AddressChapterRelsDeleted { get; set; }
        public virtual ICollection<AddressPersonRel> AddressPersonRelsCreated { get; set; }
        public virtual ICollection<AddressPersonRel> AddressPersonRelsModified { get; set; }
        public virtual ICollection<AddressPersonRel> AddressPersonRelsDeleted { get; set; }
        public virtual ICollection<AddressEventRel> AddressEventRelsCreated { get; set; }
        public virtual ICollection<AddressEventRel> AddressEventRelsModified { get; set; }
        public virtual ICollection<AddressEventRel> AddressEventRelsDeleted { get; set; }
        public virtual ICollection<AddressContactRel> AddressContactRelsCreated { get; set; }
        public virtual ICollection<AddressContactRel> AddressContactRelsModified { get; set; }
        public virtual ICollection<AddressContactRel> AddressContactRelsDeleted { get; set; }

        public virtual ICollection<Alias> AliasesCreated { get; set; }
        public virtual ICollection<Alias> AliasesModified { get; set; }
        public virtual ICollection<Alias> AliasesDeleted { get; set; }
        public virtual ICollection<AliasChapterRel> AliasChapterRelsCreated { get; set; }
        public virtual ICollection<AliasChapterRel> AliasChapterRelsModified { get; set; }
        public virtual ICollection<AliasChapterRel> AliasChapterRelsDeleted { get; set; }
        public virtual ICollection<AliasOrganizationRel> AliasOrganizationRelsCreated { get; set; }
        public virtual ICollection<AliasOrganizationRel> AliasOrganizationRelsModified { get; set; }
        public virtual ICollection<AliasOrganizationRel> AliasOrganizationRelsDeleted { get; set; }
        public virtual ICollection<AliasPersonRel> AliasPersonRelsCreated { get; set; }
        public virtual ICollection<AliasPersonRel> AliasPersonRelsModified { get; set; }
        public virtual ICollection<AliasPersonRel> AliasPersonRelsDeleted { get; set; }

        public virtual ICollection<BeholderPerson> BeholderPersonsCreated { get; set; }
        public virtual ICollection<BeholderPerson> BeholderPersonsModified { get; set; }
        public virtual ICollection<BeholderPerson> BeholderPersonsDeleted { get; set; }
        public virtual ICollection<PersonComment> PersonCommentsCreated { get; set; }
        public virtual ICollection<PersonComment> PersonCommentsModified { get; set; }
        public virtual ICollection<PersonComment> PersonCommentsDeleted { get; set; }
        public virtual ICollection<PersonScreenName> PersonScreenNamesCreated { get; set; }
        public virtual ICollection<PersonScreenName> PersonScreenNamesModified { get; set; }
        public virtual ICollection<PersonScreenName> PersonScreenNamesDeleted { get; set; }

        public virtual ICollection<Chapter> ChaptersCreated { get; set; }
        public virtual ICollection<Chapter> ChaptersModified { get; set; }
        public virtual ICollection<Chapter> ChaptersDeleted { get; set; }
        public virtual ICollection<ChapterContactInfoRel> ChapterContactInfoRelsCreated { get; set; }
        public virtual ICollection<ChapterContactInfoRel> ChapterContactInfoRelsModified { get; set; }
        public virtual ICollection<ChapterContactInfoRel> ChapterContactInfoRelsDeleted { get; set; }
        public virtual ICollection<ChapterComment> ChapterCommentsCreated { get; set; }
        public virtual ICollection<ChapterComment> ChapterCommentsModified { get; set; }
        public virtual ICollection<ChapterComment> ChapterCommentsDeleted { get; set; }
        public virtual ICollection<ChapterStatusHistory> ChapterStatusHistoriesCreated { get; set; }
        public virtual ICollection<ChapterStatusHistory> ChapterStatusHistoriesModified { get; set; }
        public virtual ICollection<ChapterStatusHistory> ChapterStatusHistoriesDeleted { get; set; }

        public virtual ICollection<CommonPerson> CommonPersonsCreated { get; set; }
        public virtual ICollection<CommonPerson> CommonPersonsModified { get; set; }
        public virtual ICollection<CommonPerson> CommonPersonsDeleted { get; set; }

        public virtual ICollection<ContactComment> ContactCommentsCreated { get; set; }
        public virtual ICollection<ContactComment> ContactCommentsModified { get; set; }
        public virtual ICollection<ContactComment> ContactCommentsDeleted { get; set; }
        public virtual ICollection<Contact> ContactsCreated { get; set; }
        public virtual ICollection<Contact> ContactsModified { get; set; }
        public virtual ICollection<Contact> ContactsDeleted { get; set; }

        public virtual ICollection<ContactInfo> ContactInfoCreated { get; set; }
        public virtual ICollection<ContactInfo> ContactInfoModified { get; set; }
        public virtual ICollection<ContactInfo> ContactInfoDeleted { get; set; }
        public virtual ICollection<ContactInfoPersonRel> ContactInfoPersonRelsCreated { get; set; }
        public virtual ICollection<ContactInfoPersonRel> ContactInfoPersonRelsModified { get; set; }
        public virtual ICollection<ContactInfoPersonRel> ContactInfoPersonRelsDeleted { get; set; }

        public virtual ICollection<Event> EventsCreated { get; set; }
        public virtual ICollection<Event> EventsModified { get; set; }
        public virtual ICollection<Event> EventsDeleted { get; set; }
        public virtual ICollection<EventComment> EventCommentsCreated { get; set; }
        public virtual ICollection<EventComment> EventCommentsModified { get; set; }
        public virtual ICollection<EventComment> EventCommentsDeleted { get; set; }
        public virtual ICollection<EventStatusHistory> EventStatusHistoriesCreated { get; set; }
        public virtual ICollection<EventStatusHistory> EventStatusHistoriesModified { get; set; }
        public virtual ICollection<EventStatusHistory> EventStatusHistoriesDeleted { get; set; }

        public virtual ICollection<Image> ImagesCreated { get; set; }
        public virtual ICollection<Image> ImagesModified { get; set; }
        public virtual ICollection<Image> ImagesDeleted { get; set; }

        public virtual ICollection<MediaAudioVideo> MediaAudioVideosCreated { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideosModified { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideosDeleted { get; set; }
        public virtual ICollection<MediaAudioVideoComment> MediaAudioVideoCommentsCreated { get; set; }
        public virtual ICollection<MediaAudioVideoComment> MediaAudioVideoCommentsModified { get; set; }
        public virtual ICollection<MediaAudioVideoComment> MediaAudioVideoCommentsDeleted { get; set; }

        public virtual ICollection<MediaCorrespondence> MediaCorrespondencesCreated { get; set; }
        public virtual ICollection<MediaCorrespondence> MediaCorrespondencesModified { get; set; }
        public virtual ICollection<MediaCorrespondence> MediaCorrespondencesDeleted { get; set; }
        public virtual ICollection<MediaCorrespondenceComment> MediaCorrespondenceCommentsCreated { get; set; }
        public virtual ICollection<MediaCorrespondenceComment> MediaCorrespondenceCommentsModified { get; set; }
        public virtual ICollection<MediaCorrespondenceComment> MediaCorrespondenceCommentsDeleted { get; set; }

        public virtual ICollection<MediaImage> MediaImagesCreated { get; set; }
        public virtual ICollection<MediaImage> MediaImagesModified { get; set; }
        public virtual ICollection<MediaImage> MediaImagesDeleted { get; set; }
        public virtual ICollection<MediaImageComment> MediaImageCommentsCreated { get; set; }
        public virtual ICollection<MediaImageComment> MediaImageCommentsModified { get; set; }
        public virtual ICollection<MediaImageComment> MediaImageCommentsDeleted { get; set; }

        public virtual ICollection<MediaPublished> MediaPublishedsCreated { get; set; }
        public virtual ICollection<MediaPublished> MediaPublishedsModified { get; set; }
        public virtual ICollection<MediaPublished> MediaPublishedsDeleted { get; set; }
        public virtual ICollection<MediaPublishedComment> MediaPublishedCommentsCreated { get; set; }
        public virtual ICollection<MediaPublishedComment> MediaPublishedCommentsModified { get; set; }
        public virtual ICollection<MediaPublishedComment> MediaPublishedCommentsDeleted { get; set; }

        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroupsCreated { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroupsModified { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroupsDeleted { get; set; }
        public virtual ICollection<MediaWebsiteEGroupComment> MediaWebsiteEGroupCommentsCreated { get; set; }
        public virtual ICollection<MediaWebsiteEGroupComment> MediaWebsiteEGroupCommentsModified { get; set; }
        public virtual ICollection<MediaWebsiteEGroupComment> MediaWebsiteEGroupCommentsDeleted { get; set; }

        public virtual ICollection<NewsSource> NewsSourcesCreated { get; set; }
        public virtual ICollection<NewsSource> NewsSourcesModified { get; set; }
        public virtual ICollection<NewsSource> NewsSourcesDeleted { get; set; }
        public virtual ICollection<NewsSourceComment> NewsSourceCommentsCreated { get; set; }
        public virtual ICollection<NewsSourceComment> NewsSourceCommentsModified { get; set; }
        public virtual ICollection<NewsSourceComment> NewsSourceCommentsDeleted { get; set; }

        public virtual ICollection<Organization> OrganizationsCreated { get; set; }
        public virtual ICollection<Organization> OrganizationsModified { get; set; }
        public virtual ICollection<Organization> OrganizationsDeleted { get; set; }
        public virtual ICollection<OrganizationComment> OrganizationCommentsCreated { get; set; }
        public virtual ICollection<OrganizationComment> OrganizationCommentsModified { get; set; }
        public virtual ICollection<OrganizationComment> OrganizationCommentsDeleted { get; set; }
        public virtual ICollection<OrganizationStatusHistory> OrganizationStatusHistoriesCreated { get; set; }
        public virtual ICollection<OrganizationStatusHistory> OrganizationStatusHistoriesModified { get; set; }
        public virtual ICollection<OrganizationStatusHistory> OrganizationStatusHistoriesDeleted { get; set; }

        public virtual ICollection<Subscription> SubscriptionsCreated { get; set; }
        public virtual ICollection<Subscription> SubscriptionsModified { get; set; }
        public virtual ICollection<Subscription> SubscriptionsDeleted { get; set; }
        public virtual ICollection<SubscriptionComment> SubscriptionCommentsCreated { get; set; }
        public virtual ICollection<SubscriptionComment> SubscriptionCommentsModified { get; set; }
        public virtual ICollection<SubscriptionComment> SubscriptionCommentsDeleted { get; set; }

        public virtual ICollection<Vehicle> VehiclesCreated { get; set; }
        public virtual ICollection<Vehicle> VehiclesModified { get; set; }
        public virtual ICollection<Vehicle> VehiclesDeleted { get; set; }
        public virtual ICollection<VehicleComment> VehicleCommentsCreated { get; set; }
        public virtual ICollection<VehicleComment> VehicleCommentsModified { get; set; }
        public virtual ICollection<VehicleComment> VehicleCommentsDeleted { get; set; }
        public virtual ICollection<VehicleTag> VehicleTagsCreated { get; set; }
        public virtual ICollection<VehicleTag> VehicleTagsModified { get; set; }
        public virtual ICollection<VehicleTag> VehicleTagsDeleted { get; set; }

        public virtual ICollection<Religion> ReligionsCreated { get; set; }
        public virtual ICollection<Religion> ReligionsModified { get; set; }
        public virtual ICollection<Religion> ReligionsDeleted { get; set; }

        public virtual ICollection<UserType> UserTypesCreated { get; set; }
        public virtual ICollection<UserType> UserTypesModified { get; set; }
        public virtual ICollection<UserType> UserTypesDeleted { get; set; }
        public virtual ICollection<User> UsersCreated { get; set; }
        public virtual ICollection<User> UsersModified { get; set; }
        public virtual ICollection<User> UsersDeleted { get; set; }

        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        [NotMapped]
        public int? MaxConfidentialityLevel { get; set; }

    }
}
