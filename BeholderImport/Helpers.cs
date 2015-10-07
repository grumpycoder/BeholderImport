using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Models;
using Domain.Models.Enums;
using splc.data;

namespace BeholderImport
{
    internal static class Helpers
    {
        private static List<splc.domain.Models.MovementClass> m1;
        private static List<Domain.Models.Enums.Movement> m2;

        static Helpers()
        {
            using (var context = new AppContext())
            {
                m2 = context.Movements.ToList();
            }
            using (var db = new ACDBContext())
            {
                m1 = db.MovementClasses.ToList();
            }

        }


        public static ImageType? ConvertImageType(int? id)
        {
            if (id != null)
            {
                return (ImageType)id;
            }
            return null;
        }

        public static RenewalType? ConvertRenewalType(int? renewalPermissionTypeId)
        {
            if (renewalPermissionTypeId != null)
            {
                return (RenewalType)renewalPermissionTypeId;
            }
            return null;
        }

        public static LicenseType? GetLicenseType(int? licenseTypeId)
        {

            switch (licenseTypeId)
            {
                case 11:
                    return LicenseType.Chauffeur;
                case 12:
                    return LicenseType.IDCardOnly;
                case 1:
                    return LicenseType.Operator;
                case 2:
                    return LicenseType.Restricted;
                default:
                    return null;
            }
        }

        public static Movement ConvertMovementId(int? movementClassId = 0)
        {
            if (movementClassId != null)
            {
                var i = m1.First(x => x.Id == movementClassId);
                return m2.First(x => x.Name == i.Name);
            }
            return null;

        }

        public static Domain.Models.Website GetWebsite(int id)
        {
            using (var db = new AppContext())
            {
                return db.Websites.Find(id);
            }
        }

        //public static DocumentationType ConvertEventDocType(int? id = 0)
        //{
        //    //if (id != null)
        //    //{
        //    //    return null;
        //    //}
        //    //return null;
        //}
    }
}