using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public class StateInfo : INotifyPropertyChanged
    {
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Created User")]
        public int? CreatedUserId { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }
        [Display(Name = "Modified User")]
        public int? ModifiedUserId { get; set; }
        [Display(Name = "Date Deleted")]
        public DateTime? DateDeleted { get; set; }
        [Display(Name = "Deleted User")]
        public int? DeletedUserId { get; set; }
        [Display(Name = "Created User")]
        public virtual User CreatedUser { get; set; }
        [Display(Name = "Modified User")]
        public virtual User ModifiedUser { get; set; }
        [Display(Name = "Deleted User")]
        public virtual User DeletedUser { get; set; }

        [NotMapped]
        public bool IsDirty { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;



        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //  IsDirty = true;
        //  PropertyChangedEventHandler handler = PropertyChanged;
        //  if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
