using System.Collections.Generic;

namespace School.Domain.Entities.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string ComercialPhone { get; set; }
        public string Email { get; set; }
        public List<InstantMessageDto> instantMessageDto { get; set; } = new List<InstantMessageDto>();
        public List<SocialNetworkDto> socialNetworkDto { get; set; } = new List<SocialNetworkDto>();
    }
}
