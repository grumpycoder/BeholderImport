using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using splc.data;
using splc.domain.Models;
using Gender = Domain.Models.Gender;
using MaritialStatus = Domain.Models.MaritialStatus;
using PrimaryStatus = Domain.Models.Enums.PrimaryStatus;

namespace BeholderImport
{
    internal static class PersonService
    {
        public static Person CreatePerson(BeholderPerson p)
        {
            Gender gender;
            Enum.TryParse(p.CommonPerson.GenderId.ToString(), out gender);
            MaritialStatus maritialStatus;
            Enum.TryParse(p.CommonPerson.MaritialStatusId.ToString(), out maritialStatus);

            var person = new Person()
            {
                Id = p.CommonPersonId,
                PrefixId = p.CommonPerson.PrefixId,
                SuffixId = p.CommonPerson.SuffixId,
                FirstName = p.CommonPerson.FName,
                MiddleName = p.CommonPerson.MName,
                LastName = p.CommonPerson.LName,
                DOB = p.CommonPerson.DOB,
                ActualDOB = p.CommonPerson.ActualDOBIndicator,
                DeceasedDate = p.CommonPerson.DeceasedDate,
                ActualDeceasedDate = p.CommonPerson.ActualDeceasedDateIndicator,
                Height = p.CommonPerson.Height,
                Weight = p.CommonPerson.Weight,
                SSN = p.CommonPerson.SSN,
                LicenseType = Helpers.GetLicenseType(p.CommonPerson.LicenseTypeId),
                DriversLicenseNumber = p.CommonPerson.DriversLicenseNumber,
                DriversLicenseStateId = p.CommonPerson.DriversLicenseStateId,
                MaritialStatus = maritialStatus,
                Gender = gender,
                HairColorId = p.CommonPerson.HairColorId,
                HairPatternId = p.CommonPerson.HairPatternId,
                EyeColorId = p.CommonPerson.EyeColorId,
                RaceId = p.CommonPerson.RaceId,
                SecurityLevel = p.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                DistinguishableMarks = p.DistinguishableMarks,
                Movement = Helpers.ConvertMovementId(p.MovementClassId),
                DateCreated = p.CommonPerson.DateCreated,
                DateUpdated = p.CommonPerson.DateModified,
                LogEntries = new List<PersonLogEntry>()
            };
            person.LogEntries.Add(new PersonLogEntry() { Note = $"Added person {person.ReverseFullName}" });
            return person;
        }

        public static void AddAliasList(Person person, ICollection<AliasPersonRel> list)
        {
            foreach (var rel in list)
            {
                var c = rel;
                var @alias = new PersonAlias()
                {
                    Id = c.AliasId,
                    Name = c.Alias.AliasName,
                    PrimaryStatus = (PrimaryStatus)c.PrimaryStatusId,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateModified
                };
                person.PersonAliases.Add(@alias);
                person.LogEntries.Add(new PersonLogEntry()
                {
                    Note = $"Added Person {person.FullName} alias {@alias.Name}"
                });
            }
        }


        public static void AddChapters(Person person, ICollection<ChapterPersonRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var chapter = db.Chapters.Find(item.Id);
                    person.Chapters.Add(chapter);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added chapter {chapter.Name}" });
                    chapter.LogEntries.Add(new ChapterLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }

        }

