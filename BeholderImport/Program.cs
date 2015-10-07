using System;

namespace BeholderImport
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;

            //EntityService.LoadOrganizations();
            //EntityService.LoadChapters();
            //EntityService.LoadPeople();
            //EntityService.LoadAudioVideo();
            //EntityService.LoadCorrespondence();
            //EntityService.LoadEvents();
            //EntityService.LoadImages();
            //EntityService.LoadPublications();
            //EntityService.LoadSubscriptions();
            //EntityService.LoadWebsites();

            //EntityService.LoadOrganizationRelationships();
            EntityService.LoadChapterRelationships();
            //EntityService.LoadPersonRelationships();
            //EntityService.LoadEventRelationships();
            //EntityService.LoadWebsiteRelationships();
            //EntityService.LoadPublicationRelationships();

            var ts = DateTime.Now - start;
            Console.WriteLine($"Finished in {ts.Hours}:{ts.Minutes}:{ts.Seconds}");
            Console.ReadLine();
        }

    }
}
