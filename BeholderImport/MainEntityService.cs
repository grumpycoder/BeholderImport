using System;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using splc.data;

namespace BeholderImport
{
    public partial class EntityService
    {
        public static void LoadOrganizations(int? takecount = 0)
        {
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var totalAdded = 0;
            if (takecount == 0) takecount = db.Organizations.Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Organizations ON");
                    w.White.Line($"Creating {db.Organizations.Take(takecount ?? 0).Count()} Organizations");
                    foreach (var item in db.Organizations.Take(takecount ?? 0))
                    {
                        var i = context.Organizations.Find(item.Id);
                        if (i != null) continue;
                        totalAdded++;
                        var org = new Domain.Models.Organization()
                        {
                            Id = item.Id,
                            Name = item.OrganizationName?.Trim(),
                            DateDisbanded = item.DisbandDate,
                            DateFormed = item.FormedDate,
                            Description = item.OrganizationDesc?.Trim(),
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Organization {org.Name}" });
                        context.Organizations.Add(org);
                    }
                    w.Gray.Line($"Saving Organizations");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Organizations OFF");
                    trans.Commit();
                }
            }
            w.Green.Line($"Saved {totalAdded} new Organizations");
            w.White.Line(new String('-', 15));
        }

        public static void OrganizationChapters(int? takecount = 0)
        {
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            if (takecount == 0) takecount = db.Chapters.Count();
            var total = db.Chapters.Take(takecount ?? 0).Count();

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Chapters ON");
                    w.White.Line($"Creating {takecount} Chapters");

                    foreach (var item in db.Chapters.Take(takecount ?? 0))
                    {
                        var i = context.Chapters.Find(item.Id);
                        if (i != null) continue;
                        count++;
                        var chapter = new Domain.Models.Chapter()
                        {
                            Id = item.Id,
                            Name = item.ChapterName?.Trim(),
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            Description = item.ChapterDesc?.Trim(),
                            DateFormed = item.FormedDate,
                            DateDisbanded = item.DisbandDate,
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            IsHeadquarters = item.IsHeadquarters,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added chapter {chapter.Name}" });
                        w.Cyan.Line($"Creating {chapter.Name} ({count} of {total})");
                        context.Chapters.Add(chapter);
                    }
                    w.Gray.Line($"Saving Chapters");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Chapters OFF");
                    trans.Commit();
                }
                w.Green.Line($"Saved {count} new Chapters");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadAliases(int? takecount = 0)
        {
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            if (takecount == 0) takecount = db.Aliases.Count();
            var total = db.Aliases.Take(takecount ?? 0).Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Aliases ON");
                    w.White.Line($"Creating {takecount} Aliases");

                    foreach (var item in db.Aliases.Take(takecount ?? 0))
                    {
                        var i = context.Aliases.Find(item.Id);
                        if (i != null) continue;
                        count++;
                        var alias = new Domain.Models.Alias()
                        {
                            Id = item.Id,
                            Name = item.AliasName?.Trim(),
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        w.Cyan.Line($"Creating {alias.Name} ({count} of {total})");
                        context.Aliases.Add(alias);
                    }
                    w.Gray.Line($"Saving Aliases");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Aliases OFF");
                    trans.Commit();
                }
                w.Green.Line($"Saved {count} new Aliases");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadPeople(int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Chapters.Count();
            var total = db.BeholderPersons.Where(p => p.OrganizationPersonRels.Any()).OrderBy(x => x.Id).Skip(6000).Take(2000).Count();
            //            var total = db.BeholderPersons.Take(takecount ?? 0).Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Persons ON");
                    w.White.Line($"Creating {total} People");

                    //                    foreach (var item in db.BeholderPersons.Take(takecount ?? 0).Include("CommonPerson"))
                    foreach (var item in db.BeholderPersons.Where(p => p.OrganizationPersonRels.Any()).OrderBy(x => x.Id).Skip(6000).Take(2000).Include("CommonPerson"))
                    {count++;
                        var i = context.Persons.Find(item.CommonPersonId);
                        if (i != null)
                        {
                            w.Red.Line($"Adding Person {count} of {total}: Person {i.FullName} already exists");
                            continue;
                        }
                        
                        Gender gender;
                        Enum.TryParse(item.CommonPerson.GenderId.ToString(), out gender);
                        MaritialStatus maritialStatus;
                        Enum.TryParse(item.CommonPerson.MaritialStatusId.ToString(), out maritialStatus);
                        var person = new Person()
                        {
                            Id = item.CommonPersonId,
                            PrefixId = item.CommonPerson.PrefixId,
                            SuffixId = item.CommonPerson.SuffixId,
                            FirstName = item.CommonPerson.FName?.Trim(),
                            MiddleName = item.CommonPerson.MName?.Trim(),
                            LastName = item.CommonPerson.LName?.Trim(),
                            DOB = item.CommonPerson.DOB,
                            ActualDOB = item.CommonPerson.ActualDOBIndicator,
                            DeceasedDate = item.CommonPerson.DeceasedDate,
                            ActualDeceasedDate = item.CommonPerson.ActualDeceasedDateIndicator,
                            Height = item.CommonPerson.Height,
                            Weight = item.CommonPerson.Weight,
                            SSN = item.CommonPerson.SSN,
                            LicenseType = Helpers.GetLicenseType(item.CommonPerson.LicenseTypeId),
                            DriversLicenseNumber = item.CommonPerson.DriversLicenseNumber,
                            DriversLicenseStateId = item.CommonPerson.DriversLicenseStateId,
                            MaritialStatus = maritialStatus,
                            Gender = gender,
                            HairColorId = item.CommonPerson.HairColorId,
                            HairPatternId = item.CommonPerson.HairPatternId,
                            EyeColorId = item.CommonPerson.EyeColorId,
                            RaceId = item.CommonPerson.RaceId,
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            DistinguishableMarks = item.DistinguishableMarks?.Trim(),
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            DateCreated = item.CommonPerson.DateCreated,
                            DateUpdated = item.CommonPerson.DateModified,
                        };
                        person.LogEntries.Add(new PersonLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                        w.Green.Line($"Adding {count} of {total} Person {person.ReverseFullName}");
                        savedCount ++;
                        context.Persons.Add(person);
                    }
                    w.Gray.Line($"Saving People");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Persons OFF");
                    trans.Commit();
                }
                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} People in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new string('-', 15));
            }
        }

        public static void LoadAudioVideo(int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Organizations.Count();
            var total = db.MediaAudioVideos.Take(takecount ?? 0).Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AudioVideos ON");
                    w.White.Line($"Creating {db.MediaAudioVideos.Count()} Audio Video");
                    foreach (var item in db.MediaAudioVideos.Take(takecount ?? 0))
                    {    count++;
                        var i = context.AudioVideos.Find(item.Id);
                        if (i != null)
                        {
                            w.Red.Line($"Adding Audio Video {count} of {total}: {i.Title} already exists");
                            continue;
                        }
                    
                        var audioVideo = new AudioVideo()
                        {
                            Id = item.Id,
                            Title = item.Title?.Trim(),
                            Summary = item.Summary?.Trim(),
                            SpeakerCommentator = item.SpeakerCommentator?.Trim(),
                            MediaLength = item.MediaLength?.Trim(),
                            CatalogId = item.CatalogId?.Trim(),
                            DateReceivedRecorded = item.DateReceivedRecorded,
                            DateAired = item.DateAired,
                            AudioVideoType = (AudioVideoType)item.AudioVideoTypeId,
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            City = item.City?.Trim(),
                            County = item.County?.Trim(),
                            StateId = item.StateId,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified,
                        };
                        audioVideo.LogEntries.Add(new AudioVideoLogEntry()
                        {
                            Note = $"Added audio video {audioVideo.Title}"
                        });
                        w.Cyan.Line($"Creating {audioVideo.Title} ({count} of {total})");
                        context.AudioVideos.Add(audioVideo);
                    }
                    w.Gray.Line($"Saving Audio Videos");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AudioVideos OFF");
                    trans.Commit();
                }
                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Audio Video in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new string('-', 15));
            }
        }

        public static void LoadCorrespondence(int? takecount = 0)
        {
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            if (takecount == 0) takecount = db.MediaCorrespondences.Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    var total = db.MediaCorrespondences.Take(takecount ?? 0).Count();
                    w.White.Line($"Creating {takecount} Correspondence");

                    foreach (var item in db.MediaCorrespondences.Take(takecount ?? 0))
                    {
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Correspondences ON");
                        var i = context.Correspondences.Find(item.Id);
                        if (i != null) continue;

                        count++;
                        var correspondence = new Correspondence()
                        {
                            Id = item.Id,
                            Name = item.CorrespondenceName?.Trim(),
                            CatalogId = item.CatalogId?.Trim(),
                            DateReceived = item.DateReceived,
                            Summary = item.Summary?.Trim(),
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            Sender = item.FromName?.Trim(),
                            Receiver = item.FromName?.Trim(),
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            City = item.City?.Trim(),
                            County = item.County?.Trim(),
                            StateId = item.StateId,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        correspondence.LogEntries.Add(new CorrespondenceLogEntry()
                        {
                            Note = $"Added correspondence {correspondence.Name}"
                        });
                        w.Cyan.Line($"Creating {correspondence.Name} ({count} of {total})");
                        context.Correspondences.Add(correspondence);
                    }
                    w.Gray.Line($"Saving Correspondences");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Correspondences OFF");
                    trans.Commit();
                    w.Green.Line($"Saved {count} Correspondences");
                    w.White.Line(new string('-', 15));
                }
            }

        }

        public static void LoadEvents(int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            if (takecount == 0) takecount = db.Events.Count();
            var total = db.Events.Take(takecount ?? 0).Count();
            var count = 0;
            var savedCount = 0;
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    w.White.Line($"Creating {db.Events.Take(takecount ?? 0).Count()} Events");
                    foreach (var item in db.Events.Where(x => x.OrganizationEventRels.Any()).Take(takecount ?? 0))
                    {
                        count++;
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Events ON");
                        var i = context.Events.Find(item.Id);
                        if (i != null)
                        {
                            w.Red.Line($"Adding Event {count} of {total}: {i.Name} already exists");
                            continue;
                        }
                        
                        var @event = new Domain.Models.Event()
                        {
                            Id = item.Id,
                            Name = item.EventName?.Trim(),
                            Summary = item.Summary?.Trim(),
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            DocumentationType = (DocumentationType)item.EventDocumentationTypeId,
                            //todo: EventType
                            //                        EventType = 
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            EventDate = item.EventDate,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        savedCount++;
                        @event.LogEntries.Add(new EventLogEntry() { Note = $"Added event {@event.Name}" });
                        w.Cyan.Line($"Creating {@event.Name} ({count} of {total})");
                        context.Events.Add(@event);
                    }

                    w.Gray.Line($"Saving Events");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Events OFF");
                    trans.Commit();
                    TimeSpan totalTime = DateTime.Now - startTime;
                    w.Green.Line($"Saved {savedCount} Events in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                    w.White.Line(new string('-', 15));
                }
            }
        }

        public static void LoadImages(int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Events.Count();
            var total = db.MediaImages.Take(takecount ?? 0).Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    w.White.Line($"Creating {total} MediaImages");
                    foreach (var item in db.MediaImages.Where(x => x.OrganizationMediaImageRels.Any()).Take(takecount ?? 0))
                    {     count++;
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MediaImages ON");
                        var i = context.MediaImages.Find(item.Id);
                        if (i != null)
                        {
                            w.Red.Line($"Adding Image {count} of {total}: {i.Title} already exists");
                            continue;
                        }
                        
                        var mediaImage = new Domain.Models.MediaImage()
                        {
                            Id = item.Id,
                            Title = item.ImageTitle?.Trim(),
                            Summary = item.Summary?.Trim(),
                            FileName = item.ImageFileName?.Trim(),
                            CatalogId = item.CatalogId?.Trim(),
                            ContactOwner = item.ContactOwner?.Trim(),
                            BatchSortOrder = item.BatchSortOrder,
                            Photographer = item.PhotographerArtist?.Trim(),
                            DatePublished = item.DatePublished,
                            DateTaken = item.DateTaken,
                            RollFrame = item.RollFrameNumber?.Trim(),
                            ImageType = Helpers.ConvertImageType(item.ImageTypeId),
                            SecurityLevel = item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            ////                        Image = item.Image.IMAGE1, 
                            //                        MimeType = item.Image.MimeType.Name, //todo: make type
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified,
                        };
                        mediaImage.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added image {mediaImage.Title}" });
                        savedCount ++;
                        w.Cyan.Line($"Creating {mediaImage.Title} ({count} of {total})");
                        context.MediaImages.Add(mediaImage);
                    }
                    w.Gray.Line($"Saving Images");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MediaImages OFF");
                    trans.Commit();
                    TimeSpan totalTime = DateTime.Now - startTime;
                    w.Green.Line($"Saved {savedCount} Images in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                    w.White.Line(new string('-', 15));
                }
            }
        }

        public static void LoadPublications(int? takecount = 0)
        {
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            if (takecount == 0) takecount = db.Events.Count();
            var total = db.MediaPublisheds.Take(takecount ?? 0).Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    w.White.Line($"Creating {total} Publications");
                    foreach (var item in db.MediaPublisheds.Take(takecount ?? 0))
                    {
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Publications ON");
                        var i = context.Publications.Find(item.Id);
                        if (i != null) continue;

                        count++;
                        var publication = new Publication()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Summary = item.Summary,
                            DateReceived = item.DateReceived,
                            DatePublished = item.DatePublished,
                            Author = item.Author,
                            CatalogId = item.CatalogId,
                            RenewalType = Helpers.ConvertRenewalType(item.RenewalPermissionTypeId),
                            SecurityLevel = item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            //                        PublicationTypeId = item.PublishedTypeId,
                            City = item.City,
                            County = item.County,
                            StateId = item.StateId,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        publication.LogEntries.Add(new PublicationLogEntry() { Note = $"Added publication {publication.Name}" });
                        w.Cyan.Line($"Creating {publication.Name} ({count} of {total})");
                        context.Publications.Add(publication);
                    }
                    w.Gray.Line($"Saving Publication");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Publications OFF");
                    trans.Commit();
                    w.Green.Line($"Saved {count} Publications");
                    w.White.Line(new string('-', 15));
                }
            }
        }

        public static void LoadSubscriptions(int? takecount = 0)
        {
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            if (takecount == 0) takecount = db.Events.Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    var total = db.Subscriptions.Take(takecount ?? 0).Count();
                    w.White.Line($"Creating {total} Subscriptions");
                    foreach (var item in db.Subscriptions.Take(takecount ?? 0))
                    {
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Subscriptions ON");
                        var i = context.Subscriptions.Find(item.Id);
                        if (i != null) continue;

                        count++;
                        var subscription = new Domain.Models.Subscription()
                        {
                            Id = item.Id,
                            Name = item.PublicationName?.Trim(),
                            Rate = item.SubscriptionRate?.Trim(),
                            RenewalDate = item.RenewalPermissionDate,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        subscription.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added subscription {subscription.Name}" });
                        w.Cyan.Line($"Creating {subscription.Name} ({count} of {total})");
                        context.Subscriptions.Add(subscription);
                    }
                    w.Gray.Line($"Saving Subscriptions");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Subscriptions OFF");
                    trans.Commit();
                    w.Green.Line($"Saved {count} Subscriptions");
                    w.White.Line(new string('-', 15));
                }
            }
        }

        public static void LoadWebsites(int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaWebsiteEGroups.Count();
            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    var total = db.MediaWebsiteEGroups.Take(takecount ?? 0).Count();
                    w.White.Line($"Creating {total} Websites");
                    foreach (var item in db.MediaWebsiteEGroups.Take(takecount ?? 0))
                    {
                        count++;
                        context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Websites ON");
                        var i = context.Websites.Find(item.Id);
                        if (i != null)
                        {
                            w.Red.Line($"Adding Website {count} of {total}: Website already exists");
                            continue;
                        }
                        
                        var website = new Website()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            //                            Type = (WebsiteType)item.WebsiteEGroupTypeId,
                            Url = item.URL,
                            Summary = item.Summary,
                            DateDiscovered = item.DateDiscovered,
                            DatePublished = item.DatePublished,
                            DateOffline = item.DateOffline,
                            WhoIs = item.WhoIsInfo,
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };

                        savedCount ++;
                        website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added website {website.Name}" });
                        w.Green.Line($"Adding {count} of {total} Website {website.Name}");
                        context.Websites.Add(website);
                    }
                    w.Gray.Line($"Saving Websites");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Websites OFF");
                    trans.Commit();
                    TimeSpan totalTime = DateTime.Now - startTime;
                    w.Green.Line($"Saved {savedCount} Websites in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                    w.White.Line(new string('-', 15));
                }
            }
        }

    }
}