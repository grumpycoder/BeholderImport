using System;
using System.Linq;
using Domain;
using Domain.Models;
using splc.data;
using splc.domain.Models;
using PrimaryStatus = Domain.Models.Enums.PrimaryStatus;

namespace BeholderImport
{
    public partial class EntityService
    {
        public static void LoadEventRelationships()
        {
            //EventImages();
            //EventAudioVideos();
            //EventCorrespondences();
            //EventPublications();
            //EventComments();
            //EventAddresses();
        }

        private static void EventImages(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.EventMediaImageRels.Count();
            var entityName = "Event-Image";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.EventMediaImageRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.MediaImages.Find(item.MediaImageId);
                    var @event = context.Events.Find(item.EventId);
                    if (e == null || @event == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (@event.MediaImages.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {@event.Name}-{e.Title} already exists");
                        continue;
                    }

                    @event.MediaImages.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {@event.Name}-{e.Title}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void EventAudioVideos(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.EventMediaAudioVideoRels.Count();
            var entityName = "Event-AudioVideo";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.EventMediaAudioVideoRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var @event = context.Events.Find(item.EventId);
                    if (e == null || @event == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (@event.AudioVideos.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {@event.Name}-{e.Title} already exists");
                        continue;
                    }
                    @event.AudioVideos.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {@event.Name}-{e.Title}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void EventCorrespondences(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaCorrespondenceEventRels.Count();
            var entityName = "Event-Correspondence";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaCorrespondenceEventRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var @event = context.Events.Find(item.EventId);
                    if (e == null || @event == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (@event.Correspondences.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {@event.Name}-{e.Name} already exists");
                        continue;
                    }
                    @event.Correspondences.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Correspondence {e.Name}" });
                    e.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {@event.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void EventPublications(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaPublishedEventRels.Count();
            var entityName = "Event-Publication";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedEventRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var @event = context.Events.Find(item.EventId);
                    if (e == null || @event == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (@event.Publications.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {@event.Name}-{e.Name} already exists");
                        continue;
                    }
                    @event.Publications.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {@event.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }

        }

        private static void EventComments(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.EventComments.Count();
            var entityName = "Event-Comment";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.EventComments.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var comment = item.Comment.Length > 15 ? item.Comment?.Substring(0, 15) : item.Comment;
                    var @event = context.Chapters.Find(item.EventId);
                    if (@event == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    var log = @event.LogEntries.FirstOrDefault(x => x.Note == item.Comment?.Trim());
                    if (log == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {@event.Name}-{comment} already exists");
                        continue;
                    }
                    @event.LogEntries.Add(new ChapterLogEntry() { Note = item.Comment });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {@event.Name}-{comment}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void EventAddresses(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.AddressEventRels.Count();
            var entityName = "Event-Address";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.AddressEventRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var @event = context.Events.Find(item.EventId);
                    if (@event == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    var address = @event.EventAddresses.FirstOrDefault(
                        x => x.Street == item.Address.Address1?.Trim() &&
                             x.City == item.Address.City?.Trim() &&
                             x.StateId == item.Address.StateId &&
                             x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (address == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {@event.Name}-{item.Address.Address1} already exists");
                        continue;
                    }
                    @event.EventAddresses.Add(new EventAddress()
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

                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Address {item.Address.Address1}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {@event.Name}-{item.Address.Address1}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }
    }
}