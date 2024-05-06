// import
namespace InsuranceApp1
{


    class Program
    {
        // global virable
        // initialise a list of strings: Device types/ category
        static List<string> deviceCategory = new List<string>()
        {

            "Laptop", "Desktop", "Other (Such as Smart Phones or Drones)"

        };

        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string priciestDeviceName = "";
        static float totalInsuranceCost = 0, PriciestDevice = 0;

        //methods / functions
        static void OneDevice()
        {
            string deviceName; // this means the function DeviceName is a string function meaning it will return strings to the code which will turn into the name of the device
            int category, deviceCount; //This is a int function meaning it wil return a whole number to the code which will turn into which device and how many there are
            float deviceCost, deviceInsurance = 0; ; // this means that this will return numbers with decimals

            // enter the device name
            Console.WriteLine("Enter the Device's Name:");
            deviceName = Console.ReadLine();

            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();


            Console.Clear();


            // choose category of device
            string menu = "Choose Device Category";
            Console.WriteLine("Choose Device Category:");

            int categoryCount = 0;

            foreach (string cat in deviceCategory)
            {

                categoryCount +=1;
                Console.WriteLine($"{categoryCount}. {cat}");

            }
            category = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();


            Console.Clear();

            
            //Enter Device Cost
            Console.WriteLine("Enter Device Cost:");
            deviceCost = (float)Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();


            Console.Clear();


            //Enter number of devices
            Console.WriteLine("Enter the number of devices:");
            deviceCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();


            Console.Clear();
            // this is a function that increases the amount of devices per category 
            if (category ==1)
            {
                laptopCounter += deviceCount;
            }
            else if (category ==2)
            {
                desktopCounter += deviceCount;

            }
            else 
            {
                otherCounter += deviceCount;
            }

         

            //calculate insurance

            if (deviceCount > 5)
            {
                deviceInsurance += 5* deviceCost;

                deviceInsurance += (deviceCount - 5) * deviceCost * 0.9f;


            }

            else
            {
                deviceInsurance += deviceCount * deviceCost;
            }

            Console.WriteLine($"{deviceName}");
            Console.WriteLine($"total cost for {deviceCount} x {deviceName}, is = ${deviceInsurance}");



            //calculate Depreciation
            Console.WriteLine("month\t value loss");

            float depreciation = deviceCost;
            for (int month = 0; month < 6; month++)
            {
                depreciation = depreciation * 0.95f;
                depreciation = (float)Math.Round( depreciation, 2);
                Console.WriteLine($"{month +1}\t{depreciation}");

            }


            // to show the total insurance cost 
            if (deviceInsurance > 0)
            {
                totalInsuranceCost += deviceInsurance;
            }


            // to show Priciest Device 
            if (deviceCost > PriciestDevice)
            {
                PriciestDevice = deviceCost;
                priciestDeviceName =  deviceName;
            }



        }




        static void Main(string[] args)
        {
            //Display App Title
            Console.WriteLine("Insurance App");

            Console.WriteLine("Press <Enter> to continue...");
            Console.ReadLine();


            Console.Clear();

        


            //Add another Device

            string proceed = "";
            while (proceed.Equals(""))
            {
                OneDevice();
              
                Console.WriteLine("Press <ENTER> to add another device or type x to exit...");
                proceed = Console.ReadLine();
                
                
         

              
            }
            Console.WriteLine($"The number of laptops:{laptopCounter}");
            Console.WriteLine($"The number of Desktops:{desktopCounter}");
            Console.WriteLine($"The number of other Device:{otherCounter}");

            Console.WriteLine($"The total value for insurance:${totalInsuranceCost}");
            Console.WriteLine($"The most expensive device: {priciestDeviceName} costing ${PriciestDevice}");




        }
    }
}

}



