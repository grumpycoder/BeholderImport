using System.Linq;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using splc.data;

namespace BeholderImport
{
    public partial class EntityService
    {
        public static void LoadEventRelationships()
        {
            //            EventAddresses();
            //            EventPublications();
            //            EventImages();
            //            EventAudioVideos();
            //            EventCorrespondences();
        }

        private static void EventCorrespondences()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.MediaCorrespondenceEventRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Event-Correspondence relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaCorrespondenceEventRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var corr = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var @event = context.Events.Find(item.EventId);
                    if (corr == null || @event == null) continue;

                    if (@event.Correspondences.Any(x => x.Id == corr.Id)) continue;
                    count++;
                    @event.Correspondences.Add(corr);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Correspondence {corr.Name}" });
                    corr.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {total} {corr.Name} to {@event.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void EventAudioVideos()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.EventMediaAudioVideoRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Event-Audio Video relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.EventMediaAudioVideoRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var @event = context.Events.Find(item.EventId);
                    if (e == null || @event == null) continue;
                    if (@event.AudioVideos.Any(x => x.Id == e.Id)) continue;
                    count++;
                    @event.AudioVideos.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Title} to {@event.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void EventImages()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.EventMediaImageRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Event-Image relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.EventMediaImageRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var e = context.MediaImages.Find(item.MediaImageId);
                    var @event =
                        context.Events.Find(item.EventId);

                    if (e == null || @event == null) continue;
                    if (@event.MediaImages.Any(x => x.Id == e.Id)) continue;
                    count++;
                    @event.MediaImages.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Title} to {@event.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void EventPublications()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.MediaPublishedEventRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Event-Publications relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedEventRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var @event = context.Events.Find(item.EventId);
                    if (e == null || @event == null) continue;

                    count++;
                    @event.Publications.Add(e);
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Event {@event.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Name} to {@event.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }

        }

        private static void EventAddresses()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.AddressEventRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Event-Address relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.AddressEventRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var @event = context.Events.Find(item.EventId);

                    if (@event == null) continue;

                    var address = @event.EventAddresses.Any(
                        x => x.Street == item.Address.Address1?.Trim() &&
                             x.City == item.Address.City?.Trim() &&
                             x.StateId == item.Address.StateId &&
                             x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (address == null) continue;
                    count++;

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
                    w.Green.Line($"Adding {count} of {total} {item.Address.Address1} to {@event.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }
    }
}