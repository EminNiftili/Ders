namespace Web
{
    public class Ders : IDers
    {
        private int SalamCount = 0;
        public void Salam()
        {
            Console.Write("Salam ");
            SalamCount++;
            Console.WriteLine(SalamCount);
        }
    }
}
