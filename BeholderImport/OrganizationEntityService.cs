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
            OrganizationChapters();
            OrganizationPeople();
            OrganizationWebsites();
            OrganizationCorrespondence();
            OrganizationEvents();
            OrganizationPublications();
            OrganizationSubscriptions();
            OrganizationAudioVideo();
            OrganizationImages();
            OrganizationAliases();
            OrganizationComments();
            OrganizationActivities();
        }

        private static void OrganizationActivities()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationStatusHistories.OrderBy(x => x.Id).Count();
            w.Yellow.Line($"Adding {total} organization Activity");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationStatusHistories.OrderBy(x => x.Id))
                {
                    count++;
                    var organization = context.Organizations.Find(item.OrganizationId);

                    if (organization == null)
                    {
                        w.Red.Line($"Adding Organization-Activity {count} of {total}: Organization not found");
                        continue;
                    }

                    if (organization.OrganizationActivity.Any(
                        x => x.ActiveYear == item.ActiveYear))
                    {
                        w.Yellow.Line($"Adding Organization-Activity {count} of {total}: Activity already exists");
                        continue;
                    };
                    savedCount++;

                    organization.OrganizationActivity.Add(new OrganizationActivity()
                    {
                        ActiveYear = item.ActiveYear,
                    });

                    organization.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Activity Year {item.ActiveYear}" });
                    w.Green.Line($"Adding {count} of {total} Activity {item.ActiveYear} to {organization.Name}");
                }
                w.Gray.Line($"Saving Activity");
                context.SaveChanges();
                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Activities in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");

            }
        }

        private static void OrganizationComments()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationComments.OrderBy(x => x.Id).Count();
            w.Yellow.Line($"Adding {total} Organziation Comments to log entries");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationComments.OrderBy(x => x.Id))
                {
                    count++;
                    var organization = context.Organizations.Find(item.OrganizationId);

                    if (organization == null)
                    {
                        w.Red.Line($"Adding Organization-Comment {count} of {total}: Organization not found");
                        continue;
                    }

                    if (organization.LogEntries.Any(
                        x => x.Note == item.Comment?.Trim()))
                    {
                        w.Yellow.Line($"Adding Organization-Comment {count} of {total}: Comment already exists");
                        continue;
                    };

                    savedCount++;

                    organization.LogEntries.Add(new OrganizationLogEntry()
                    {
                        Note = item.Comment,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });

                    var comment = item.Comment.Length > 15 ? item.Comment?.Substring(0, 15) : item.Comment;
                    w.Green.Line($"Adding {count} of {total} Comment LogEntry {comment}... to {organization.Name}");
                }
                w.Gray.Line($"Saving Comments");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Comments in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationAliases()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.AliasOrganizationRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Alias relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.AliasOrganizationRels)
                {
                    count++;
                    var org = context.Organizations.Find(item.OrganizationId);

                    if (org == null)
                    {
                        w.Red.Line($"Adding Organization-Alias {count} of {total}: Organization not found");
                        continue;
                    }

                    if (org.OrganizationAliases.Any(
                        x => x.Name == item.Alias.AliasName && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId))
                    {
                        w.Yellow.Line($"Adding Organization-Alias {count} of {total}: {item.Alias.AliasName} to {org.Name} already exists");
                        continue;
                    };

                    savedCount++;

                    org.OrganizationAliases.Add(new OrganizationAlias()
                    {
                        Name = item.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });

                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Alias {item.Alias.AliasName}" });
                    w.Green.Line($"Adding {item.Alias.AliasName} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationImages()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationMediaImageRels.OrderBy(x => x.Id).Skip(10000).Take(2000).Count();
            w.Yellow.Line($"Adding {total} Organization-Image relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaImageRels.OrderBy(x => x.Id).Skip(10000).Take(2000))
                {
                    count++;
                    var e = context.MediaImages.Find(item.MediaImageId);
                    var org =
                        context.Organizations.Include(x => x.MediaImages).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Image {count} of {total}: Image or Organization not found");
                        continue;
                    }
                    if (org.MediaImages.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Adding Organization-Image {count} of {total}: {e.Title} to {org.Name} already exists");
                        continue;
                    }

                    savedCount++;
                    org.MediaImages.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding Organization-Image {count} of {total}: {e.Title} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationAudioVideo()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationMediaAudioVideoRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Audio Video relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaAudioVideoRels)
                {
                    count++;
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var org =
                        context.Organizations.Include(x => x.AudioVideos).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Audio Video {count} of {total}: Audio Video or Organization not found");
                        continue;
                    }
                    if (org.AudioVideos.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Adding Organization-Audio Video {count} of {total}: {e.Title} to {org.Name} already exists");
                        continue;
                    }

                    savedCount++;
                    org.AudioVideos.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {e.Title} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationSubscriptions()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationSubscriptionRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Subscriptions relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationSubscriptionRels)
                {
                    count++;
                    var e = context.Subscriptions.Find(item.SubscriptionId);
                    var org =
                        context.Organizations.Include(x => x.Subscriptions).First(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Subscriptions {count} of {total}: Subscriptions or Organization not found");
                        continue;
                    }
                    if (org.Subscriptions.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Adding Organization-Subscriptions {count} of {total}: {e.Name} to {org.Name} already exists");
                        continue;
                    }

                    savedCount++;
                    org.Subscriptions.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Subscription {e.Name}" });
                    e.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {e.Name} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationPublications()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0; var savedCount = 0;
            var total = db.OrganizationMediaPublishedRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Publications relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaPublishedRels)
                {
                    count++;
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var org = context.Organizations.Include(o => o.Publications).FirstOrDefault(x => x.Id == item.OrganizationId);
                    if (e == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Publications {count} of {total}: Publications or Organization not found");
                        continue;
                    }

                    if (org.Publications.Any(x => x.Id == item.MediaPublishedId))
                    {
                        w.Yellow.Line($"Adding Organization-Publications {count} of {total}: {e.Name} to {org.Name} already exists");
                        continue;
                    }
                    savedCount++;

                    org.Publications.Add(e);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding Organization-Publication {count} of {total}: {e.Name} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationEvents()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationEventRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Event relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationEventRels)
                {
                    count++;
                    var @event = context.Events.Find(item.EventId);
                    var org =
                        context.Organizations.Include(x => x.Events).First(x => x.Id == item.OrganizationId);
                    if (@event == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Publication {count} of {total}: Event or Organization not found");
                        continue;
                    }
                    if (org.Events.Any(x => x.Id == @event.Id))
                    {
                        w.Yellow.Line($"Adding Organization-Publication {count} of {total}: {@event.Name} to {org.Name} already exists");
                        continue;
                    }
                    savedCount++;
                    org.Events.Add(@event);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Event {@event.Name}" });
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {@event.Name} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationCorrespondence()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationMediaCorrespondenceRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Correspondence relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaCorrespondenceRels)
                {
                    count++;
                    var corr = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var org =
                        context.Organizations.Include(x => x.Correspondence).First(x => x.Id == item.OrganizationId);
                    if (corr == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Correspondence {count} of {total}: Correspondence or Organization not found");
                        continue;
                    }
                    if (org.Correspondence.Any(x => x.Id == corr.Id))
                    {
                        w.Yellow.Line($"Adding Organization-Correspondence {count} of {total}: {corr.Name} to {org.Name} already exists");
                        continue;
                    }

                    savedCount++;
                    org.Correspondence.Add(corr);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added Correspondence {corr.Name}" });
                    corr.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding {corr.Name} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationWebsites()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationMediaWebsiteEGroupRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Website relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationMediaWebsiteEGroupRels)
                {
                    count++;
                    var website = context.Websites.Find(item.Id);
                    var org = context.Organizations.Include(x => x.Websites).FirstOrDefault(x => x.Id == item.Id);
                    if (website == null || org == null)
                    {
                        w.Red.Line($"Skipping Organization-Website {count} or {total}: Did not find website or organization");
                        continue;
                    }
                    if (org.Websites.Any(x => x.Id == website.Id))
                    {
                        w.Yellow.Line($"Skipping Organization-Website {count} or {total}: {website.Name} to {org.Name} already exists");
                        continue;
                    }
                    savedCount++;

                    org.Websites.Add(website);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added website {website.Name}" });
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding Organization-Website {count} or {total}: {website.Name} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationPeople()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.OrganizationPersonRels.OrderBy(x => x.Id).Count();
            w.Yellow.Line($"Adding {total} Organization-Person relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.OrganizationPersonRels.Include(x => x.BeholderPerson).OrderBy(x => x.Id))
                {
                    count++;
                    var person = context.Persons.Include(x => x.Organizations).FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    var org = context.Organizations.Find(item.OrganizationId);
                    if (person == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Person {count} of {total}: Person or Organization not found");
                        continue;
                    }

                    if (person.Organizations.Any(x => x.Id == org.Id))
                    {
                        w.Yellow.Line($"Adding Organization-Person {count} of {total}: {person.FullName} to {org.Name} already exists");
                        continue;
                    }
                    savedCount++;

                    org.Persons.Add(person);
                    org.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Organization {org.Name}" });
                    w.Green.Line($"Adding Organization-Person {count} of {total}: {person.FullName} to {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void OrganizationChapters()
        {
            var startTime = DateTime.Now;
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var savedCount = 0;
            var total = db.ChapterOrganizationRels.Count();
            w.Yellow.Line($"Adding {total} Organization-Chapter relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.ChapterOrganizationRels)
                {
                    count++;
                    var chapter = context.Chapters.Find(item.ChapterId);
                    var org = context.Organizations.Find(item.OrganizationId);
                    if (chapter == null || org == null)
                    {
                        w.Red.Line($"Adding Organization-Chapter {count} of {total}: Chapter or Organization not found");
                        continue; 
                    }
                    if (chapter.Organization != null)
                    {
                        w.Yellow.Line($"Adding Organization-Chapter {count} of {total}: {chapter.Name} to {org.Name} already exists");
                        continue; 
                    }

                    savedCount++;
                    chapter.Organization = org;
                    w.Green.Line($"Adding Organization-Chapter {count} of {total}: {chapter.Name} - {org.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();

                TimeSpan totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} Relationships in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }
    }
}