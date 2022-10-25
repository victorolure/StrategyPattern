using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    public abstract class Phone
    {
        public Phone(int storage, string tone)
        {
            StorageGb = storage;
            RingTone = tone;
            
        }
        public Phone()
        {

        }
        public int StorageGb { get; set; }
        public void MakeCall(int phoneNumber)
        {
            Console.WriteLine($"You call {phoneNumber}");
        }
        public string RingTone { get; set; }
        public void Ring()
        {
            Console.WriteLine($"The phone makes a sound that goes {RingTone}");
        }

        //interchangeable behaviours.
        public IFlipBehaviour FlipBehaviour { get; set; }
        public IPortBehaviour PortBehaviour { get; set; }
        public IBiometricBehaviour BiometricBehaviour { get; set; }
        public void PerformFlipBehaviour()
        {
            FlipBehaviour.FlipBehaviour();
        }
        public void PerformPortBehaviour()
        {
            PortBehaviour.UsePort();
        }
        public void PerformBiometricLogin(string imageBlob)
        {
            BiometricBehaviour.BiometricLoginBehaviour(imageBlob);
        }
    }


    public class IPhone99 : Phone
    {
        public IPhone99(int storage, string ringTone): base(storage, ringTone)
        {
            PortBehaviour = new NoPortBehaviour();
            FlipBehaviour = new FlipNineTimes();
            BiometricBehaviour = new BloodSampleLogin();
        }
    }

    public class SamsungUniverse : Phone
    {
        public SamsungUniverse(int storage, string ringTone): base(storage, ringTone)
        {
            FlipBehaviour = new FlipNineTimes();
            PortBehaviour = new UsbZedPortBehaviour();
            BiometricBehaviour = new FaceImageLogin();
        }
    }

    public class HuaweiSuperPhone: Phone
    {
        public HuaweiSuperPhone(int storage, string ringTone): base(storage, ringTone)
        {
            FlipBehaviour = new FlipNineTimes();
            PortBehaviour = new UsbZedPortBehaviour();
            BiometricBehaviour = new FaceImageLogin();
        }
    }

    public interface IPortBehaviour
    {
        public void UsePort();
    }

    public class NoPortBehaviour : IPortBehaviour
    {
        public void UsePort()
        {
            Console.WriteLine("You can't plug in -- no port here");
        }
    }

    public class UsbZedPortBehaviour : IPortBehaviour
    {
        public void UsePort()
        {
            Console.WriteLine("The USB z connector gives the cable a friendly hug");
        }
    }
    public interface IFlipBehaviour
    {
        public void FlipBehaviour();
    }
    public class FlipNineTimes : IFlipBehaviour
    {
        public void FlipBehaviour()
        {
            Console.WriteLine("You flip the phone into a tiny pretzel");
        }
    }

    public interface IBiometricBehaviour
    {
        public void BiometricLoginBehaviour(string imageBlob);
    }

    public class BloodSampleLogin : IBiometricBehaviour
    {
        public void BiometricLoginBehaviour(string imageBlob)
        {
            Console.WriteLine("The phone pricks your finger and takes a blood sample");
        }
    }

    public class FaceImageLogin : IBiometricBehaviour
    {
        public void BiometricLoginBehaviour(string imageBlob)
        {
            Console.WriteLine("The phone takes a picture of your face to  login");
        }
    }
}
