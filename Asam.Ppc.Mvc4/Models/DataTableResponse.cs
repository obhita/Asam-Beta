using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Asam.Ppc.Mvc4.Models
{
    [DataContract]
    public class DataTableResponse<TModel>
    {
        [DataMember(Name = "sEcho")]
        public string Echo { get; set; }

        [DataMember(Name = "iTotalRecords")]
        public int TotalRecords { get; set; }

        [DataMember(Name = "iTotalDisplayRecords")]
        public int TotalDisplayRecords { get; set; }

        [DataMember(Name = "aaData")]
        public IEnumerable<TModel> Data { get; set; }
    }
}