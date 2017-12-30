using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using BikeDistributor.Shared.Interfaces;

namespace BikeDistributor.Data.Common
{
    public abstract class BaseEntity<T> : IEntity<T>
    {
        private DateTime? _createdDate;
        public virtual string Name { get; set; }
        object IEntity.Id => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }

        public DateTime? CreatedDate
        {
            get => _createdDate ?? DateTime.Now;
            set => _createdDate = value;
        }

        [DataType(DataType.DateTime)]
        public virtual DateTime? ModifiedDate { get; set; }

        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
