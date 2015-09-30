using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using SecurityLevel = Domain.Models.Enums.SecurityLevel;
using splc.data;

namespace BeholderImport
{
    class Program
    {

        private static List<splc.domain.Models.MovementClass> m1;
        private static List<Domain.Models.Enums.Movement> m2;


        static void Main(string[] args)
        {
            var write = FluentConsole.Instance;
            var db = new ACDBContext();
            var context = new AppContext();

            m1 = db.MovementClasses.ToList();
            m2 = context.Movements.ToList();

            //            ProcessOrganizations(db, context);

            var total = db.Organizations.Count();
            var counter = 0;
            //            foreach (var organization in db.Organizations)
            //            {
            //                counter ++;
            //                write.Yellow.Line($"Creating ({counter} of {total}) {organization.OrganizationName}");
            //                ProcessOrganization(organization.Id);
            //                write.White.Line(new String('-', 15));
            //            }

            //            total = db.Chapters.Count();
            //            counter = 0;
            //            foreach (var chapter in db.Chapters.Where(x => x.Id > 6725))
            //            {
            //                counter ++;
            //                write.Yellow.Line($"Creating/Updating ({counter} of {total}) Chapter: {chapter.ChapterName}");
            //                ProcessChapter(chapter.Id);
            //                write.White.Line(new String('-', 15));
            //            }


            total = db.BeholderPersons.Count();
            counter = 0;
            foreach (var item in db.BeholderPersons)
            {
                counter++;
                write.Yellow.Line($"Creating/Updating ({counter} of {total}) Person: {item.CommonPerson.FullName}");
                ProcessPerson(item.Id);
                write.White.Line(new String('-', 15));
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        private static void ProcessPerson(int id)
        {
            var write = FluentConsole.Instance;

            var db = new ACDBContext();
            var c = db.BeholderPersons.Find(id);
            using (var context = new AppContext())
            {
                bool isNew;
                var person = context.Persons.Find(id);
                if (person == null)
                {
                    write.Red.Line($"Unable to find {c.CommonPerson.FullName} creating");
                    person = PersonService.CreatePerson(c);
                    isNew = true;
                }
                else
                {
                    write.DarkYellow.Line($"Found existing {c.CommonPerson.FullName} do nothing");
                    isNew = false;
                }

                write.Green.Line($"Adding Aliases ({c.CommonPerson.AliasPersonRels.Count})");
                PersonService.AddAliasList(person, c.CommonPerson.AliasPersonRels);

                write.Green.Line($"Adding Online Aliases ({c.PersonScreenNames.Count})");
                PersonService.AddOnlineAliasList(person, c.PersonScreenNames);

                write.Yellow.Line($"Adding Chapters to Person ({c.ChapterPersonRels.Count})");
                PersonService.AddChapters(person, c.ChapterPersonRels);

                write.Yellow.Line($"Adding Organizations to Person ({c.OrganizationPersonRels.Count})");
                PersonService.AddOrganizations(person, c.ChapterPersonRels);

                write.Yellow.Line($"Adding Addresses to Person ({c.CommonPerson.AliasPersonRels.Count})");
                PersonService.AddAddresses(person, c.CommonPerson.AddressPersonRels);

                write.Green.Line($"Adding Websites ({c.PersonMediaWebsiteEGroupRels.Count})");
                PersonService.AddWebsites(person, c.PersonMediaWebsiteEGroupRels);

                write.Yellow.Line($"Adding Correspondence to Person ({c.PersonMediaCorrespondenceRels.Count})");
                PersonService.AddCorrespondences(person, c.PersonMediaCorrespondenceRels);

                write.Blue.Line($"Adding Events to Person ({c.PersonEventRels.Count})");
                PersonService.AddEvents(person, c.PersonEventRels);

                write.Green.Line($"Adding Published to Person ({c.PersonMediaPublishedRels.Count})");
                PersonService.AddPublished(person, c.PersonMediaPublishedRels);

                write.Blue.Line($"Adding AudioVideo to Person ({c.PersonMediaAudioVideoRels.Count})");
                PersonService.AddAudioVideo(person, c.PersonMediaAudioVideoRels);

                write.Green.Line($"Adding Images to Person ({c.PersonMediaImageRels.Count})");
                PersonService.AddImages(person, c.PersonMediaImageRels);


            }
        }

        private static void ProcessChapter(int id)
        {
            var write = FluentConsole.Instance;

            var db = new ACDBContext();
            var c = db.Chapters.Find(id);
            using (var context = new AppContext())
            {
                bool isNew;
                var chapter = context.Chapters.Find(id);
                if (chapter == null)
                {
                    write.Red.Line($"Unable to find {c.ChapterName} creating");
                    var organizationId = c.ChapterOrganizationRels.Any() ? c.ChapterOrganizationRels.First().OrganizationId : 0;
                    chapter = ChapterService.CreateChapter(c, organizationId);
                    isNew = true;
                }
                else
                {
                    write.DarkYellow.Line($"Found existing {c.ChapterName} do nothing");
                    isNew = false;
                }
                if (isNew)
                {
                    write.Blue.Line($"Active Activity history ({c.ChapterStatusHistories.Count})");
                    ChapterService.AddActivityList(chapter, c.ChapterStatusHistories);

                    write.Green.Line($"Adding Aliases ({c.AliasChapterRels.Count})");
                    ChapterService.AddAliasList(chapter, c.AliasChapterRels);

                    write.Yellow.Line($"Adding Addresses to Chapter ({c.AddressChapterRels.Count})");
                    ChapterService.AddAddress(chapter, c.AddressChapterRels);

                    write.Yellow.Line($"Adding people to Chapter ({c.ChapterPersonRels.Count})");
                    ChapterService.AddPeople(chapter, c.ChapterPersonRels);

                    write.Green.Line($"Adding Websites ({c.ChapterMediaWebsiteEGroupRels.Count})");
                    ChapterService.AddWebsites(chapter, c.ChapterMediaWebsiteEGroupRels);

                    write.Yellow.Line($"Adding Correspondence to Chapter ({c.ChapterMediaCorrespondenceRels.Count})");
                    ChapterService.AddCorrespondences(chapter, c.ChapterMediaCorrespondenceRels);

                    write.Blue.Line($"Adding Events to Chapter ({c.ChapterEventRels.Count})");
                    ChapterService.AddEvents(chapter, c.ChapterEventRels);

                    write.Green.Line($"Adding Published to Chapter ({c.ChapterMediaPublishedRels.Count})");
                    ChapterService.AddPublished(chapter, c.ChapterMediaPublishedRels);

                    write.Yellow.Line($"Adding Subscriptions to Chapter ({c.ChapterSubscriptionRels.Count})");
                    ChapterService.AddSubscriptions(chapter, c.ChapterSubscriptionRels);

                    write.Blue.Line($"Adding AudioVideo to Chapter ({c.ChapterMediaAudioVideoRels.Count})");
                    ChapterService.AddAudioVideo(chapter, c.ChapterMediaAudioVideoRels);

                    write.Green.Line($"Adding Images to Chapter ({c.ChapterMediaImageRels.Count})");
                    ChapterService.AddImages(chapter, c.ChapterMediaImageRels);
                }


            }
        }

        private static void ProcessOrganization(int id)
        {
            var write = FluentConsole.Instance;

            var db = new ACDBContext();
            var o = db.Organizations.Find(id);
            using (var context = new AppContext())
            {

                var org = OrganizationService.CreateOrganization(o);

                write.Blue.Line($"Active Activity history ({o.OrganizationStatusHistories.Count})");
                OrganizationService.AddActivityList(org, o.OrganizationStatusHistories);

                write.Green.Line($"Adding Aliases ({o.AliasOrganizationRels.Count})");
                OrganizationService.AddAliasList(org, o.AliasOrganizationRels);

                write.Yellow.Line($"Adding people to Organization ({o.OrganizationPersonRels.Count})");
                OrganizationService.AddPeople(org, o.OrganizationPersonRels);

                write.Blue.Line($"Adding Chapters to Organization ({o.ChapterOrganizationRels.Count})");
                OrganizationService.AddChapters(org, o.ChapterOrganizationRels);

                write.Green.Line($"Loading Websites ({o.OrganizationMediaWebsiteEGroupRels.Count})");
                OrganizationService.AddWebsites(org, o.OrganizationMediaWebsiteEGroupRels);

                write.Yellow.Line($"Adding Correspondence to Organization ({o.OrganizationMediaCorrespondenceRels.Count})");
                OrganizationService.AddCorrespondences(org, o.OrganizationMediaCorrespondenceRels);

                write.Blue.Line($"Adding Events to Organization ({o.OrganizationEventRels.Count})");
                OrganizationService.AddEvents(org, o.OrganizationEventRels);

                write.Green.Line($"Adding Published to Organization ({o.OrganizationMediaPublishedRels.Count})");
                OrganizationService.AddPublished(org, o.OrganizationMediaPublishedRels);

                write.Yellow.Line($"Adding Subscriptions to Organization ({o.OrganizationSubscriptionRels.Count})");
                OrganizationService.AddSubscriptions(org, o.OrganizationSubscriptionRels);

                write.Blue.Line($"Adding AudioVideo to Organization ({o.OrganizationMediaAudioVideoRels.Count})");
                OrganizationService.AddAudioVideo(org, o.OrganizationMediaAudioVideoRels);

                write.Green.Line($"Adding Images to Organization ({o.OrganizationMediaImageRels.Count})");
                OrganizationService.AddImages(org, o.OrganizationMediaImageRels);

                context.Organizations.Add(org);
                context.SaveChanges();

                write.White.Line($"Saved Organization Record");

            }
        }

        private static void ProcessOrganizations(ACDBContext db, AppContext context)
        {
            foreach (var o in db.Organizations)
            {
                Console.WriteLine(o.OrganizationName);

                var org = new Organization()
                {
                    Id = o.Id,
                    Name = o.OrganizationName,
                    DateCreated = o.DateCreated,
                    DateDisbanded = o.DisbandDate,
                    DateFormed = o.FormedDate,
                    DateUpdated = o.DateModified,
                    Description = o.OrganizationDesc,
                    SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                    Chapters = new List<Chapter>(),
                    Persons = new List<Person>(),
                    Websites = new List<Website>(),
                    Correspondence = new List<Correspondence>(),
                    Events = new List<Event>(),
                    Publications = new List<Publication>(),
                    Subscriptions = new List<Subscription>(),
                    AudioVideos = new List<AudioVideo>(),
                    MediaImages = new List<MediaImage>(),
                    OrganizationActivity = new List<OrganizationActivity>(),
                    OrganizationAliases = new List<OrganizationAlias>(),
                    LogEntries = new List<OrganizationLogEntry>()
                };
                org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Organization {org.Name}" });

                Console.WriteLine("Adding Activty to Organization");
                foreach (var rel in o.OrganizationStatusHistories)
                {
                    var c = rel;
                    Console.WriteLine("Activity: {0}", c.ActiveStatus);
                    var activity = new OrganizationActivity()
                    {
                        Id = c.Id,
                        ActiveYear = c.ActiveYear,
                        Notes = "Added active year from status histories",
                    };
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Activityfor {activity.ActiveYear} {org.Name}" });
                    org.OrganizationActivity.Add(activity);
                }
                Console.WriteLine("Completed adding Activity");

                Console.WriteLine("Adding Aliases to Organization");
                foreach (var rel in o.AliasOrganizationRels)
                {
                    var c = rel;
                    Console.WriteLine("Alias: {0}", c.Alias.AliasName);
                    var @alias = new OrganizationAlias()
                    {
                        Id = c.AliasId,
                        Name = c.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)c.PrimaryStatusId,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified
                    };
                    org.OrganizationAliases.Add(@alias);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Organization {org.Name} alias {@alias.Name}" });
                }
                Console.WriteLine("Completed adding Aliases");


                Console.WriteLine("Adding People to Organization");
                foreach (var r in o.OrganizationPersonRels)
                {
                    var p = r.BeholderPerson;
                    Gender gender;
                    Enum.TryParse(p.CommonPerson.GenderId.ToString(), out gender);
                    MaritialStatus maritialStatus;
                    Enum.TryParse(p.CommonPerson.MaritialStatusId.ToString(), out maritialStatus);
                    Console.WriteLine("Person: {0}, {1}", p.CommonPerson.LName, p.CommonPerson.FullName);
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
                        LicenseType = GetLicenseType(p.CommonPerson.LicenseTypeId),
                        DriversLicenseNumber = p.CommonPerson.DriversLicenseNumber,
                        DriversLicenseStateId = p.CommonPerson.DriversLicenseStateId,
                        MaritialStatus = maritialStatus,
                        Gender = gender,
                        HairColorId = p.CommonPerson.HairColorId,
                        HairPatternId = p.CommonPerson.HairPatternId,
                        EyeColorId = p.CommonPerson.EyeColorId,
                        RaceId = p.CommonPerson.RaceId,
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        DistinguishableMarks = p.DistinguishableMarks,
                        Movement = ConvertMovementId(p.MovementClassId),
                        DateCreated = p.CommonPerson.DateCreated,
                        DateUpdated = p.CommonPerson.DateModified,
                        LogEntries = new List<PersonLogEntry>()
                    };
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                    org.Persons.Add(person);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Organization {org.Name} person relationship {person.ReverseFullName}" });
                }
                Console.WriteLine("Completed adding people");

                Console.WriteLine("Adding Chapters to Organization");
                foreach (var rel in o.ChapterOrganizationRels)
                {
                    var c = rel.Chapter;
                    Console.WriteLine("Chapter: {0}", c.ChapterName);
                    var chapter = new Chapter()
                    {
                        Id = c.Id,
                        Name = c.ChapterName,
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        Description = c.ChapterDesc,
                        DateFormed = c.FormedDate,
                        DateDisbanded = c.DisbandDate,
                        Movement = ConvertMovementId(c.MovementClassId),
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
                Console.WriteLine("Completed adding Chapters");
                context.Organizations.Add(org);

                Console.WriteLine("Adding Websites to Organization");
                foreach (var rel in o.OrganizationMediaWebsiteEGroupRels)
                {
                    var c = rel.MediaWebsiteEGroup;
                    Console.WriteLine("Website: {0}", c.Name);
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
                        Movement = ConvertMovementId(c.MovementClassId),
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified,
                        LogEntries = new List<WebsiteLogEntry>()
                    };
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added website {website.Name}" });
                    org.Websites.Add(website);
                }
                Console.WriteLine("Completed adding Websites");

                Console.WriteLine("Adding Correspondence to Organization");
                foreach (var rel in o.OrganizationMediaCorrespondenceRels)
                {
                    var c = rel.MediaCorrespondence;
                    Console.WriteLine("Correspondence: {0}", c.CorrespondenceName);
                    var correspondence = new Correspondence()
                    {
                        Id = c.Id,
                        Name = c.CorrespondenceName,
                        CatalogId = c.CatalogId,
                        DateReceived = c.DateReceived,
                        Summary = c.Summary,
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        Sender = c.FromName,
                        Receiver = c.FromName,
                        Movement = ConvertMovementId(c.MovementClassId),
                        City = c.City,
                        County = c.County,
                        StateId = c.StateId,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified,
                        LogEntries = new List<CorrespondenceLogEntry>()
                    };
                    correspondence.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added correspondence {correspondence.Name}" });
                    org.Correspondence.Add(correspondence);
                }
                Console.WriteLine("Completed adding Correspondence");

                Console.WriteLine("Adding Events to Organization");
                foreach (var rel in o.OrganizationEventRels)
                {
                    var c = rel.Event;
                    Console.WriteLine("Event: {0}", c.EventName);
                    var @event = new Event()
                    {
                        Id = c.Id,
                        Name = c.EventName,
                        Summary = c.Summary,
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        DocumentationType = (DocumentationType)c.EventDocumentationTypeId,
                        //todo: EventType
                        //                        EventType = 
                        Movement = ConvertMovementId(c.MovementClassId),
                        EventDate = c.EventDate,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified,
                        LogEntries = new List<EventLogEntry>()
                    };
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added event {@event.Name}" });
                    org.Events.Add(@event);
                }
                Console.WriteLine("Completed adding Events");

                Console.WriteLine("Adding Published to Organizations");
                foreach (var rel in o.OrganizationMediaPublishedRels)
                {
                    var c = rel.MediaPublished;
                    Console.WriteLine("Publication: {0}", c.Name);
                    var publication = new Publication()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Summary = c.Summary,
                        DateReceived = c.DateReceived,
                        DatePublished = c.DatePublished,
                        Author = c.Author,
                        CatalogId = c.CatalogId,
                        RenewalType = ConvertRenewalType(c.RenewalPermissionTypeId),
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        Movement = ConvertMovementId(c.MovementClassId),
                        //                        PublicationTypeId = c.PublishedTypeId,
                        City = c.City,
                        County = c.County,
                        StateId = c.StateId,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified,
                        LogEntries = new List<PublicationLogEntry>()
                    };
                    publication.LogEntries.Add(new PublicationLogEntry() { Note = $"Added publication {publication.Name}" });
                    org.Publications.Add(publication);
                }
                Console.WriteLine("Completed adding Publications");

                Console.WriteLine("Adding Subscriptions to Organization");
                foreach (var rel in o.OrganizationSubscriptionRels)
                {
                    var c = rel.Subscription;
                    Console.WriteLine("Subscription: {0}", c.PublicationName);
                    var subscription = new Subscription()
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
                    org.Subscriptions.Add(subscription);
                }
                Console.WriteLine("Completed adding Subscription");

                Console.WriteLine("Adding Audio/Video to Organization");
                foreach (var rel in o.OrganizationMediaAudioVideoRels)
                {
                    var c = rel.MediaAudioVideo;
                    Console.WriteLine("Audio/Video: {0}", c.Title);
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
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        Movement = ConvertMovementId(c.MovementClassId),
                        City = c.City,
                        County = c.County,
                        StateId = c.StateId,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified,
                        LogEntries = new List<AudioVideoLogEntry>()
                    };
                    audioVideo.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added audiovideo {audioVideo.Title}" });
                    org.AudioVideos.Add(audioVideo);
                }
                Console.WriteLine("Completed adding Audio/Video");

                Console.WriteLine("Adding Images to Organization");
                foreach (var rel in o.OrganizationMediaImageRels)
                {
                    var c = rel.MediaImage;
                    Console.WriteLine("Image: {0}", c.ImageTitle);
                    var mediaImage = new MediaImage()
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
                        ImageType = ConvertImageType(c.ImageTypeId),
                        SecurityLevel = o.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                        Movement = ConvertMovementId(c.MovementClassId),
                        ////                        Image = c.Image.IMAGE1, 
                        //                        MimeType = c.Image.MimeType.Name, //todo: make type
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateModified,
                        LogEntries = new List<MediaImageLogEntry>()
                    };
                    mediaImage.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added image {mediaImage.Title}" });
                    org.MediaImages.Add(mediaImage);
                }
                Console.WriteLine("Completed adding Images");

                Console.WriteLine("Saving Organizations");
                context.Organizations.Add(org);
                Console.WriteLine("Saving Completed");
            }


            context.SaveChanges();
            Console.WriteLine("Completed adding Organizations");
        }

        private static ImageType? ConvertImageType(int? id)
        {
            if (id != null)
            {
                return (ImageType)id;
            }
            return null;
        }


        private static RenewalType? ConvertRenewalType(int? renewalPermissionTypeId)
        {
            if (renewalPermissionTypeId != null)
            {
                return (RenewalType)renewalPermissionTypeId;
            }
            return null;
        }

        private static LicenseType? GetLicenseType(int? licenseTypeId)
        {

            switch (licenseTypeId)
            {
                case 11:
                    return LicenseType.Chauffeur;
                case 12:
                    return LicenseType.IDCardOnly;
                case 1:
                    return LicenseType.Operator;
                case 2:
                    return LicenseType.Restricted;
                default:
                    return null;
            }
        }

        private static Movement ConvertMovementId(int? movementClassId = 0)
        {
            if (movementClassId != null)
            {
                var i = m1.First(x => x.Id == movementClassId);
                return m2.First(x => x.Name == i.Name);
            }
            return null;

        }
    }
}
