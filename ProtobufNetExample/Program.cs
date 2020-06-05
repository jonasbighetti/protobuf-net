using ProtoBuf;
using System.IO;

namespace ProtobufNetExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Id = 1,
                FirstName = "Jonas",
                LastName = "Bighetti",
                Age = 29
            };

            var personSerialize = SerializeObject(person);
            var personDeserialize = DeserializeObject(personSerialize);
        }

        private static byte[] SerializeObject(Person obj)
        {
            using var stream = new MemoryStream();
            Serializer.Serialize(stream, obj);
            return stream.ToArray();
        }

        private static Person DeserializeObject(byte[] data)
        {
            using var stream = new MemoryStream(data);
            return Serializer.Deserialize<Person>(stream);
        }
    }

    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string FirstName { get; set; }
        [ProtoIgnore]
        public string LastName { get; set; }
        [ProtoMember(4)]
        public int Age { get; set; }
    }
}
