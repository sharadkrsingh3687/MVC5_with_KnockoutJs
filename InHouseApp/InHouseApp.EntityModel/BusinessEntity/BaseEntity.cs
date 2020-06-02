using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InHouseApp.EntityModel.BusinessEntity
{
    public class BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public String CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public String ModifiedBy { get; set; }

    }
}
