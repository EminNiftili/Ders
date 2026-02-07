namespace Entities.Clients
{
    public class IdentityCardEntity : BaseEntity
    {
        public int PersonId { get; set; }
        public string PinCode { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
        public string RegisteredAddress { get; set; } = null!;

        public PersonEntity? Person { get; set; }
    }
}
