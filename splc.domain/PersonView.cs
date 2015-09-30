using splc.infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain
{
    [Serializable]
    public class PersonView : IKeyed<int>
    {
        [Key]
        public virtual int Id { get; set; }
        //public int OrganizationCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0}, {1}", LastName, FirstName); } }
        public DateTime? DOB { get; set; }


    }
}
