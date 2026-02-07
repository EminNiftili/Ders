using Entities.Clients;

namespace Web.Dtos
{
    public class IdentityCardDto
    {
        public IdentityCardDto(IdentityCardEntity entity)
        {
            Id = entity.Id;
            PinCode = entity.PinCode;
            SerialNumber = entity.SerialNumber;
            RegisteredAddress = entity.RegisteredAddress;
        }
        public int Id { get; set; }
        public string PinCode { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string RegisteredAddress { get; set; } = null!;
    }
}
