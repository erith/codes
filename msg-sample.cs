using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using System.Drawing;
using System.Text.Json;

namespace App2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var resolver = MessagePack.Resolvers.CompositeResolver.Create(
              new IMessagePackFormatter[] { MessagePack.Formatters.TypelessFormatter.Instance, ColorFormatter.Instance },
              new IFormatterResolver[] { MessagePack.Resolvers.ContractlessStandardResolver.Instance, StandardResolver.Instance, MessagePack.Resolvers.PrimitiveObjectResolver.Instance }
          );
            var options = MessagePackSerializerOptions.Standard.WithResolver(resolver);

            // Pass options every time or set as default
            MessagePackSerializer.DefaultOptions = options;

            //Write();

            Read();


            Console.ReadLine();
        }

        public static void Read()
        {
            var bytes = File.ReadAllBytes(@"d:\test.bin");

            var lz4Options = MessagePackSerializerOptions.Standard
                            .WithResolver(MyResolver.Instance)
                            .WithCompression(MessagePackCompression.Lz4BlockArray);

            var dt = MessagePackSerializer.Deserialize<Data>(bytes, lz4Options);
        }

        public static void Write()
        {

            var items = Enumerable.Range(0, 10000);
            Color[] colors = new Color[10000];
            foreach (var item in items)
            {
                colors[item] = Color.Wheat;
            }

            Data dt = new Data();
            dt.Colors = colors;

            var text = JsonSerializer.Serialize(dt);
            File.WriteAllText(@"d:\test.json", text);

            //var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);

            var lz4Options = MessagePackSerializerOptions.Standard
                .WithResolver(MyResolver.Instance)
                .WithCompression(MessagePackCompression.Lz4BlockArray);

            byte[] bytes = MessagePackSerializer.Serialize(dt, lz4Options);
            //byte[] bytes = MessagePackSerializer.Serialize(dt);

            File.WriteAllBytes(@"d:\test.bin", bytes);


        }
    }

    [MessagePack.MessagePackObject]
    public class Data
    {
        /// <summary>
        /// Colors
        /// </summary>
        [Key("Colors")]
        public Color[] Colors { get; set; }
    }


    public class MyResolver : IFormatterResolver
    {
        public static readonly IFormatterResolver Instance = new MyResolver();
        private static readonly IFormatterResolver[] Resolvers = new IFormatterResolver[]
        { TypelessContractlessStandardResolver.Instance };

        private MyResolver() { }

        public IMessagePackFormatter<T> GetFormatter<T>()
        { return Cache<T>.Formatter; }

        private static class Cache<T>
        {
            public static IMessagePackFormatter<T> Formatter;

            static Cache()
            {
                if (typeof(T) == typeof(Color))
                {
                    Formatter = (IMessagePackFormatter<T>)(ColorFormatter.Instance);
                    return;
                }

                foreach (var resolver in Resolvers)
                {
                    var f = resolver.GetFormatter<T>();
                    if (f != null)
                    {
                        Formatter = f;
                        return;
                    }
                }
            }
        }
    }
    public class ColorFormatter : IMessagePackFormatter<Color>
    {
        public static ColorFormatter Instance = new ColorFormatter();

        public Color Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var a = reader.ReadByte();
            var r = reader.ReadByte();
            var g = reader.ReadByte();
            var b = reader.ReadByte();

            return Color.FromArgb(a, r, g, b);
        }

        public void Serialize(ref MessagePackWriter writer, Color value, MessagePackSerializerOptions options)
        {
            writer.Write(value.A);
            writer.Write(value.R);
            writer.Write(value.G);
            writer.Write(value.B);
        }
    }
}
