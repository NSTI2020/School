using System.Collections.Generic;

namespace School.Domain.Entities.Dtos
{
    public class UnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoomsDtoId { get; set; }
        public List<RoomDto> RoomsDto { get; set; } = new List<RoomDto>();
        public int CheckingAccountsDtoId { get; set; }
        public List<CheckingAccountDto> CheckingAccountsDto { get; set; }
        public int AddressDtoId { get; set; }
        public AddressDto AddressDto { get; set; }
    }
}
