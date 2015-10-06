using System.Linq;
using Domain;
using Domain.Models;
using splc.data;

namespace BeholderImport
{
    public partial class EntityService
    {
        public static void LoadWebsiteRelationships()
        {
//            WebsitePublications();
//            WebsiteCorrespondences();
        }

        private static void WebsiteCorrespondences()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.MediaCorrespondenceMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Website-Correspondence relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaCorrespondenceMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var corr = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    if (corr == null || website == null) continue;

                    if (website.Correspondences.Any(x => x.Id == corr.Id)) continue;
                    count++;
                    website.Correspondences.Add(corr);
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Correspondence {corr.Name}" });
                    corr.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Website {website.Name}" });
                    w.Green.Line($"Adding {count} of {total} {corr.Name} to {website.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }
        }

        private static void WebsitePublications()
        {
            var db = new ACDBContext();
            var w = FluentConsole.Instance;
            var count = 0;
            var total = db.MediaPublishedMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(0).Take(500).Count();
            w.Yellow.Line($"Adding {total} Website-Publications relationships");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(0).Take(500))
                {
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    if (e == null || website == null) continue;

                    count++;
                    website.Publications.Add(e);
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Website {website.Name}" });
                    w.Green.Line($"Adding {count} of {total} {e.Name} to {website.Name}");
                }
                w.Gray.Line($"Saving Relationships");
                context.SaveChanges();
                w.Green.Line($"Saved {count} Relationships");
            }

        }
    }
}