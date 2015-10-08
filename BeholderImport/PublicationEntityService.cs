using System;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.Models;
using splc.data;

namespace BeholderImport
{
    public partial class EntityService
    {
        public static void LoadPublicationRelationships()
        {
            PublicationSubscriptions();
            PublicationCorrespondences();

        }

        private static void PublicationSubscriptions(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaPublishedSubscriptionRels.Count();
            var entityName = "Publication-Subscription";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedSubscriptionRels.OrderBy(x => x.Id).Skip(0).Take(1000).OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Subscriptions.Find(item.SubscriptionId);
                    var pub = context.Publications.Include(x => x.Subscriptions).FirstOrDefault(x => x.Id == item.MediaPublishedId);
                    if (e == null || pub == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (pub.Subscriptions.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {pub.Name}-{e.Name} already exists");
                        continue;
                    }
                    pub.Subscriptions.Add(e);
                    pub.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Subscription {e.Name}" });
                    e.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added Publication {pub.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {pub.Name}-{e.Name}");
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

        private static void PublicationCorrespondences(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaPublishedMediaCorrespondenceRels.Count();
            var entityName = "Publication-Correspondence";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var pub =
                        context.Publications.Include(x => x.Correspondence).FirstOrDefault(x => x.Id == item.MediaPublishedId);
                    if (e == null || pub == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    //todo: change to correspondences
                    if (pub.Correspondence.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {pub.Name}-{e.Name} already exists");
                        continue;
                    }
                    pub.Correspondence.Add(e);
                    pub.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Correspondence {e.Name}" });
                    e.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Publication {pub.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {pub.Name}-{e.Name}");
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

    }
}