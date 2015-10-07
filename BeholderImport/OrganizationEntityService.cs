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

        public static void LoadOrganizationRelationships()
        {
            //OrganizationChapters();
            //OrganizationPeople();
            //OrganizationEvents();
            //OrganizationWebsites();
            //OrganizationImages();
            //OrganizationAudioVideo();
            //OrganizationCorrespondence();
            //OrganizationSubscriptions();
            //OrganizationPublications();
            //OrganizationAliases();
            //OrganizationComments();
            //OrganizationActivities();
        }

        private static void OrganizationChapters(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.ChapterOrganizationRels.Count();
            var entityName = "Chapter-Organziation";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterOrganizationRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var chapter = context.Chapters.Find(item.ChapterId);
                    var org = context.Organizations.Find(item.OrganizationId);
                    if (chapter == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (chapter.Organization != null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {chapter.Name}-{org.Name} already exists");
                        continue;
                    }
                    chapter.Organization = org;
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {chapter.Name}-{org.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationPeople(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationPersonRels.Count();
            var entityName = "Organziation-Person";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationPersonRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0).Include(x => x.BeholderPerson).OrderBy(x => x.Id))
                {
                    count++;
                    var person = context.Persons.Include(x => x.Organizations).FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    var org = context.Organizations.Find(item.OrganizationId);
                    if (person == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }

                    if (person.Organizations.Any(x => x.Id == org.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{person.FullName} already exists");
                        continue;
                    }
                    org.Persons.Add(person);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Person {person.ReverseFullName}" });
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{person.ReverseFullName}");
                    savedCount++;

                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationEvents(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationEventRels.Count();
            var entityName = "Organziation-Event";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationEventRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var @event = context.Events.Find(item.EventId);
                    var org = context.Organizations.Include(x => x.Events).First(x => x.Id == item.OrganizationId);
                    if (@event == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.Events.Any(x => x.Id == @event.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{@event.Name} already exists");
                        continue;
                    }
                    org.Events.Add(@event);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Event {@event.Name}" });
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{@event.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationWebsites(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationMediaWebsiteEGroupRels.Count();
            var entityName = "Organziation-Website";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    var org = context.Organizations.Include(x => x.Websites).FirstOrDefault(x => x.Id == item.OrganizationId);
                    if (website == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.Websites.Where(x => x.Id == website.Id).Any())
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{website.Name} already exists");
                        continue;
                    }
                    org.Websites.Add(website);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Website {website.Name}" });
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{website.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationImages(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationMediaImageRels.Count();
            var entityName = "Organziation-Image";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaImageRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.MediaImages.Find(item.MediaImageId);
                    var org = context.Organizations.Include(x => x.MediaImages).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.MediaImages.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{e.Title} already exists");
                        continue;
                    }
                    org.MediaImages.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{e.Title}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationAudioVideo(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationMediaAudioVideoRels.Count();
            var entityName = "Organziation-AudioVideo";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaAudioVideoRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var org = context.Organizations.Include(x => x.AudioVideos).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.AudioVideos.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{e.Title} already exists");
                        continue;
                    }
                    org.AudioVideos.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{e.Title}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationCorrespondence(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationMediaCorrespondenceRels.Count();
            var entityName = "Organziation-Correspondence";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var org = context.Organizations.Include(x => x.Correspondence).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.Correspondence.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{e.Name} already exists");
                        continue;
                    }
                    org.Correspondence.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Correspondence {e.Name}" });
                    e.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationSubscriptions(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationSubscriptionRels.Count();
            var entityName = "Organziation-Subscription";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationSubscriptionRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Subscriptions.Find(item.SubscriptionId);
                    var org = context.Organizations.Include(x => x.Subscriptions).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.Subscriptions.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{e.Name} already exists");
                        continue;
                    }
                    org.Subscriptions.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Subscription {e.Name}" });
                    e.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationPublications(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationMediaPublishedRels.Count();
            var entityName = "Organziation-Publication";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaPublishedRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var org = context.Organizations.Include(o => o.Publications).FirstOrDefault(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.Publications.Any(x => x.Id == item.MediaPublishedId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{e.Name} already exists");
                        continue;
                    }
                    org.Publications.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationAliases(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.AliasOrganizationRels.Count();
            var entityName = "Organziation-Alias";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.AliasOrganizationRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var org = context.Organizations.Find(item.OrganizationId);
                    if (org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.OrganizationAliases.Any(
                        x => x.Name == item.Alias.AliasName && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{item.Alias.AliasName} already exists");
                        continue;
                    };
                    org.OrganizationAliases.Add(new OrganizationAlias()
                    {
                        Name = item.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Alias {item.Alias.AliasName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{item.Alias.AliasName}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationComments(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationComments.Count();
            var entityName = "Organziation-Comment";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationComments.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var comment = item.Comment.Length > 15 ? item.Comment?.Substring(0, 15) : item.Comment;
                    var org = context.Organizations.Find(item.OrganizationId);
                    if (org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (org.LogEntries.Any(x => x.Note == item.Comment?.Trim()))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{comment} already exists");
                        continue;
                    }
                    org.LogEntries.Add(new OrganizationLogEntry()
                    {
                        Note = item.Comment,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{comment}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void OrganizationActivities(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.OrganizationStatusHistories.Count();
            var entityName = "Organziation-Activity";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationStatusHistories.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var org = context.Organizations.Find(item.OrganizationId);

                    if (org == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }

                    if (org.OrganizationActivity.Any(x => x.ActiveYear == item.ActiveYear))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {org.Name}-{item.ActiveYear} already exists");
                        continue;
                    }

                    org.OrganizationActivity.Add(new OrganizationActivity()
                    {
                        ActiveYear = item.ActiveYear,
                    });
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Activity Year {item.ActiveYear}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {org.Name}-{item.ActiveYear}");
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