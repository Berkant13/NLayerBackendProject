using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity
    {
        //EF core otomatik olarak bunu id olarak algılar.Yoksa[Key("entity_attribute ismi verilir")]
        //Eğer foreign key olarak atamak istiyorsak [ForeignKey("entity_attribute")] olarak verebiliriz.
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
