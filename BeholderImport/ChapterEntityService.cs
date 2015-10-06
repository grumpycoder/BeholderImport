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
            //            ChapterPeople();
            //            ChapterWebsites();
            //            ChapterCorrespondence();
            //            ChapterEvents();
            //            ChapterPublications();
            //            ChapterSubscriptions();
            //            ChapterAudioVideo();
            //            ChapterImages();
            //            ChapterAddresses();
            //            ChapterAliases();
            //            ChapterActivities();
            //            ChapterComments();
        }

        private static void ChapterComments()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var total = db.ChapterComments.OrderBy(x => x.Id).Skip(1000).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Chapter Comments to log entries");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterComments.OrderBy(x => x.Id).Skip(1000).Take(1000))
                {
                    var chapter = context.Chapters.Find(item.ChapterId);

                    if (chapter == null) continue;

                    var log = chapter.LogEntries.Any(
                        x => x.Note == item.Comment?.Trim());

                    if (log == null) continue;
                    count++;
                    chapter.LogEntries.Add(new ChapterLogEntry()
                    {
                        Note = item.Comment,
                    });

                    w.Green.Line($"Adding {count} of {total} Comment LogEntry {item.Comment?.Substring(0, 15)}... to {chapter.Name}");
                }
                w.Gray.Line($"Saving Comments");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Comments");
            }
        }

        private static void ChapterActivities()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var total = db.ChapterStatusHistories.OrderBy(x => x.Id).Skip(1000).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Chapter Activity");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterStatusHistories.OrderBy(x => x.Id).Skip(1000).Take(1000))
                {
                    var chapter = context.Chapters.Find(item.ChapterId);

                    if (chapter == null) continue;

                    var activity = chapter.ChapterActivity.Any(
                        x => x.ActiveYear == item.ActiveYear);

                    if (activity == null) continue;
                    count++;

                    chapter.ChapterActivity.Add(new ChapterActivity()
                    {
                        ActiveYear = item.ActiveYear,
                    });

                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Activity Year {item.ActiveYear}" });
                    w.Green.Line($"Adding {count} of {total} Activity {item.ActiveYear} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Activity");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Activities");
            }
        }

        private static void ChapterPeople()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterPersonRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Person relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterPersonRels.Include("BeholderPerson"))
                {
                    var person = context.Persons.Find(item.BeholderPerson.CommonPersonId);
                    var chapter =
                        context.Chapters.Include(x => x.Persons).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (person == null || chapter == null) continue;
                    if (chapter.Persons.Any(x => x.Id == person.Id)) continue;
                    count++;

                    chapter.Persons.Add(person);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {person.FullName} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterWebsites()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterMediaWebsiteEGroupRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Website relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaWebsiteEGroupRels)
                {
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    var chapter =
                        context.Chapters.Include(x => x.Websites).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (website == null || chapter == null) continue;
                    if (chapter.Websites.Any(x => x.Id == website.Id)) continue;
                    count++;
                    chapter.Websites.Add(website);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added website {website.Name}" });
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {website.Name} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterCorrespondence()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterMediaCorrespondenceRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Correspondence relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaCorrespondenceRels)
                {
                    var corr = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var chapter =
                        context.Chapters.Include(x => x.Correspondence).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (corr == null || chapter == null) continue;
                    if (chapter.Correspondence.Any(x => x.Id == corr.Id)) continue;
                    count++;
                    chapter.Correspondence.Add(corr);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Correspondence {corr.Name}" });
                    corr.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {corr.Name} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterEvents()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterEventRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Event relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterEventRels)
                {
                    var @event = context.Events.Find(item.EventId);
                    var chapter =
                        context.Chapters.Include(x => x.Events).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (@event == null || chapter == null) continue;
                    if (chapter.Events.Any(x => x.Id == @event.Id)) continue;
                    count++;
                    chapter.Events.Add(@event);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Event {@event.Name}" });
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {@event.Name} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterPublications()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterMediaPublishedRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Publications relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaPublishedRels)
                {
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var chapter =
                        context.Chapters.Include(x => x.Publications).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null) continue;
                    if (chapter.Publications.Any(x => x.Id == e.Id)) continue;
                    count++;
                    chapter.Publications.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Name} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }

        }

        private static void ChapterSubscriptions()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterSubscriptionRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Subscriptions relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterSubscriptionRels)
                {
                    var e = context.Subscriptions.Find(item.SubscriptionId);
                    var chapter =
                        context.Chapters.Include(x => x.Subscriptions).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null) continue;
                    if (chapter.Subscriptions.Any(x => x.Id == e.Id)) continue;
                    count++;
                    chapter.Subscriptions.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Subscription {e.Name}" });
                    e.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Name} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterAudioVideo()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterMediaAudioVideoRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Audio Video relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaAudioVideoRels)
                {
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var chapter =
                        context.Chapters.Include(x => x.AudioVideos).FirstOrDefault(x => x.Id == item.ChapterId);
                    if (e == null || chapter == null) continue;
                    if (chapter.AudioVideos.Any(x => x.Id == e.Id)) continue;
                    count++;
                    chapter.AudioVideos.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Title} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterImages()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.ChapterMediaImageRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Image relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterMediaImageRels)
                {
                    var e = context.MediaImages.Find(item.MediaImageId);
                    var chapter =
                        context.Chapters.Include(x => x.MediaImages).FirstOrDefault(x => x.Id == item.ChapterId);

                    if (e == null || chapter == null) continue;
                    if (chapter.MediaImages.Any(x => x.Id == e.Id)) continue;
                    count++;
                    chapter.MediaImages.Add(e);
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Chapter {chapter.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Title} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterAddresses()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.AddressChapterRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Address relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.AddressChapterRels)
                {
                    var chapter = context.Chapters.Find(item.ChapterId);

                    if (chapter == null) continue;

                    var address = chapter.ChapterAddresses.Any(
                        x => x.Street == item.Address.Address1?.Trim() &&
                             x.City == item.Address.City?.Trim() &&
                             x.StateId == item.Address.StateId &&
                             x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (address == null) continue;
                    count ++; 

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
                    w.Green.Line($"Adding {count} of {total} {item.Address.Address1} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void ChapterAliases()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var total = db.AliasChapterRels.Count();
            w.Yellow.Line($"Adding {total} Chapter-Alias relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.AliasChapterRels)
                {
                    var chapter = context.Chapters.Find(item.ChapterId);

                    if (chapter == null) continue;

                    var alias = chapter.ChapterAliases.Any(
                        x => x.Name == item.Alias.AliasName && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (alias == null) continue;

                    chapter.ChapterAliases.Add(new ChapterAlias()
                    {
                        Name = item.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });

                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added Alias {item.Alias.AliasName}" });
                    w.Green.Line($"Adding {count} of {total} {item.Alias.AliasName} to {chapter.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }
    }
}