using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;


namespace DeSerialisation
{
    [Serializable]
    [DataContract (Name = "Cartoon", Namespace = "DeSerialisation")]
    public class Cartoon : TvProgram, Film
    {
        public Cartoon(string Name, string genre, int Duration, string Define)
        {
            this.Name = Name;
            this.genre = genre;
            this.Duration = Duration;
            this.Define = Define;
        }

        public Cartoon() { }

        [DataMember]
        public int? Duration { get; set; }                                                                     
        [DataMember]
        [NonSerialized]                                               //Как я понял, поле мы не можем просто убрать
        public string? Define;
        public override void PrintFragment()
        {
            Console.WriteLine("1 сезон, 2 серия, включаем!");
        }

        //[DataMember]                                                //Для проверки отсутствия члена в json, просто убрал его
        public string? genre { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Genre: {genre}\n" +
                   $"Duration: {Duration}\n" +
                   $"Define: {Define}";
        }
    }

    [Serializable]
    [DataContract]
    public abstract class TvProgram
    {
        [DataMember]
        public string? Name { get; set; }

        public abstract void PrintFragment();
    }

    interface Film
    {
        string? genre { get; set; }
    }
}
