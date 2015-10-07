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
        public static void LoadChapterRelationships()
        {
            //ChapterPeople();
            //ChapterEvents();
            //ChapterWebsites();
            ChapterImages();
            //ChapterAudioVideo();
            //ChapterCorrespondence();
            //ChapterSubscriptions();
            //ChapterPublications();
            //ChapterAliases();
            //ChapterComments();
            //ChapterActivities();
            //ChapterAddresses();
        }

        private static void ChapterPeople(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterPersonRels.Count();
            var entityName = "Chapter-Person";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterPersonRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0).Include("BeholderPerson"))
                {
                    count++;
                    var e = context.Persons.Find(item.BeholderPerson.CommonPersonId);
                    var chapter = context.Chapters.Include(x => x.Persons).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Persons.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.FullName} already exists");
                        continue;
                    }
                    chapter.Persons.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Person {e.ReverseFullName}" });
                    e.LogEntries.Add(new PersonLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.ReverseFullName}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterEvents(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterEventRels.Count();
            var entityName = "Chapter-Event";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterEventRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Events.Find(item.EventId);
                    var chapter = context.Chapters.Include(x => x.Events).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Events.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Name} already exists");
                        continue;
                    }
                    chapter.Events.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Event {e.Name}" });
                    e.LogEntries.Add(new EventLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterWebsites(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterMediaWebsiteEGroupRels.Count();
            var entityName = "Chapter-Website";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Websites.Find(item.MediaWebsiteEGroupId);
                    var chapter = context.Chapters.Include(x => x.Websites).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Websites.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Name} already exists");
                        continue;
                    }
                    chapter.Websites.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added website {e.Name}" });
                    e.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterImages(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterMediaImageRels.Count();
            var entityName = "Chapter-Image";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaImageRels.Where(x => x.Id >= 1 && x.Id < 4000).OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.MediaImages.Find(item.MediaImageId);
                    var chapter = context.Chapters.Include(x => x.MediaImages).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.MediaImages.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Title} already exists");
                        continue;
                    }
                    chapter.MediaImages.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Title}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterAudioVideo(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterMediaAudioVideoRels.Count();
            var entityName = "Chapter-AudioVideo";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaAudioVideoRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var chapter = context.Chapters.Include(x => x.AudioVideos).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.AudioVideos.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Title} already exists");
                        continue;
                    }
                    chapter.AudioVideos.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Title}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterCorrespondence(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterMediaCorrespondenceRels.Count();
            var entityName = "Chapter-Correspondence";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var chapter = context.Chapters.Include(x => x.Correspondence).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Correspondence.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Name} already exists");
                        continue;
                    }
                    chapter.Correspondence.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Correspondence {e.Name}" });
                    e.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterSubscriptions(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterSubscriptionRels.Count();
            var entityName = "Chapter-Subscription";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterSubscriptionRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Subscriptions.Find(item.SubscriptionId);
                    var chapter = context.Chapters.Include(x => x.Subscriptions).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Subscriptions.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Name} already exists");
                        continue;
                    }
                    chapter.Subscriptions.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Subscription {e.Name}" });
                    e.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterPublications(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterMediaPublishedRels.Count();
            var entityName = "Chapter-Publication";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaPublishedRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var chapter = context.Chapters.Include(x => x.Publications).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Publications.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Name} already exists");
                        continue;
                    }
                    chapter.Publications.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterAliases(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.AliasChapterRels.Count();
            var entityName = "Chapter-Alias";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.AliasChapterRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var chapter = context.Chapters.Find(item.ChapterId);

                    if (chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    //todo: verify query
                    var e = chapter.ChapterAliases.FirstOrDefault(x => x.Name == item.Alias.AliasName && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);
                    if (e == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Name} already exists");
                        continue;
                    }
                    chapter.ChapterAliases.Add(new ChapterAlias()
                    {
                        Name = item.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Alias {item.Alias.AliasName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterComments(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterComments.Count();
            var entityName = "Chapter-Comment";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterComments.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var comment = item.Comment.Length > 15 ? item.Comment?.Substring(0, 15) : item.Comment;
                    var chapter = context.Chapters.Find(item.ChapterId);
                    if (chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    var log = chapter.LogEntries.FirstOrDefault(x => x.Note == item.Comment?.Trim());
                    if (log == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{comment} already exists");
                        continue;
                    }
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = item.Comment });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{comment}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterActivities(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterStatusHistories.Count();
            var entityName = "Chapter-Activity";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterStatusHistories.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var chapter = context.Chapters.Find(item.ChapterId);
                    if (chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    var e = chapter.ChapterActivity.FirstOrDefault(x => x.ActiveYear == item.ActiveYear);
                    if (e == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.ActiveYear} already exists");
                        continue;
                    }
                    chapter.ChapterActivity.Add(new ChapterActivity() { ActiveYear = item.ActiveYear });
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Activity Year {item.ActiveYear}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.ActiveYear}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void ChapterAddresses(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.AddressChapterRels.Count();
            var entityName = "Chapter-Address";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.AddressChapterRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var chapter = context.Chapters.Find(item.ChapterId);
                    if (chapter == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    //todo: verify query
                    var e = chapter.ChapterAddresses.FirstOrDefault(
                        x => x.Street == item.Address.Address1?.Trim() &&
                             x.City == item.Address.City?.Trim() &&
                             x.StateId == item.Address.StateId &&
                             x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);
                    if (e == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{e.Street} already exists");
                        continue;
                    }
                    chapter.ChapterAddresses.Add(new ChapterAddress()
                    {
                        Street = item.Address.Address1?.Trim(),
                        Street2 = item.Address.Address2?.Trim(),
                        City = item.Address.City?.Trim(),
                        County = item.Address.County?.Trim(),
                        StateId = item.Address.StateId,
                        ZipCode = $"{item.Address.Zip5?.Trim()}-{item.Address.Zip4?.Trim()}",
                        Country = item.Address.Country?.Trim(),
                        Latitude = item.Address.Latitude,
                        Longitude = item.Address.Longitude,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Address {item.Address.Address1}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{e.Street}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

    }
}