using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Models.Enums;
using splc.domain.Models;
using AudioVideoType = Domain.Models.AudioVideoType;
using Chapter = Domain.Models.Chapter;
using Gender = Domain.Models.Gender;
using MaritialStatus = Domain.Models.MaritialStatus;
using PrimaryStatus = Domain.Models.Enums.PrimaryStatus;

namespace BeholderImport
{
    internal static class ChapterService
    {
        public static Chapter CreateChapter(splc.domain.Models.Chapter beholderchapter, int? organizationId)
        {
            var c = beholderchapter;
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
                OrganizationId = organizationId == 0 ? null : organizationId,
            };
            chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added chapter {chapter.Name}" });

            return chapter;
        }

        public static void AddActivityList(Domain.Models.Chapter chapter, ICollection<ChapterStatusHistory> list)
        {
            foreach (var rel in list)
            {
                var c = rel;

                var activity = new ChapterActivity()
                {
                    Id = c.Id,
                    ActiveYear = c.ActiveYear,
                    Notes = "Added active year from status histories",
                };
                chapter.LogEntries.Add(new ChapterLogEntry()
                {
                    Note = $"Added Activityfor {activity.ActiveYear} {chapter.Name}"
                });
                chapter.ChapterActivity.Add(activity);
            }
        }

        public static void AddAliasList(Chapter chapter, ICollection<AliasChapterRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel;
                var @alias = new ChapterAlias()
                {
                    Id = c.AliasId,
                    Name = c.Alias.AliasName,
                    PrimaryStatus = (PrimaryStatus)c.PrimaryStatusId,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified
                };
                chapter.ChapterAliases.Add(@alias);
                chapter.LogEntries.Add(new ChapterLogEntry()
                {
                    Note = $"Added Chapter {chapter.Name} alias {@alias.Name}"
                });
            }
        }

        public static void AddPeople(Chapter chapter, ICollection<ChapterPersonRel> list)
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
                chapter.Persons.Add(person);
                chapter.LogEntries.Add(new ChapterLogEntry()
                {
                    Note = $"Added Chapter {chapter.Name} person relationship {person.ReverseFullName}"
                });
            }
        }
        
        public static void AddWebsites(Chapter chapter, ICollection<ChapterMediaWebsiteEGroupRel> list)
        {
            foreach (var rel in list)
            {

                var c = rel.MediaWebsiteEGroup;
                var existingWebsite = Helpers.GetWebsite(c.Id);

                if (existingWebsite != null)
                {
                    chapter.Websites.Add(existingWebsite);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added website {existingWebsite.Name} to Chapter" });
                    return;
                }

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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added website {website.Name} to Chapter" });
                chapter.Websites.Add(website);
            }
        }

        public static void AddCorrespondences(Chapter chapter, ICollection<ChapterMediaCorrespondenceRel> list)
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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added correspondence {correspondence.Name}" });
                chapter.Correspondence.Add(correspondence);
            }
        }

        public static void AddEvents(Chapter chapter, ICollection<ChapterEventRel> list)
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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added event {@event.Name}" });
                chapter.Events.Add(@event);
            }
        }
        
        public static void AddPublished(Chapter chapter, ICollection<ChapterMediaPublishedRel> list)
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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added publication {publication.Name}" });
                chapter.Publications.Add(publication);
            }

        }

        public static void AddSubscriptions(Chapter chapter, ICollection<ChapterSubscriptionRel> list)
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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added subscription {subscription.Name}" });
                chapter.Subscriptions.Add(subscription);
            }
        }

        public static void AddAudioVideo(Chapter chapter, ICollection<ChapterMediaAudioVideoRel> list)
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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added audio video {audioVideo.Title}" });
                chapter.AudioVideos.Add(audioVideo);
            }
        }

        public static void AddImages(Chapter chapter, ICollection<ChapterMediaImageRel> list)
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
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added image {mediaImage.Title}" });
                chapter.MediaImages.Add(mediaImage);
            }
        }

        public static void AddAddress(Chapter chapter, ICollection<AddressChapterRel> list)
        {
            foreach (var item in list)
            {
                var addr = new ChapterAddress()
                {
                    Street = item.Address.Address1,
                    Street2 = item.Address.Address2,
                    City = item.Address.City,
                    StateId = item.Address.StateId,
                    County = item.Address.County,
                    ZipCode = $"{item.Address.Zip5}-{item.Address.Zip4}",
                    Country = item.Address.Country,
                    Latitude = item.Address.Latitude,
                    Longitude = item.Address.Longitude,
                    DateCreated = item.Address.DateCreated, 
                    DateUpdated = item.Address.DateModified
                    //todo: need primarystatus here
                };
                chapter.ChapterAddresses.Add(addr);
                chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added address" });
            }
        }
    }
}