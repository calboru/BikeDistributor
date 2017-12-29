using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using BikeDistributor.Interfaces.Shared;

namespace BikeDistributor.Data.Common
{
  public abstract class BaseEntity<T>: IEntity<T>
  {
      private PropertyInfo[] _propertyInfos = null;

        private DateTime? _createdDate;
      public string Name { get; set; }
      object IEntity.Id => Id;

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public   T Id { get; set; }
      public DateTime? CreatedDate
      {
            get => _createdDate  ?? DateTime.Now ;
            set => _createdDate = value;
      }
      [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }
      public string CreatedBy { get; set; }
      public string ModifiedBy { get; set; }
      [Timestamp]
        public byte[] Version { get; set; }

      public override string ToString()
      {
          
          if (_propertyInfos == null)
              _propertyInfos =  GetType().GetProperties();

          var sb = new StringBuilder();
          sb.Append(GetType().FullName);
          sb.Append("-");

            foreach (var info in _propertyInfos)
          {
              var value = info.GetValue(this, null) ?? "(null)";
              sb.Append(info.Name + "[" + value.ToString() + "]|");
                
          }

          return sb.ToString(); ;
      }
  }
}
