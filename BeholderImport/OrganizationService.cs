using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using splc.data;
using splc.domain.Models;
using AudioVideoType = Domain.Models.AudioVideoType;
using Gender = Domain.Models.Gender;
using ImageType = Domain.Models.ImageType;
using LicenseType = Domain.Models.LicenseType;
using MaritialStatus = Domain.Models.MaritialStatus;
using Organization = Domain.Models.Organization;
using PrimaryStatus = Domain.Models.Enums.PrimaryStatus;

namespace BeholderImport
{
    internal static class OrganizationService
    {
        private static List<splc.domain.Models.MovementClass> m1;
        private static List<Domain.Models.Enums.Movement> m2;

        static OrganizationService()
        {
            using (var context = new AppContext())
            {
                m2 = context.Movements.ToList();
            }
            using (var db = new ACDBContext())
            {
                m1 = db.MovementClasses.ToList();
            }

        }

        public static Domain.Models.Organization CreateOrganization(splc.domain.Models.Organization organization)
        {

            var org = new Domain.Models.Organization()
            {
                Id = organization.Id,
                Name = organization.OrganizationName,
                DateCreated = organization.DateCreated,
                DateDisbanded = organization.DisbandDate,
                DateFormed = organization.FormedDate,
                DateUpdated = organization.DateModified,
                Description = organization.OrganizationDesc,
                SecurityLevel =
                    organization.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open
            };
            org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Organization {org.Name}" });
            return org;

        }

        public static void AddActivityList(Domain.Models.Organization org,
            ICollection<OrganizationStatusHistory> history)
        {
            foreach (var rel in history)
            {
                var c = rel;

                var activity = new OrganizationActivity()
                {
                    Id = c.Id,
                    ActiveYear = c.ActiveYear,
                    Notes = "Added active year from status histories",
                };
                org.LogEntries.Add(new OrganizationLogEntry()
                {
                    Note = $"Added Activityfor {activity.ActiveYear} {org.Name}"
                });
                org.OrganizationActivity.Add(activity);
            }
        }

        public static void AddAliasList(Organization org, ICollection<AliasOrganizationRel> aliases)
        {
            foreach (var rel in aliases)
            {
                var c = rel;
                var @alias = new OrganizationAlias()
                {
                    Id = c.AliasId,
                    Name = c.Alias.AliasName,
                    PrimaryStatus = (PrimaryStatus)c.PrimaryStatusId,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified
                };
                org.OrganizationAliases.Add(@alias);
                org.LogEntries.Add(new OrganizationLogEntry()
                {
                    Note = $"Added Organization {org.Name} alias {@alias.Name}"
                });
            }
        }

        public static void AddPeople(Organization org, ICollection<OrganizationPersonRel> list)
        {
            foreach (var r in list)
            {
                var p = r.BeholderPerson;
                Gender gender;
                Enum.TryParse(p.CommonPerson.GenderId.ToString(), out gender);
                MaritialStatus maritialStatus;
                Enum.TryParse(p.CommonPerson.MaritialStatusId.ToString(), out maritialStatus);
                var person = new Person()
                {
                    Id = p.CommonPersonId,
                    PrefixId = p.CommonPerson.PrefixId,
                    SuffixId = p.CommonPerson.SuffixId,
                    FirstName = p.CommonPerson.FName,
                    MiddleName = p.CommonPerson.MName,
                    LastName = p.CommonPerson.LName,
                    DOB = p.CommonPerson.DOB,
                    ActualDOB = p.CommonPerson.ActualDOBIndicator,
                    DeceasedDate = p.CommonPerson.DeceasedDate,
                    ActualDeceasedDate = p.CommonPerson.ActualDeceasedDateIndicator,
                    Height = p.CommonPerson.Height,
                    Weight = p.CommonPerson.Weight,
                    SSN = p.CommonPerson.SSN,
                    LicenseType = Helpers.GetLicenseType(p.CommonPerson.LicenseTypeId),
                    DriversLicenseNumber = p.CommonPerson.DriversLicenseNumber,
                    DriversLicenseStateId = p.CommonPerson.DriversLicenseStateId,
                    MaritialStatus = maritialStatus,
                    Gender = gender,
                    HairColorId = p.CommonPerson.HairColorId,
                    HairPatternId = p.CommonPerson.HairPatternId,
                    EyeColorId = p.CommonPerson.EyeColorId,
                    RaceId = p.CommonPerson.RaceId,
                    SecurityLevel = p.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    DistinguishableMarks = p.DistinguishableMarks,
                    Movement = Helpers.ConvertMovementId(p.MovementClassId),
                    DateCreated = p.CommonPerson.DateCreated,
                    DateUpdated = p.CommonPerson.DateModified,
                    LogEntries = new List<PersonLogEntry>()
                };
                person.LogEntries.Add(new PersonLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                org.Persons.Add(person);
                org.LogEntries.Add(new OrganizationLogEntry()
                {
                    Note = $"Added Organization {org.Name} person relationship {person.ReverseFullName}"
                });
            }
        }

        public static void AddChapters(Organization org, ICollection<ChapterOrganizationRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.Chapter;
                var chapter = new Domain.Models.Chapter()
                {
                    Id = c.Id,
                    Name = c.ChapterName,
                    SecurityLevel = c.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    Description = c.ChapterDesc,
                    DateFormed = c.FormedDate,
                    DateDisbanded = c.DisbandDate,
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    IsHeadquarters = c.IsHeadquarters,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    OrganizationId = rel.OrganizationId,
                    Persons = new List<Person>(),
                    LogEntries = new List<ChapterLogEntry>()
                };
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added chapter {chapter.Name}" });
                org.Chapters.Add(chapter);
            }
        }

