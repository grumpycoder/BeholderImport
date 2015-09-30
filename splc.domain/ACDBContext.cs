using splc.domain.Models;
using splc.domain.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace splc.domain
{
    public partial class ACDBContext : IdentityDbContext<ApplicationUser>
    {
        static ACDBContext()
        {
            //            DbInterception.Add(new FtsInterceptor());
            Database.SetInitializer<ACDBContext>(null);

        }

        private int userId;

        public ACDBContext()
            : base("Name=ACDBContext")
        {
            //            userName = HttpContext.Current.User.Identity.Name;
            //userId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
        }

        //protected override DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
        //{
        //    var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
        //    if (entityEntry.Entity is AliasChapterRel && entityEntry.State == EntityState.Added)
        //    {
        //        AliasChapterRel entity = entityEntry.Entity as AliasChapterRel;
        //        if (entity.FirstKnownUseDate > entity.LastKnownUseDate)
        //        {
        //            result.ValidationErrors.Add(new System.Data.Entity.Validation.DbValidationError("FirstKnownUseDate", "Date error."));
        //        }
        //    }

        //    if (result.ValidationErrors.Count > 0)
        //    {
        //        return result;
        //    }
        //    else
        //    {
        //        return base.ValidateEntity(entityEntry, items);
        //    }
        //}

        private DBAudit AuditTrailFactory(ObjectStateEntry entry, int userId)
        {
            //var userRepo = new UserRepository(this);
            //var user = userRepo.Find(userId);

            DBAudit audit = new DBAudit();
            audit.RevisionStamp = DateTime.Now;
            audit.TableName = entry.EntitySet.Name;
            audit.KeyValue = (int?)entry.CurrentValues.GetValue(0);
            //            audit.UserName = userName;

            if (entry.State == EntityState.Added)
            {//entry is Added 
                audit.NewData = GetEntryValueInString(entry, false);
                audit.Actions = "Added";
            }
            else if (entry.State == EntityState.Deleted)
            {//entry in deleted
                audit.OldData = GetEntryValueInString(entry, true);
                audit.Actions = "Deleted";
            }
            else
            {//entry is modified
                //audit.OldData = GetEntryValueInString(entry, true);
                audit.NewData = GetEntryValueInString(entry, false);
                audit.Actions = "Modified";

                IEnumerable<string> modifiedProperties = entry.GetModifiedProperties();
                //assing collection of mismatched Columns name as serialized string 
                //                audit.ChangedColumns = XMLSerializationHelper.XmlSerialize(modifiedProperties.ToArray());
            }

            return audit;
        }


        private string GetEntryValueInString(ObjectStateEntry entry, bool isOrginal)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string propertyName in entry.GetModifiedProperties())
            {
                DbDataRecord original = entry.OriginalValues;
                CurrentValueRecord current = entry.CurrentValues;
                //if (original.GetValue(original.GetOrdinal(propertyName)).ToString() != current.GetValue(current.GetOrdinal(propertyName)).ToString())
                //{
                if (isOrginal)
                {
                    sb.Append(String.Format("Property:{0} Value:{1} /", propertyName, original.GetValue(original.GetOrdinal(propertyName)).ToString()));
                }
                else
                {
                    sb.Append(String.Format("Property:{0} Value:{1} /", propertyName, current.GetValue(current.GetOrdinal(propertyName)).ToString()));
                }
                //}
            }
            return sb.ToString();

            //if (entry.Entity is EntityObject)
            //{
            //    object target = CloneEntity((EntityObject)entry.Entity);
            //    foreach (string propName in entry.GetModifiedProperties())
            //    {
            //        object setterValue = null;
            //        if (isOrginal)
            //        {
            //            //Get orginal value 
            //            setterValue = entry.OriginalValues[propName];
            //        }
            //        else
            //        {
            //            //Get orginal value 
            //            setterValue = entry.CurrentValues[propName];
            //        }
            //        //Find property to update 
            //        PropertyInfo propInfo = target.GetType().GetProperty(propName);
            //        //update property with orgibal value 
            //        if (setterValue == DBNull.Value)
            //        {//
            //            setterValue = null;
            //        }
            //        propInfo.SetValue(target, setterValue, null);
            //    }//end foreach

            //    XmlSerializer formatter = new XmlSerializer(target.GetType());
            //    XDocument document = new XDocument();

            //    using (XmlWriter xmlWriter = document.CreateWriter())
            //    {
            //        formatter.Serialize(xmlWriter, target);
            //    }
            //    return document.Root.ToString();
            //}
            //return null;
        }

        public EntityObject CloneEntity(EntityObject obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();

            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;

            EntityObject newObject = (EntityObject)dcSer.ReadObject(memoryStream);
            return newObject;
        }

        public override int SaveChanges()
        {
            //ChangeTracker.DetectChanges(); // Important!
            ObjectContext ctx = ((IObjectContextAdapter)this).ObjectContext;

            //            userRepo = new UserRepository(this);
            //            userId = userRepo.GetUsers(x => x.UserName == userName).FirstOrDefault().Id;

            List<DBAudit> auditTrailList = new List<DBAudit>();


            //handle soft delete.
            foreach (var stateinfo in this.ChangeTracker.Entries()
                .Where(e => e.Entity is StateInfo && e.State == EntityState.Deleted))
            {
                stateinfo.State = EntityState.Unchanged;
                ((StateInfo)stateinfo.Entity).DateDeleted = DateTime.Now;
                ((StateInfo)stateinfo.Entity).DeletedUserId = userId;
            }

            List<ObjectStateEntry> objectStateEntryList = ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted).ToList();
            foreach (ObjectStateEntry entry in objectStateEntryList)
            {
                if (entry.Entity is StateInfo)
                {
                    //Update modified
                    if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                    {
                        ((StateInfo)entry.Entity).DateModified = DateTime.Now;
                        ((StateInfo)entry.Entity).ModifiedUserId = userId;
                    }
                    //Update added
                    if (entry.State == EntityState.Added)
                    {
                        ((StateInfo)entry.Entity).DateCreated = DateTime.Now;
                        ((StateInfo)entry.Entity).DateModified = DateTime.Now;
                        ((StateInfo)entry.Entity).CreatedUserId = userId;
                        ((StateInfo)entry.Entity).ModifiedUserId = userId;
                    }
                    //handle audit log
                    if (!(entry.Entity is DBAudit) && !entry.IsRelationship)
                    {
                        DBAudit audit = this.AuditTrailFactory(entry, userId);
                        auditTrailList.Add(audit);
                    }
                }
            }

            if (auditTrailList.Count > 0)
            {
                foreach (var audit in auditTrailList)
                {//add all audits 
                    this.DBAudit.Add(audit);
                }
            }


            //foreach (var stateinfo in this.ChangeTracker.Entries()
            //    .Where(e => e.Entity is StateInfo && e.State == EntityState.Deleted)
            //    .Select(e => e.Entity as StateInfo))
            //{
            //    stateinfo.
            //    stateinfo.DateModified = DateTime.Now;
            //    //stateinfo.CreatedUserId = 1; 
            //}


            //foreach (var stateinfo in this.ChangeTracker.Entries()
            //    .Where(e => e.Entity is StateInfo && (e.State == EntityState.Added || e.State == EntityState.Modified))
            //    .Select(e => e.Entity as StateInfo))
            //{

            //    stateinfo.DateModified = DateTime.Now;
            //    //stateinfo.CreatedUserId = 1; 
            //}

            //foreach (var stateinfo in this.ChangeTracker.Entries()
            //    .Where(e => e.Entity is StateInfo && (e.State == EntityState.Added))
            //    .Select(e => e.Entity as StateInfo))
            //{
            //    stateinfo.DateCreated = DateTime.Now;
            //    //stateinfo.ModifiedUserId = 1;
            //}
            //try
            //{
            int result = base.SaveChanges();
            return result;
            //}
            //catch (DbEntityValidationException dbValEx)
            //{
            //    var outputLines = new StringBuilder();
            //    foreach (var eve in dbValEx.EntityValidationErrors)
            //    {
            //        outputLines.AppendFormat(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:"
            //            , DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State);

            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.AppendFormat("- Property: \"{0}\", Error: \"{1}\""
            //                , ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //}

            //foreach (var stateinfo in this.ChangeTracker.Entries()
            //                              .Where(e => e.Entity is StateInfo)
            //                              .Select(e => e.Entity as StateInfo))
            //{
            //    stateinfo.IsDirty = false;
            //}

            return 0;
        }

        public DbSet<Chapter> Chapters { get; set; }

        #region DbSets

        public DbSet<DBAudit> DBAudit { get; set; }
        public DbSet<Search> Search { get; set; }
        public DbSet<ActiveStatus> ActiveStatus { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatus { get; set; }
        public DbSet<ConfidentialityType> ConfidentialityTypes { get; set; }
        public DbSet<EyeColor> EyeColors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<HairColor> HairColors { get; set; }
        public DbSet<HairPattern> HairPatterns { get; set; }
        public DbSet<ContactInfoType> ContactInfoTypes { get; set; }
        public DbSet<ChapterType> ChapterTypes { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<MaritialStatus> MaritialStatus { get; set; }
        public DbSet<MovementClass> MovementClasses { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<MimeType> MimeTypes { get; set; }
        public DbSet<NewsSourceType> NewsSourceTypes { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Prefix> Prefixes { get; set; }
        public DbSet<PrimaryStatus> PrimaryStatus { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RemovalStatus> RemovalStatus { get; set; }
        public DbSet<RelationshipType> RelationshipTypes { get; set; }
        public DbSet<RenewalPermmisionType> RenewalPermmisionTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Suffix> Suffixes { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleColor> VehicleColors { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<AudioVideoType> AudioVideoTypes { get; set; }
        public DbSet<CorrespondenceType> CorrespondenceTypes { get; set; }
        public DbSet<EventDocumentationType> EventDocumentationTypes { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<LibraryCategoryType> LibraryCategoryTypes { get; set; }
        public DbSet<ContactTopic> ContactTopics { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<PublishedType> PublishedTypes { get; set; }
        public DbSet<TagType> TagTypes { get; set; }
        public DbSet<WebIncidentType> WebIncidentTypes { get; set; }
        public DbSet<WebsiteGroupType> WebsiteGroupTypes { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressPersonRel> AddressPersonRels { get; set; }
        public DbSet<AddressContactRel> AddressContactRels { get; set; }
        public DbSet<AddressChapterRel> AddressChapterRels { get; set; }
        public DbSet<AddressEventRel> AddressEventRels { get; set; }

        public DbSet<Alias> Aliases { get; set; }
        public DbSet<AliasPersonRel> AliasPersonRels { get; set; }
        public DbSet<AliasOrganizationRel> AliasOrganizationRels { get; set; }
        public DbSet<AliasChapterRel> AliasChapterRels { get; set; }

        public DbSet<BeholderPerson> BeholderPersons { get; set; }
        public DbSet<CommonPerson> CommonPersons { get; set; }
        public DbSet<DropdownPerson> DropdownPersons { get; set; }
        public DbSet<PersonComment> PersonComments { get; set; }
        public DbSet<PersonScreenName> PersonScreenNames { get; set; }
        public DbSet<PersonMediaImageRel> PersonMediaImageRels { get; set; }
        public DbSet<PersonMediaAudioVideoRel> PersonMediaAudioVideoRels { get; set; }
        public DbSet<PersonEventRel> PersonEventRels { get; set; }
        public DbSet<PersonContactRel> PersonContactRels { get; set; }
        public DbSet<PersonPersonRel> PersonPersonRels { get; set; }
        public DbSet<PersonVehicleRel> PersonVehicleRels { get; set; }
        public DbSet<PersonMediaCorrespondenceRel> PersonMediaCorrespondenceRels { get; set; }
        public DbSet<PersonMediaPublishedRel> PersonMediaPublishedRels { get; set; }

        public DbSet<MediaPublished> MediaPublisheds { get; set; }
        public DbSet<MediaPublishedComment> MediaPublishedComments { get; set; }
        public DbSet<MediaPublishedContext> MediaPublishedContexts { get; set; }
        public DbSet<MediaPublishedContext_Index> MediaPublishedContext_Indexes { get; set; }
        public DbSet<MediaPublishedEventRel> MediaPublishedEventRels { get; set; }
        public DbSet<MediaPublishedMediaAudioVideoRel> MediaPublishedMediaAudioVideoRels { get; set; }
        public DbSet<MediaPublishedMediaCorrespondenceRel> MediaPublishedMediaCorrespondenceRels { get; set; }
        public DbSet<MediaPublishedMediaImageRel> MediaPublishedMediaImageRels { get; set; }
        public DbSet<MediaPublishedMediaPublishedRel> MediaPublishedMediaPublishedRels { get; set; }
        public DbSet<MediaPublishedMediaWebsiteEGroupRel> MediaPublishedMediaWebsiteEGroupRels { get; set; }
        public DbSet<MediaPublishedVehicleRel> MediaPublishedVehicleRels { get; set; }

        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<ContactInfoPersonRel> ContactInfoPersonRels { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactComment> ContactComments { get; set; }
        public DbSet<ContactMediaImageRel> ContactMediaImageRels { get; set; }
        public DbSet<ContactContactRel> ContactContactRels { get; set; }
        public DbSet<ContactMediaCorrespondenceRel> ContactMediaCorrespondenceRels { get; set; }

        public DbSet<ChapterComment> ChapterComments { get; set; }
        public DbSet<ChapterStatusHistory> ChapterStatusHistories { get; set; }
        public DbSet<ChapterMediaImageRel> ChapterMediaImageRels { get; set; }
        public DbSet<ChapterPersonRel> ChapterPersonRels { get; set; }
        public DbSet<ChapterEventRel> ChapterEventRels { get; set; }
        public DbSet<ChapterContactRel> ChapterContactRels { get; set; }
        public DbSet<ChapterOrganizationRel> ChapterOrganizationRels { get; set; }
        public DbSet<ChapterContactInfoRel> ChapterContactInfoRels { get; set; }
        public DbSet<ChapterChapterRel> ChapterChapterRels { get; set; }
        public DbSet<ChapterMediaAudioVideoRel> ChapterMediaAudioVideoRels { get; set; }
        public DbSet<ChapterVehicleRel> ChapterVehicleRels { get; set; }
        public DbSet<DropdownChapter> DropdownChapters { get; set; }
        public DbSet<ChapterMediaCorrespondenceRel> ChapterMediaCorrespondenceRels { get; set; }
        public DbSet<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventEventRel> EventEventRels { get; set; }
        public DbSet<EventMediaImageRel> EventMediaImageRels { get; set; }
        public DbSet<EventMediaAudioVideoRel> EventMediaAudioVideoRels { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<EventStatusHistory> EventStatusHistories { get; set; }
        public DbSet<EventVehicleRel> EventVehicleRels { get; set; }
        public DbSet<EventEventTypeRel> EventEventTypeRels { get; set; }

        public DbSet<ImageType> ImageTypes { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<MediaImage> MediaImages { get; set; }
        public DbSet<MediaImageComment> MediaImageComments { get; set; }
        public DbSet<MediaImageMediaAudioVideoRel> MediaImageMediaAudioVideoRels { get; set; }
        public DbSet<MediaImageMediaImageRel> MediaImageMediaImageRels { get; set; }
        public DbSet<MediaImageVehicleRel> MediaImageVehicleRels { get; set; }

        public DbSet<NewsSource> NewsSources { get; set; }
        public DbSet<NewsSourceComment> NewsSourceComments { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationPersonRel> OrganizationPersonRels { get; set; }
        public DbSet<OrganizationComment> OrganizationComments { get; set; }
        public DbSet<OrganizationMediaImageRel> OrganizationMediaImageRels { get; set; }
        public DbSet<OrganizationEventRel> OrganizationEventRels { get; set; }
        public DbSet<OrganizationMediaAudioVideoRel> OrganizationMediaAudioVideoRels { get; set; }
        public DbSet<OrganizationOrganizationRel> OrganizationOrganizationRels { get; set; }
        public DbSet<OrganizationVehicleRel> OrganizationVehicleRels { get; set; }
        public DbSet<DropdownOrganization> DropdownOrganizations { get; set; }
        public DbSet<OrganizationMediaCorrespondenceRel> OrganizationMediaCorrespondenceRels { get; set; }
        public DbSet<OrganizationMediaPublishedRel> OrganizationMediaPublishedRels { get; set; }
        public DbSet<OrganizationStatusHistory> OrganizationStatusHistories { get; set; }

        public DbSet<MediaAudioVideo> MediaAudioVideos { get; set; }
        public DbSet<MediaAudioVideoComment> MediaAudioVideoComments { get; set; }
        public DbSet<MediaAudioVideoVehicleRel> MediaAudioVideoVehicleRels { get; set; }

        public DbSet<MediaCorrespondence> MediaCorrespondences { get; set; }
        public DbSet<MediaCorrespondenceContext> MediaCorrespondenceContexts { get; set; }
        public DbSet<MediaCorrespondenceContext_Index> MediaCorrespondenceContext_Indexes { get; set; }
        public DbSet<MediaCorrespondenceComment> MediaCorrespondenceComments { get; set; }
        public DbSet<MediaCorrespondenceEventRel> MediaCorrespondenceEventRels { get; set; }
        public DbSet<MediaCorrespondenceMediaAudioVideoRel> MediaCorrespondenceMediaAudioVideoRels { get; set; }
        public DbSet<MediaCorrespondenceMediaCorrespondenceRel> MediaCorrespondenceMediaCorrespondenceRels { get; set; }
        public DbSet<MediaCorrespondenceMediaImageRel> MediaCorrespondenceMediaImageRels { get; set; }
        public DbSet<MediaCorrespondenceVehicleRel> MediaCorrespondenceVehicleRels { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<AddressSubscriptionsRel> AddressSubscriptionsRels { get; set; }
        public DbSet<ChapterSubscriptionRel> ChapterSubscriptionRels { get; set; }
        public DbSet<ContactSubscriptionRel> ContactSubscriptionRels { get; set; }
        public DbSet<EventSubscriptionRel> EventSubscriptionRels { get; set; }
        public DbSet<MediaCorrespondenceSubscriptionRel> MediaCorrespondenceSubscriptionRels { get; set; }
        public DbSet<MediaImageSubscriptionRel> MediaImageSubscriptionRels { get; set; }
        public DbSet<MediaPublishedSubscriptionRel> MediaPublishedSubscriptionRels { get; set; }
        public DbSet<OrganizationSubscriptionRel> OrganizationSubscriptionRels { get; set; }
        public DbSet<SubscriptionComment> SubscriptionComments { get; set; }
        public DbSet<SubscriptionSubscriptionRel> SubscriptionSubscriptionRels { get; set; }
        public DbSet<SubscriptionVehicleRel> SubscriptionVehicleRels { get; set; }

        public DbSet<ChapterMediaWebsiteEGroupRel> ChapterMediaWebsiteEGroupRels { get; set; }
        public DbSet<EventMediaWebsiteEGroupRel> EventMediaWebsiteEGroupRels { get; set; }
        public DbSet<MediaCorrespondenceMediaWebsiteEGroupRel> MediaCorrespondenceMediaWebsiteEGroupRels { get; set; }
        public DbSet<MediaImageMediaWebsiteEGroupRel> MediaImageMediaWebsiteEGroupRels { get; set; }
        public DbSet<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public DbSet<MediaWebsiteEGroupComment> MediaWebsiteEGroupComments { get; set; }
        public DbSet<MediaWebsiteEGroupMediaAudioVideoRel> MediaWebsiteEGroupMediaAudioVideoRels { get; set; }
        public DbSet<MediaWebsiteEGroupMediaWebsiteEGroupRel> MediaWebsiteEGroupMediaWebsiteEGroupRels { get; set; }
        public DbSet<MediaWebsiteEGroupSubscriptionRel> MediaWebsiteEGroupSubscriptionRels { get; set; }
        public DbSet<MediaWebsiteEGroupVehicleRel> MediaWebsiteEGroupVehicleRels { get; set; }
        public DbSet<OrganizationMediaWebsiteEGroupRel> OrganizationMediaWebsiteEGroupRels { get; set; }
        public DbSet<PersonMediaWebsiteEGroupRel> PersonMediaWebsiteEGroupRels { get; set; }
        public DbSet<MediaWebsiteEGroupContext> MediaWebsiteEGroupContexts { get; set; }
        public DbSet<MediaWebsiteEGroupContext_Index> MediaWebsiteEGroupContext_Indexes { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleComment> VehicleComments { get; set; }
        public DbSet<VehicleVehicleRel> VehicleVehicleRels { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }

        public DbSet<PendingRemoval> PendingRemovals { get; set; }
        public DbSet<ChapterReport> ChapterReports { get; set; }
        public DbSet<EventReport> EventReports { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<ApplicationUser>().ToTable("Security.Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("Security.UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("Security.UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("Security.UserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("Security.Roles");

            //            modelBuilder.Configurations.Add(new ChapterMap());
            modelBuilder.Entity<Chapter>().ToTable("Beholder.Chapters").HasKey(k => k.Id)
                .HasOptional(t => t.MovementClass)
                .WithMany(t => t.Chapters)
                .HasForeignKey(d => d.MovementClassId);

//            modelBuilder.Entity<Chapter>().HasOptional(t => t.ChapterType)
//                .WithMany(t => t.Chapters)
//                .HasForeignKey(d => d.ChapterTypeId); ;

            modelBuilder.Configurations.Add(new DBAuditMap());
            modelBuilder.Configurations.Add(new SearchMap());

            modelBuilder.Configurations.Add(new ActiveStatusMap());
            modelBuilder.Configurations.Add(new AddressTypeMap());
            modelBuilder.Configurations.Add(new ApprovalStatusMap());
            modelBuilder.Configurations.Add(new ConfidentialityTypeMap());
            modelBuilder.Configurations.Add(new ContactInfoMap());
            modelBuilder.Configurations.Add(new ContactInfoTypeMap());
            modelBuilder.Configurations.Add(new EyeColorMap());
            modelBuilder.Configurations.Add(new ImageTypeMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Configurations.Add(new ReligionMap());
            modelBuilder.Configurations.Add(new HairColorMap());
            modelBuilder.Configurations.Add(new HairPatternMap());
            modelBuilder.Configurations.Add(new LicenseTypeMap());
            modelBuilder.Configurations.Add(new MovementClassMap());
            modelBuilder.Configurations.Add(new MaritialStatusMap());
            modelBuilder.Configurations.Add(new MediaTypeMap());
            modelBuilder.Configurations.Add(new MimeTypeMap());
            modelBuilder.Configurations.Add(new PrefixMap());
            modelBuilder.Configurations.Add(new PrimaryStatusMap());
            modelBuilder.Configurations.Add(new RaceMap());
            modelBuilder.Configurations.Add(new RenewalPermmisionTypeMap());
            modelBuilder.Configurations.Add(new RemovalStatusMap());
            modelBuilder.Configurations.Add(new RelationshipTypeMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new SuffixMap());
            modelBuilder.Configurations.Add(new AudioVideoTypeMap());
            modelBuilder.Configurations.Add(new ContactTopicMap());
            modelBuilder.Configurations.Add(new ContactTypeMap());
            modelBuilder.Configurations.Add(new CorrespondenceTypeMap());
            modelBuilder.Configurations.Add(new EventDocumentationTypeMap());
            modelBuilder.Configurations.Add(new EventTypeMap());
            modelBuilder.Configurations.Add(new LibraryCategoryTypeMap());
            modelBuilder.Configurations.Add(new PublishedTypeMap());
            modelBuilder.Configurations.Add(new TagTypeMap());
            modelBuilder.Configurations.Add(new VehicleColorMap());
            modelBuilder.Configurations.Add(new VehicleMakeMap());
            modelBuilder.Configurations.Add(new VehicleModelMap());
            modelBuilder.Configurations.Add(new VehicleTagMap());
            modelBuilder.Configurations.Add(new VehicleTypeMap());
            modelBuilder.Configurations.Add(new ChapterTypeMap());
            modelBuilder.Configurations.Add(new WebIncidentTypeMap());
            modelBuilder.Configurations.Add(new WebsiteGroupTypeMap());

            modelBuilder.Configurations.Add(new AddressChapterRelMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AddressPersonRelMap());
            modelBuilder.Configurations.Add(new AddressContactRelMap());
            modelBuilder.Configurations.Add(new AddressEventRelMap());

            modelBuilder.Configurations.Add(new AliasOrganizationRelMap());
            modelBuilder.Configurations.Add(new AliasMap());
            modelBuilder.Configurations.Add(new AliasPersonRelMap());
            modelBuilder.Configurations.Add(new AliasChapterRelMap());

            modelBuilder.Configurations.Add(new CommonPersonMap());
            modelBuilder.Configurations.Add(new BeholderPersonMap());
            modelBuilder.Configurations.Add(new DropdownPersonMap());
            modelBuilder.Configurations.Add(new PersonScreenNameMap());
            modelBuilder.Configurations.Add(new PersonCommentMap());
            modelBuilder.Configurations.Add(new PersonVehicleRelMap());
            modelBuilder.Configurations.Add(new PersonContactRelMap());
            modelBuilder.Configurations.Add(new PersonPersonRelMap());
            modelBuilder.Configurations.Add(new PersonMediaImageRelMap());
            modelBuilder.Configurations.Add(new PersonMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new PersonEventRelMap());
            modelBuilder.Configurations.Add(new PersonMediaCorrespondenceRelMap());
            modelBuilder.Configurations.Add(new PersonMediaPublishedRelMap());

            modelBuilder.Configurations.Add(new ChapterMediaImageRelMap());

            modelBuilder.Configurations.Add(new ChapterCommentMap());
            modelBuilder.Configurations.Add(new ChapterStatusHistoryMap());
            modelBuilder.Configurations.Add(new ChapterPersonRelMap());
            modelBuilder.Configurations.Add(new ChapterEventRelMap());
            modelBuilder.Configurations.Add(new ChapterContactRelMap());
            modelBuilder.Configurations.Add(new ChapterOrganizationRelMap());
            modelBuilder.Configurations.Add(new ChapterContactInfoRelMap());
            modelBuilder.Configurations.Add(new DropdownChapterMap());
            modelBuilder.Configurations.Add(new ChapterChapterRelMap());
            modelBuilder.Configurations.Add(new ChapterMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new ChapterVehicleRelMap());
            modelBuilder.Configurations.Add(new ChapterMediaCorrespondenceRelMap());
            modelBuilder.Configurations.Add(new ChapterMediaPublishedRelMap());

            modelBuilder.Configurations.Add(new ContactContactRelMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContactInfoPersonRelMap());
            modelBuilder.Configurations.Add(new ContactCommentMap());
            modelBuilder.Configurations.Add(new ContactMediaImageRelMap());
            modelBuilder.Configurations.Add(new ContactMediaCorrespondenceRelMap());

            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new EventEventRelMap());
            modelBuilder.Configurations.Add(new EventMediaImageRelMap());
            modelBuilder.Configurations.Add(new EventMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new EventCommentMap());
            modelBuilder.Configurations.Add(new EventVehicleRelMap());
            modelBuilder.Configurations.Add(new EventEventTypeRelMap());
            modelBuilder.Configurations.Add(new EventStatusHistoryMap());

            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new MediaImageMap());
            modelBuilder.Configurations.Add(new MediaImageCommentMap());
            modelBuilder.Configurations.Add(new MediaImageMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new MediaImageMediaImageRelMap());
            modelBuilder.Configurations.Add(new MediaImageVehicleRelMap());

            modelBuilder.Configurations.Add(new MediaAudioVideoMap());
            modelBuilder.Configurations.Add(new MediaAudioVideoCommentMap());
            modelBuilder.Configurations.Add(new MediaAudioVideoVehicleRelMap());

            modelBuilder.Configurations.Add(new MediaCorrespondenceMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceContextMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceContext_IndexMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceCommentMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceEventRelMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceMediaCorrespondenceRelMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceMediaImageRelMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceSubscriptionRelMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceVehicleRelMap());

            modelBuilder.Configurations.Add(new MediaPublishedMap());
            //modelBuilder.Configurations.Add(new MediaPublishedContextMap());
            modelBuilder.Configurations.Add(new MediaPublishedContext_IndexMap());
            modelBuilder.Configurations.Add(new MediaPublishedCommentMap());
            modelBuilder.Configurations.Add(new MediaPublishedEventRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedMediaCorrespondenceRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedMediaImageRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedMediaPublishedRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedVehicleRelMap());

            modelBuilder.Configurations.Add(new NewsSourceMap());
            modelBuilder.Configurations.Add(new NewsSourceCommentMap());
            modelBuilder.Configurations.Add(new NewsSourceTypeMap());

            modelBuilder.Configurations.Add(new OrganizationMap());
            modelBuilder.Configurations.Add(new OrganizationTypeMap());
            modelBuilder.Configurations.Add(new OrganizationPersonRelMap());
            modelBuilder.Configurations.Add(new OrganizationCommentMap());
            modelBuilder.Configurations.Add(new OrganizationMediaImageRelMap());
            modelBuilder.Configurations.Add(new OrganizationEventRelMap());
            modelBuilder.Configurations.Add(new DropdownOrganizationMap());
            modelBuilder.Configurations.Add(new OrganizationMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new OrganizationOrganizationRelMap());
            modelBuilder.Configurations.Add(new OrganizationVehicleRelMap());
            modelBuilder.Configurations.Add(new OrganizationMediaCorrespondenceRelMap());
            modelBuilder.Configurations.Add(new OrganizationMediaPublishedRelMap());
            modelBuilder.Configurations.Add(new OrganizationStatusHistoryMap());

            modelBuilder.Configurations.Add(new SubscriptionMap());
            modelBuilder.Configurations.Add(new AddressSubscriptionsRelMap());
            modelBuilder.Configurations.Add(new ChapterSubscriptionRelMap());
            modelBuilder.Configurations.Add(new ContactSubscriptionRelMap());
            modelBuilder.Configurations.Add(new EventSubscriptionRelMap());
            modelBuilder.Configurations.Add(new MediaImageSubscriptionRelMap());
            modelBuilder.Configurations.Add(new MediaPublishedSubscriptionRelMap());
            modelBuilder.Configurations.Add(new OrganizationSubscriptionRelMap());
            modelBuilder.Configurations.Add(new SubscriptionCommentMap());
            modelBuilder.Configurations.Add(new SubscriptionSubscriptionRelMap());
            modelBuilder.Configurations.Add(new SubscriptionVehicleRelMap());

            modelBuilder.Configurations.Add(new ChapterMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new EventMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new MediaCorrespondenceMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new MediaImageMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupCommentMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupMediaAudioVideoRelMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupSubscriptionRelMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupVehicleRelMap());
            modelBuilder.Configurations.Add(new OrganizationMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new PersonMediaWebsiteEGroupRelMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupContextMap());
            modelBuilder.Configurations.Add(new MediaWebsiteEGroupContext_IndexMap());

            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new VehicleCommentMap());
            modelBuilder.Configurations.Add(new VehicleVehicleRelMap());

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserTypeMap());

            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new GroupUserMap());
            modelBuilder.Configurations.Add(new PendingRemovalMap());
            modelBuilder.Configurations.Add(new ChapterReportMap());
            modelBuilder.Configurations.Add(new EventReportMap());

            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails).WithRequired(e => e.Order).WillCascadeOnDelete(false);
            modelBuilder.Entity<Customer>().HasMany(e => e.Transactions);

        }


    }
}
