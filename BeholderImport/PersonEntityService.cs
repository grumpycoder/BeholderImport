using System.Linq;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using splc.data;

namespace BeholderImport
{
    public partial class EntityService
    {
        public static void LoadPersonRelationships()
        {
            //            PersonAliases();
            //            PersonOnlineAliases();
            //            PersonEvents();
            //            PersonWebsites();
            //            PersonCorrespondences();
            //            PersonPublications();
            //            PersonAddresses();
            //            PersonImages();
            //            PersonMediaAudioVideos();
        }

        private static void PersonMediaAudioVideos()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.PersonMediaAudioVideoRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Person-Audio Video relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaAudioVideoRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var person =
                        context.Persons.FirstOrDefault(x => x.Id == item.PersonId);
                    if (e == null || person == null) continue;
                    if (person.AudioVideos.Any(x => x.Id == e.Id)) continue;
                    count++;
                    person.AudioVideos.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Chapter {person.FullName}" });
                    w.Green.Line($"Adding {count} of {total} {e.Title} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonImages()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.PersonMediaImageRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Person-Image relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaImageRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var e = context.MediaImages.Find(item.MediaImageId);
                    //todo: verify personid is right one
                    var person =
                        context.Persons.FirstOrDefault(x => x.Id == item.PersonId);

                    if (e == null || person == null) continue;
                    if (person.MediaImages.Any(x => x.Id == e.Id)) continue;
                    count++;
                    person.MediaImages.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Chapter {person.FullName}" });
                    w.Green.Line($"Adding {count} of {total} {e.Title} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonAddresses()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.AddressPersonRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Person-Address relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.AddressPersonRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var person = context.Persons.Find(item.CommonPerson.Id);

                    if (person == null) continue;

                    var address = person.PersonAddresses.Any(
                        x => x.Street == item.Address.Address1?.Trim() &&
                             x.City == item.Address.City?.Trim() &&
                             x.StateId == item.Address.StateId &&
                             x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (address == null) continue;
                    count++;

                    person.PersonAddresses.Add(new PersonAddress()
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

                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Address {item.Address.Address1}" });
                    w.Green.Line($"Adding {count} of {total} {item.Address.Address1} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonPublications()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.PersonMediaPublishedRels.OrderBy(x => x.Id).Skip(0).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Person-Publications relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaPublishedRels.OrderBy(x => x.Id).Skip(0).Take(1000))
                {
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var person =
                        context.Persons.FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null) continue;
                    if (person.Publications.Any(x => x.Id == e.Id)) continue;
                    count++;
                    person.Publications.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Person {person.FullName}" });
                    w.Green.Line($"Adding {count} of {total} {e.Name} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonCorrespondences()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.PersonMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(0).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Chapter-Correspondence relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(0).Take(1000))
                {
                    var corr = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var person =
                        context.Persons.FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (corr == null || person == null) continue;
                    if (person.Correspondence.Any(x => x.Id == corr.Id)) continue;
                    count++;
                    person.Correspondence.Add(corr);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Correspondence {corr.Name}" });
                    corr.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Person {person.FullName}" });
                    w.Green.Line($"Adding {count} of {total} {corr.Name} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonWebsites()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.PersonMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(0).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Person-Website relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(0).Take(1000))
                {
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    var person =
                        context.Persons.FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (website == null || person == null) continue;
                    if (person.Websites.Any(x => x.Id == website.Id)) continue;
                    count++;
                    person.Websites.Add(website);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added website {website.Name}" });
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Person {person.FullName}" });
                    w.Green.Line($"Adding {count} of {total} {website.Name} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonEvents()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.PersonEventRels.OrderBy(x => x.Id).Skip(0).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Person-Event relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonEventRels.OrderBy(x => x.Id).Skip(0).Take(1000))
                {
                    var @event = context.Events.Find(item.EventId);
                    var person = context.Persons.FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);

                    if (@event == null || person == null) continue;
                    if (person.Events.Any(x => x.Id == @event.Id)) continue;
                    count++;
                    person.Events.Add(@event);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Event {@event.Name}" });
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added Chapter {person.FullName}" });
                    w.Green.Line($"Adding {count} of {total} {@event.Name} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonOnlineAliases()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var total = db.PersonScreenNames.OrderBy(x => x.Id).Skip(0).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Person-Online relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonScreenNames.OrderBy(x => x.Id).Skip(0).Take(1000))
                {
                    var person = context.Persons.Find(item.BeholderPerson.CommonPersonId);

                    if (person == null) continue;

                    var alias = person.OnlineAlias.Any(
                        x => x.ScreenName == item.ScreenName && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (alias == null) continue;
                    count++;
                    person.OnlineAlias.Add(new OnlineAlias()
                    {
                        ScreenName = item.ScreenName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });

                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Online Alias {item.ScreenName}" });
                    w.Green.Line($"Adding {count} of {total} {item.ScreenName} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PersonAliases()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;

            var count = 0;
            var total = db.AliasPersonRels.OrderBy(x => x.Id).Skip(2000).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Person-Alias relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.AliasPersonRels.OrderBy(x => x.Id).Skip(2000).Take(1000))
                {
                    var person = context.Persons.Find(item.PersonId);

                    if (person == null) continue;

                    var alias = person.PersonAliases.Any(
                        x => x.Name == item.Alias.AliasName && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId);

                    if (alias == null) continue;
                    count++;
                    person.PersonAliases.Add(new PersonAlias()
                    {
                        Name = item.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });

                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Alias {item.Alias.AliasName}" });
                    w.Green.Line($"Adding {count} of {total} {item.Alias.AliasName} to {person.FullName}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }
    }
}