        public static void AddWebsites(Organization org, ICollection<OrganizationMediaWebsiteEGroupRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.MediaWebsiteEGroup;
                var website = new Website()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Type = (WebsiteType)c.WebsiteEGroupTypeId,
                    Url = c.URL,
                    Summary = c.Summary,
                    DateDiscovered = c.DateDiscovered,
                    DatePublished = c.DatePublished,
                    DateOffline = c.DateOffline,
                    WhoIs = c.WhoIsInfo,
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<WebsiteLogEntry>()
                };
                website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added website {website.Name}" });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added website {website.Name} to Organization" });
                org.Websites.Add(website);
            }
        }

        public static void AddCorrespondences(Organization org, ICollection<OrganizationMediaCorrespondenceRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.MediaCorrespondence;
                var correspondence = new Correspondence()
                {
                    Id = c.Id,
                    Name = c.CorrespondenceName,
                    CatalogId = c.CatalogId,
                    DateReceived = c.DateReceived,
                    Summary = c.Summary,
                    SecurityLevel = c.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    Sender = c.FromName,
                    Receiver = c.FromName,
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    City = c.City,
                    County = c.County,
                    StateId = c.StateId,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<CorrespondenceLogEntry>()
                };
                correspondence.LogEntries.Add(new CorrespondenceLogEntry()
                {
                    Note = $"Added correspondence {correspondence.Name}"
                });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added correspondence {correspondence.Name}"});
                org.Correspondence.Add(correspondence);
            }
        }

        public static void AddEvents(Organization org, ICollection<OrganizationEventRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.Event;
                var @event = new Domain.Models.Event()
                {
                    Id = c.Id,
                    Name = c.EventName,
                    Summary = c.Summary,
                    SecurityLevel = c.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    DocumentationType = (DocumentationType)c.EventDocumentationTypeId,
                    //todo: EventType
                    //                        EventType = 
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    EventDate = c.EventDate,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<EventLogEntry>()
                };
                @event.LogEntries.Add(new EventLogEntry() { Note = $"Added event {@event.Name}" });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added event {@event.Name}" });
                org.Events.Add(@event);
            }
        }

        public static void AddPublished(Organization org, ICollection<OrganizationMediaPublishedRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.MediaPublished;
                var publication = new Publication()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Summary = c.Summary,
                    DateReceived = c.DateReceived,
                    DatePublished = c.DatePublished,
                    Author = c.Author,
                    CatalogId = c.CatalogId,
                    RenewalType = Helpers.ConvertRenewalType(c.RenewalPermissionTypeId),
                    SecurityLevel = c.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    //                        PublicationTypeId = c.PublishedTypeId,
                    City = c.City,
                    County = c.County,
                    StateId = c.StateId,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<PublicationLogEntry>()
                };
                publication.LogEntries.Add(new PublicationLogEntry() { Note = $"Added publication {publication.Name}" });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added publication {publication.Name}" });
                org.Publications.Add(publication);
            }

        }

        public static void AddSubscriptions(Organization org, ICollection<OrganizationSubscriptionRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.Subscription;
                var subscription = new Domain.Models.Subscription()
                {
                    Id = c.Id,
                    Name = c.PublicationName,
                    Rate = c.SubscriptionRate,
                    RenewalDate = c.RenewalPermissionDate,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<SubscriptionLogEntry>()
                };
                subscription.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added subscription {subscription.Name}" });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added subscription {subscription.Name}" });
                org.Subscriptions.Add(subscription);
            }
        }
        
        public static void AddAudioVideo(Organization org, ICollection<OrganizationMediaAudioVideoRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.MediaAudioVideo;
             
                var audioVideo = new AudioVideo()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Summary = c.Summary,
                    SpeakerCommentator = c.SpeakerCommentator,
                    MediaLength = c.MediaLength,
                    CatalogId = c.CatalogId,
                    DateReceivedRecorded = c.DateReceivedRecorded,
                    DateAired = c.DateAired,
                    AudioVideoType = (AudioVideoType)c.AudioVideoTypeId,
                    SecurityLevel = c.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    City = c.City,
                    County = c.County,
                    StateId = c.StateId,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<AudioVideoLogEntry>()
                };
                audioVideo.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added audio video {audioVideo.Title}" });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added audio video {audioVideo.Title}" });
                org.AudioVideos.Add(audioVideo);
            }
        }

        public static void AddImages(Organization org, ICollection<OrganizationMediaImageRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel.MediaImage;
                var mediaImage = new Domain.Models.MediaImage()
                {
                    Id = c.Id,
                    Title = c.ImageTitle,
                    Summary = c.Summary,
                    FileName = c.ImageFileName,
                    CatalogId = c.CatalogId,
                    ContactOwner = c.ContactOwner,
                    BatchSortOrder = c.BatchSortOrder,
                    Photographer = c.PhotographerArtist,
                    DatePublished = c.DatePublished,
                    DateTaken = c.DateTaken,
                    RollFrame = c.RollFrameNumber,
                    ImageType = Helpers.ConvertImageType(c.ImageTypeId),
                    SecurityLevel = c.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    Movement = Helpers.ConvertMovementId(c.MovementClassId),
                    ////                        Image = c.Image.IMAGE1, 
                    //                        MimeType = c.Image.MimeType.Name, //todo: make type
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified,
                    LogEntries = new List<MediaImageLogEntry>()
                };
                mediaImage.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added image {mediaImage.Title}" });
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added image {mediaImage.Title}" });
                org.MediaImages.Add(mediaImage);
            }

        }
    }
}