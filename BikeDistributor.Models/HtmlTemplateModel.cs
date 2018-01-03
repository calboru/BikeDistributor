using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeDistributor.Models.Common;
using BikeDistributor.Shared.Interfaces;

namespace BikeDistributor.Models
{
    public class HtmlTemplateModel: BaseModel<int>
    {
        public string Type { get; set; }
        public string Content { get; set; }

    }
}
