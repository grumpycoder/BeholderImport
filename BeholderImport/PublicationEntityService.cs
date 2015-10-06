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
            //            PublicationCorrespondences();
            //            PublicationSubscriptions();
        }

        private static void PublicationCorrespondences()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.MediaPublishedMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Publication-Correspondence relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedMediaCorrespondenceRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var corr = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var pub =
                        context.Publications.Include(x => x.Correspondence).FirstOrDefault(x => x.Id == item.MediaPublishedId);
                    if (corr == null || pub == null) continue;
                    if (pub.Correspondence.Any(x => x.Id == corr.Id)) continue;
                    count++;
                    pub.Correspondence.Add(corr);
                    pub.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Correspondence {corr.Name}" });
                    corr.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Publication {pub.Name}" });
                    w.Green.Line($"Adding {count} of {total} {corr.Name} to {pub.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void PublicationSubscriptions()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.MediaPublishedSubscriptionRels.OrderBy(x => x.Id).Skip(0).Take(1000).Count();
            w.Yellow.Line($"Adding {total} Publication-Subscriptions relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedSubscriptionRels.OrderBy(x => x.Id).Skip(0).Take(1000))
                {
                    var e = context.Subscriptions.Find(item.SubscriptionId);
                    var pub =
                        context.Publications.Include(x => x.Subscriptions).FirstOrDefault(x => x.Id == item.MediaPublishedId);
                    if (e == null || pub == null) continue;
                    if (pub.Subscriptions.Any(x => x.Id == e.Id)) continue;
                    count++;
                    pub.Subscriptions.Add(e);
                    pub.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Subscription {e.Name}" });
                    e.LogEntries.Add(new SubscriptionLogEntry() { Note = $"Added Publication {pub.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Name} to {pub.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

    }
}