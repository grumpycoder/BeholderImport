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
        public static void LoadOrganizations(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Organizations.Count();
            var entityName = "Organization";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Organizations ON");
                    w.White.Line($"Creating {takecount} {entityName}s");
                    foreach (var item in db.Organizations.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Organizations.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }

                        var newItem = new Domain.Models.Organization()
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
                        newItem.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added {entityName} {newItem.Name}" });
                        context.Organizations.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Organizations OFF");
                    trans.Commit();
                }
            }
            var totalTime = DateTime.Now - startTime;
            w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            w.White.Line(new String('-', 15));
        }

        public static void LoadChapters(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Chapters.Count();
            var entityName = "Chapter";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Chapters ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.Chapters.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Chapters.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }
                        var newItem = new Domain.Models.Chapter()
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
                        newItem.LogEntries.Add(new ChapterLogEntry() { Note = $"Added {entityName} {newItem.Name}" });
                        context.Chapters.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Chapters OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadPeople(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.BeholderPersons.Count();
            var entityName = "Person";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Persons ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.BeholderPersons.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0).Include("CommonPerson"))
                    {
                        count++;
                        var i = context.Persons.Find(item.CommonPersonId);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.FullName} already exists");
                            continue;
                        }

                        Gender gender;
                        Enum.TryParse(item.CommonPerson.GenderId.ToString(), out gender);
                        MaritialStatus maritialStatus;
                        Enum.TryParse(item.CommonPerson.MaritialStatusId.ToString(), out maritialStatus);
                        var newItem = new Person()
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
                        newItem.LogEntries.Add(new PersonLogEntry() { Note = $"Added {entityName} {newItem.ReverseFullName}" });
                        context.Persons.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.FullName}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Persons OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadAudioVideo(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaAudioVideos.Count();
            var entityName = "AudioVideo";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AudioVideos ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.MediaAudioVideos.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.AudioVideos.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Title} already exists");
                            continue;
                        }

                        var newItem = new AudioVideo()
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
                        newItem.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added {entityName} {newItem.Title}" });
                        context.AudioVideos.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Title}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT AudioVideos OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadCorrespondence(int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaCorrespondences.Count();
            var entityName = "Correspondence";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Correspondences ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.MediaCorrespondences.Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Correspondences.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }

                        var newItem = new Correspondence()
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
                        newItem.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added {entityName} {newItem.Name}" });
                        context.Correspondences.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Correspondences OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }

        }

        public static void LoadEvents(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Events.Count();
            var entityName = "Event";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Events ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.Events.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Events.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }

                        var newItem = new Domain.Models.Event()
                        {
                            Id = item.Id,
                            Name = item.EventName?.Trim(),
                            Summary = item.Summary?.Trim(),
                            SecurityLevel =
                                item.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            //                            DocumentationType = (DocumentationType)item.EventDocumentationTypeId,
                            //                            DocumentationType = Helpers.ConvertEventDocType(item.EventDocumentationTypeId),
                            //todo: EventType
                            //                        EventType = 
                            Movement = Helpers.ConvertMovementId(item.MovementClassId),
                            EventDate = item.EventDate,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        newItem.LogEntries.Add(new EventLogEntry() { Note = $"Added {entityName} {newItem.Name}" });
                        context.Events.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Events OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadImages(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaImages.Count();
            var entityName = "Image";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MediaImages ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.MediaImages.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.MediaImages.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Title} already exists");
                            continue;
                        }

                        var newItem = new Domain.Models.MediaImage()
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
                        newItem.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added {entityName} {newItem.Title}" });
                        context.MediaImages.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Title}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MediaImages OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadPublications(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaPublisheds.Count();
            var entityName = "Publication";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Publications ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.MediaPublisheds.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Publications.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }

                        var newItem = new Publication()
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
                        newItem.LogEntries.Add(new PublicationLogEntry() { Note = $"Added {entityName} {newItem.Name}" });
                        context.Publications.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Publications OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadSubscriptions(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.Subscriptions.Count();
            var entityName = "Subscription";

            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Subscriptions ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.Subscriptions.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Subscriptions.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }

                        var newItem = new Domain.Models.Subscription()
                        {
                            Id = item.Id,
                            Name = item.PublicationName?.Trim(),
                            Rate = item.SubscriptionRate?.Trim(),
                            RenewalDate = item.RenewalPermissionDate,
                            DateCreated = item.DateCreated,
                            DateUpdated = item.DateModified
                        };
                        newItem.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added {entityName} {newItem.Name}" });
                        context.Subscriptions.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Subscriptions OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        public static void LoadWebsites(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaWebsiteEGroups.Count();
            var entityName = "Website";


            using (var context = new AppContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Websites ON");
                    w.White.Line($"Creating {takecount} {entityName}s");

                    foreach (var item in db.MediaWebsiteEGroups.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                    {
                        count++;
                        var i = context.Websites.Find(item.Id);
                        if (i != null)
                        {
                            w.Yellow.Line($"Adding {entityName} {count} of {takecount}: {entityName} {i.Name} already exists");
                            continue;
                        }

                        var newItem = new Website()
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

                        newItem.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added website {newItem.Name}" });
                        context.Websites.Add(newItem);
                        w.Green.Line($"Adding {count} of {takecount} {entityName}: {newItem.Name}");
                        savedCount++;
                    }
                    w.Gray.Line($"Saving {entityName}s...");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Websites OFF");
                    trans.Commit();
                }
                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

    }
}