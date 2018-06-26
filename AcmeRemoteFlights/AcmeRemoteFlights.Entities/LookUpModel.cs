using System;
using System.ComponentModel.DataAnnotations.Schema;
using LiteDB;

namespace AcmeRemoteFlights.Entities
{
    [Table("tblLookUp")]
    public class LookUpModel
    {
        [BsonId]
        public Guid LookUpId { get; set; }
        public string LookUpType { get; set; }
        public int LookupNumber { get; set; }
        public string Description { get; set; }
    }
}
