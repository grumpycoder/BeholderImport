using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            //PersonEvents(0, 100);
            //PersonWebsites(0, 100);
            //PersonImages(0, 500);
            //PersonAudioVideos(0, 100);
            PersonCorrespondences(500, 0);
            //PersonPublications(0, 500);
            //PersonAliases(0, 10);
            //PersonOnlineAliases(0, 10);
            //PersonComments(0, 500);
            //PersonAddresses(0, 50);
        }

        private static void PersonEvents(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonEventRels.Count();
            var entityName = "Person-Event";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonEventRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Events.Find(item.EventId);
                    var person = context.Persons.Include("Events").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    //todo: verify query
                    if (person.Events.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{e.Name} already exists");
                        continue;
                    }
                    person.Events.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Event {e.Name}" });
                    e.LogEntries.Add(new EventLogEntry() { Note = $"Added Chapter {person.ReverseFullName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{e.Name}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonWebsites(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonMediaWebsiteEGroupRels.Count();
            var entityName = "Person-Website";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Websites.Find(item.MediaWebsiteEGroupId);
                    var person = context.Persons.Include("Websites").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (person.Websites.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{e.Name} already exists");
                        continue;
                    }
                    person.Websites.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added website {e.Name}" });
                    e.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Person {person.FullName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{e.Name}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonImages(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonMediaImageRels.Count();
            var entityName = "Person-Image";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaImageRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.MediaImages.Find(item.MediaImageId);
                    //todo: verify query personid is right one
                    var person = context.Persons.Include("MediaImages").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (person.MediaImages.Any(x => x.Id == item.MediaImageId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{e.Title} already exists");
                        continue;
                    }
                    person.MediaImages.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Image {e.Title}" });
                    e.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added Chapter {person.FullName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{e.Title}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonAudioVideos(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonMediaAudioVideoRels.Count();
            var entityName = "Person-AudioVideo";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaAudioVideoRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.AudioVideos.Find(item.MediaAudioVideoId);
                    var person = context.Persons.Include("AudioVideos").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (person.AudioVideos.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{e.Title} already exists");
                        continue;
                    }
                    person.AudioVideos.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Audio Video {e.Title}" });
                    e.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added Chapter {person.FullName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{e.Title}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonCorrespondences(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonMediaCorrespondenceRels.Count();
            var entityName = "Person-Correspondence";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Correspondences.Find(item.MediaCorrespondenceId);
                    //todo: change to correspondences
                    var person = context.Persons.Include("Correspondence").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (person.Correspondence.Any(x => x.Id == item.MediaCorrespondenceId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{e.Name} already exists");
                        continue;
                    }
                    person.Correspondence.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Correspondence {e.Name}" });
                    e.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Person {person.FullName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{e.Name}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonPublications(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonMediaPublishedRels.Count();
            var entityName = "Person-Publication";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonMediaPublishedRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var person = context.Persons.Include("Publications").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (e == null || person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (person.Publications.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{e.Name} already exists");
                        continue;
                    }
                    person.Publications.Add(e);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Person {person.FullName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{e.Name}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonAliases(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.AliasPersonRels.Count();
            var entityName = "Person-Alias";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.AliasPersonRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var person = context.Persons.Include("PersonAliases").FirstOrDefault(x => x.Id == item.PersonId);
                    if (person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    //todo: verify query
                    if (person.PersonAliases.Any(x => x.Name?.Trim() == item.Alias.AliasName?.Trim() && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{item.Alias.AliasName} already exists");
                        continue;
                    }
                    person.PersonAliases.Add(new PersonAlias()
                    {
                        Name = item.Alias.AliasName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Alias {item.Alias.AliasName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{item.Alias.AliasName}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonOnlineAliases(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonScreenNames.Count();
            var entityName = "Person-OnlineAlias";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonScreenNames.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var person = context.Persons.Include("OnlineAlias").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (person == null)
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{item.ScreenName} already exists");
                        continue;
                    }
                    //todo: change to onlinealiases
                    if (person.OnlineAlias.Any(x => x.ScreenName == item.ScreenName?.Trim() && x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{item.ScreenName} already exists");
                        continue;
                    }
                    person.OnlineAlias.Add(new OnlineAlias()
                    {
                        ScreenName = item.ScreenName,
                        PrimaryStatus = (PrimaryStatus)item.PrimaryStatusId,
                        DateCreated = item.DateCreated,
                        DateUpdated = item.DateModified
                    });
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Online Alias {item.ScreenName}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{item.ScreenName}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void PersonComments(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.PersonComments.Count();
            var entityName = "Person-Comment";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.PersonComments.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var comment = item.Comment.Length > 15 ? item.Comment?.Substring(0, 15) : item.Comment;
                    var person = context.Persons.Include("LogEntries").FirstOrDefault(x => x.Id == item.BeholderPerson.CommonPersonId);
                    if (person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (person.LogEntries.Any(x => x.Note == item.Comment?.Trim()))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{comment} already exists");
                        continue;
                    }
                    person.LogEntries.Add(new PersonLogEntry() { Note = item.Comment });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{comment}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

        private static void PersonAddresses(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.AddressPersonRels.Count();
            var entityName = "Person-Address";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.AddressPersonRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var person = context.Persons.Include("PersonAddresses").FirstOrDefault(x => x.Id == item.CommonPerson.Id);
                    if (person == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    //todo: verify query
                    if (person.PersonAddresses.Any(
                        x => x.Street == item.Address.Address1?.Trim() &&
                             x.City == item.Address.City?.Trim() &&
                             x.StateId == item.Address.StateId &&
                             x.PrimaryStatus == (PrimaryStatus)item.PrimaryStatusId))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {person.ReverseFullName}-{item.Address.Address1} already exists");
                        continue;
                    }
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
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {person.ReverseFullName}-{item.Address.Address1}");
                    savedCount++;
                    context.SaveChanges();
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
            }
        }

    }
}