using System.Collections.Generic;

namespace School.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string ComercialPhone { get; set; }
        public string Email { get; set; }
        public int instantMessageId { get; set; }

        public List<InstantMessage> instantMessage { get; set; } = new List<InstantMessage>();
        public int socialNetworkId { get; set; }
        public List<SocialNetwork> socialNetwork { get; set; } = new List<SocialNetwork>();
    }
}

