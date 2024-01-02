namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        /*  [SetUp]
          public void Setup()
          {
          }
        */
        /*
          public Device(int memoryCapacity)
          {
              this.MemoryCapacity = memoryCapacity;
              this.AvailableMemory = memoryCapacity;
              this.Photos = 0;
              this.Applications = new List<string>();
          }

          public int MemoryCapacity { get; private set; }
          public int AvailableMemory { get; private set; }

          public int Photos { get; private set; }

          public List<string> Applications { get; private set; }

          */
        [Test]
        public void Test_DeviceConstructor()
        {
            Device device = new Device(10);
            Assert.AreEqual(device.MemoryCapacity, 10);
            Assert.AreEqual(device.AvailableMemory, device.MemoryCapacity);
            Assert.AreEqual(device.Photos,0);
            Assert.IsNotNull(device.Applications);
            Assert.AreEqual(device.Applications.Count, 0);
            

        }
        /*
          public bool TakePhoto(int photoSize)
        {
            if (photoSize <= this.AvailableMemory)
            {
                this.AvailableMemory -= photoSize;
                this.Photos++;
                return true;
            }
            return false;
        }
        */
        [Test]
        public void Test_TakePhoto()
        {
            Device firstDevice = new Device(10);
            bool res = firstDevice.TakePhoto(10);
            Assert.AreEqual(firstDevice.AvailableMemory, 0);
            Assert.AreEqual(firstDevice.Photos, 1);
            Assert.IsTrue(res);

            Device secondDevice = new Device(20);
             res = secondDevice.TakePhoto(10);
            Assert.AreEqual(secondDevice.AvailableMemory, 10);
            Assert.AreEqual(secondDevice.Photos, 1);
            Assert.IsTrue(res);

            Device thirdDevice = new Device(5);
            res = thirdDevice.TakePhoto(10);
            Assert.AreEqual(thirdDevice.AvailableMemory, 5);
            Assert.AreEqual(thirdDevice.Photos, 0);
            Assert.IsFalse(res);
        }
        /*
         public string InstallApp(string appName, int appSize)
        {
            if (appSize <= this.AvailableMemory)
            {
                this.AvailableMemory -= appSize;
                this.Applications.Add(appName);
                return $"{appName} is installed successfully. Run application?";
            }
            else
            {
                throw new InvalidOperationException("Not enough available memory to install the app.");
            }
        }

        */
        [Test]
        public void Test_InStallAppThrowsInvalidOperationException()
        {
            Device device = new Device(10);
         
            Assert.That(()=>device.InstallApp("appName",20),Throws.InvalidOperationException);
            
        }
        [Test]
        public void Test_InStallAppReturnsMessage()
        {
            Device device = new Device(10);
            string result = device.InstallApp("appName", 5);
            Assert.AreEqual(device.AvailableMemory, 5);
            Assert.AreEqual(result, $"appName is installed successfully. Run application?");

            Assert.AreEqual(device.Applications.Count, 1);
            string existingDevice = device.Applications[0];
            Assert.AreEqual("appName", existingDevice);

        }
        /*
             public void FormatDevice()
        {
            this.Photos = 0;
            this.Applications = new List<string>();
            this.AvailableMemory = this.MemoryCapacity;
        }


        */
        [Test]
        public void Test_FormatDevice()
        {
            Device device = new Device(10);
            device.FormatDevice();
            Assert.AreEqual(device.Photos, 0);
            Assert.IsEmpty(device.Applications);
            Assert.AreEqual(device.AvailableMemory, device.MemoryCapacity);
        }
        /*
         
       public string GetDeviceStatus()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {this.MemoryCapacity} MB, Available Memory: {this.AvailableMemory} MB");
            stringBuilder.AppendLine($"Photos Count: {this.Photos}");
            stringBuilder.AppendLine($"Applications Installed: {string.Join(", ", this.Applications)}");

            return stringBuilder.ToString().TrimEnd();
        }
        */
        [Test]
        public void Test_()
        {
            Device device = new Device(10);
            device.TakePhoto(10);
            string res = device.GetDeviceStatus();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Memory Capacity: {device.MemoryCapacity} MB, Available Memory: {device.AvailableMemory} MB");
            sb.AppendLine($"Photos Count: {device.Photos}");
            sb.AppendLine($"Applications Installed: {string.Join(", ", device.Applications)}");
            string sbToString = sb.ToString().TrimEnd();
            Assert.AreEqual(sbToString, res);
        }
    }
}