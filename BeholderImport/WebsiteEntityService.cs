using System;
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
            WebsiteCorrespondences();
            WebsitePublications();
        }

        private static void WebsiteCorrespondences(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaCorrespondenceMediaWebsiteEGroupRels.Count();
            var entityName = "Website-Correspondence";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaCorrespondenceMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Correspondences.Find(item.MediaCorrespondenceId);
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    if (e == null || website == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (website.Correspondences.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {website.Name}-{e.Name} already exists");
                        continue;
                    }
                    website.Correspondences.Add(e);
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Correspondence {e.Name}" });
                    e.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added Website {website.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {website.Name}-{e.Name}");
                    savedCount++;
                }
                w.Gray.Line($"Saving {entityName}s...");
                context.SaveChanges();

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }
        }

        private static void WebsitePublications(int? skip = 0, int? takecount = 0)
        {
            var startTime = DateTime.Now;
            var w = FluentConsole.Instance;
            var db = new ACDBContext();
            var count = 0;
            var savedCount = 0;
            if (takecount == 0) takecount = db.MediaPublishedMediaWebsiteEGroupRels.Count();
            var entityName = "Website-Publication";

            w.White.Line($"Creating {takecount} {entityName}s");
            using (var context = new AppContext())
            {
                foreach (var item in db.MediaPublishedMediaWebsiteEGroupRels.OrderBy(x => x.Id).Skip(skip ?? 0).Take(takecount ?? 0))
                {
                    count++;
                    var e = context.Publications.Find(item.MediaPublishedId);
                    var website = context.Websites.Find(item.MediaWebsiteEGroupId);
                    if (e == null || website == null)
                    {
                        w.Red.Line($"Error {entityName} {count} of {takecount}: {entityName} not found");
                        continue;
                    }
                    if (website.Publications.Any(x => x.Id == e.Id))
                    {
                        w.Yellow.Line($"Warning {entityName} {count} of {takecount}: {entityName} {website.Name}-{e.Name} already exists");
                        continue;
                    }
                    website.Publications.Add(e);
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added Publication {e.Name}" });
                    e.LogEntries.Add(new PublicationLogEntry() { Note = $"Added Website {website.Name}" });
                    w.Green.Line($"Adding {count} of {takecount} {entityName}: {website.Name}-{e.Name}");
                    savedCount++;
                }

                var totalTime = DateTime.Now - startTime;
                w.Green.Line($"Saved {savedCount} {entityName}s in {totalTime.Hours}:{totalTime.Minutes}:{totalTime.Seconds} ");
                w.White.Line(new String('-', 15));
            }

        }
    }
}