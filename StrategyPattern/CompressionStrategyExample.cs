using StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IDENTIFY an instance in which classes have some behaviours that change and some that will always remain the same
// Compressor will always have a PerformCompression method that will take a Client ject
// The behaviour of the PerformCompression method will change based on user input

// STRATEGY
// We must have at least one class that has an interface for a behaviour as a property
// That interface needs to have at least one implementation
// The class needs to invoke the method(s) of the interface
// By runtime, an implementation of the interface needs to be chosen by the class

Compressor compressor = new Compressor("rar");
Client client = new Client();
client.Files = new List<string> { "imagestuff.txt", "more.txt", "again.mvc" };
compressor.PerformCompression(client);
compressor.SwitchCompressionMethod("zip");
compressor.PerformCompression(client);


namespace StrategyPattern
{

    public class Client
    {
        public List<String> Files { get; set; } = new List<string>();
    }
    public class Compressor
    {
        public ICompressionBehavior CompressionBehaviour { get; set; }

        public void SwitchCompressionMethod(string type)
        {
            switch (type.ToLower())
            {
                case "rar":
                    CompressionBehaviour = new RARCompressionBehaviour();
                    break;
                case "zip":
                    CompressionBehaviour = new ZipCompressionBehaviour();
                    break;
                case "tar":
                    CompressionBehaviour = new TarCompressionBehaviour();
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        public Compressor(string compressorType)
        {
            SwitchCompressionMethod(compressorType);
        }
        public void PerformCompression(Client client)
        {
            // de
            CompressionBehaviour.Compress(client.Files);
        }
        
    }

    public interface ICompressionBehavior
    {
        public string Compress(List<string> files);
    }
    public class RARCompressionBehaviour : ICompressionBehavior
    {
        public string Compress(List<String> files)
        {
            Console.WriteLine($"Compressed {files.Count} into RAR file.");
            return $"rarified {files.Count} files.rar";
        }
    }

    public class ZipCompressionBehaviour : ICompressionBehavior
    {
        public string Compress(List<String> files)
        {
            Console.WriteLine($"Compressed {files.Count} into Zip file.");
            return $"zipped {files.Count} files.zip";
        }
    }

    public class TarCompressionBehaviour : ICompressionBehavior
    {
        public string Compress(List<String> files)
        {
            Console.WriteLine($"Compressed {files.Count} into tar file.");
            return $"tarred {files.Count} files.zip";
        }
    }

}