        public static void AddWebsites(Person person, ICollection<PersonMediaWebsiteEGroupRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var website = db.Websites.Find(item.Id);
                    person.Websites.Add(website);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added chapter {website.Name}" });
                    website.LogEntries.Add(new WebsiteLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }


        public static void AddCorrespondences(Person person, ICollection<PersonMediaCorrespondenceRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var cor = db.Correspondences.Find(item.Id);
                    person.Correspondence.Add(cor);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added correspondence {cor.Name}" });
                    cor.LogEntries.Add(new CorrespondenceLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }

        public static void AddEvents(Person person, ICollection<PersonEventRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var @event = db.Events.Find(item.Id);
                    person.Events.Add(@event);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Event {@event.Name}" });
                    @event.LogEntries.Add(new EventLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }

        public static void AddPublished(Person person, ICollection<PersonMediaPublishedRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var pub = db.Publications.Find(item.Id);
                    if (pub == null)
                    {
                        pub = new Publication()
                        {
                            Id = item.MediaPublishedId,
                            Name = item.MediaPublished.Name,
                            Summary = item.MediaPublished.Summary,
                            DateReceived = item.MediaPublished.DateReceived,
                            DatePublished = item.MediaPublished.DatePublished,
                            Author = item.MediaPublished.Author,
                            CatalogId = item.MediaPublished.CatalogId,
                            RenewalType = Helpers.ConvertRenewalType(item.MediaPublished.RenewalPermissionTypeId),
                            SecurityLevel = item.MediaPublished.ConfidentialityTypeId == 1 ? SecurityLevel.EyesOnly : SecurityLevel.Open,
                            Movement = Helpers.ConvertMovementId(item.MediaPublished.MovementClassId),
                            //                        PublicationTypeId = item.MediaPublishedPublishedTypeId,
                            City = item.MediaPublished.City,
                            County = item.MediaPublished.County,
                            StateId = item.MediaPublished.StateId,
                            DateCreated = item.MediaPublished.DateCreated,
                            DateUpdated = item.MediaPublished.DateModified,
                            LogEntries = new List<PublicationLogEntry>()
                        };
                        pub.LogEntries.Add(new PublicationLogEntry() { Note = $"Added publication {pub.Name}" });
                    }
                    person.Publications.Add(pub);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added publication {pub.Name}" });
                    pub.LogEntries.Add(new PublicationLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }

        public static void AddAudioVideo(Person person, ICollection<PersonMediaAudioVideoRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var av = db.AudioVideos.Find(item.Id);
                    person.AudioVideos.Add(av);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added audio video {av.Title}" });
                    av.LogEntries.Add(new AudioVideoLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }

        public static void AddImages(Person person, ICollection<PersonMediaImageRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var img = db.MediaImages.Find(item.Id);
                    person.MediaImages.Add(img);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Image {img.Title}" });
                    img.LogEntries.Add(new MediaImageLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }

        public static void AddOrganizations(Person person, ICollection<ChapterPersonRel> list)
        {
            using (var db = new AppContext())
            {
                foreach (var item in list)
                {
                    var c = db.Organizations.Find(item.Id);
                    person.Organizations.Add(c);
                    person.LogEntries.Add(new PersonLogEntry() { Note = $"Added Organization {c.Name}" });
                    c.LogEntries.Add(new OrganizationLogEntry() { Note = $"Added person {person.ReverseFullName}" });
                }
            }
        }

        public static void AddAddresses(Person person, ICollection<AddressPersonRel> list)
        {
            foreach (var item in list)
            {
                var addr = new PersonAddress()
                {
                    Street = item.Address.Address1,
                    Street2 = item.Address.Address2,
                    City = item.Address.City,
                    StateId = item.Address.StateId,
                    County = item.Address.County,
                    ZipCode = $"{item.Address.Zip5}-{item.Address.Zip4}",
                    Country = item.Address.Country,
                    Latitude = item.Address.Latitude,
                    Longitude = item.Address.Longitude,
                    DateCreated = item.DateCreated, 
                    DateUpdated = item.DateModified
                    //todo: need primarystatus here
                };
                person.PersonAddresses.Add(addr);
                person.LogEntries.Add(new PersonLogEntry() { Note = $"Added address" });
            }
        }

        public static void AddOnlineAliasList(Person person, ICollection<PersonScreenName> list)
        {
            foreach (var item in list)
            {
                var addr = new OnlineAlias()
                {
                 ScreenName = item.ScreenName,
                 UsedAt =  item.UsedAt, 
                 FirstUsedDate = item.FirstKnownUseDate, 
                 LastUsedDate = item.LastKnownUseDate
                    //todo: need primarystatus here
                };
                person.OnlineAlias.Add(addr);
                person.LogEntries.Add(new PersonLogEntry() { Note = $"Added online alias" });
            }
        }
    }

}