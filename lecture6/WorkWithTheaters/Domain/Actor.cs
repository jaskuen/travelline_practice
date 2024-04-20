namespace Domain
{
    public class Actor
    {
        public int Id { get; private init; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public string FullName => $"{Surname} {Name}";
        public IReadOnlyList<Play> Plays {  get; private init; } = new List<Play>();

        public Actor(string name, string surname, string phoneNumber, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
            }

            if (string.IsNullOrEmpty(surname))
            {
                throw new ArgumentException($"\"{nameof(surname)}\" не может быть неопределенным или пустым.", nameof(surname));
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException($"\"{nameof(phoneNumber)}\" не может быть неопределенным или пустым.", nameof(phoneNumber));
            }
            DateOfBirth = dateOfBirth;
        }
    }
}
