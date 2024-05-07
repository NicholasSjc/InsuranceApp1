
//import
namespace InsuranceApp1
{


    internal class Program
    {
        // global virable
        // initialise a list of strings: Device types/ category
        readonly static List<string> DEVICECATEGORY = new List<string>()
        {

            "Laptop", "Desktop", "Other (Such as Smart Phones or Drones)"

        };

        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string priciestDeviceName = "";
        static float totalInsuranceCost = 0, PriciestDevice = 0;

        //methods / functions

        // so all error messages have a red colour to it 
        static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;

        }




        // to display errors for device cost, device category, number of devices
        static float Checkfloat(string question, float min, float max)
        {

            while (true)



                try

                {





                    Console.WriteLine(question);



                    float userfloat = (float)Convert.ToDecimal(Console.ReadLine());



                    if (userfloat >= min && userfloat <= max)

                    {

                        return userfloat;

                    }



                    DisplayErrorMessage($"ERROR: You must enter a number between {min} and {max}");



                }

                catch

                {

                    DisplayErrorMessage($"ERROR: You must enter a number between {min} and {max}");

                }

        }

        static int Checkint(string question, int min, int max)

        {

            while (true)



                try

                {





                    Console.WriteLine(question);



                    int userint = Convert.ToInt32(Console.ReadLine());



                    if (userint >= min && userint <= max)

                    {

                        return userint;

                    }



                    DisplayErrorMessage($"ERROR: You must enter a number between {min} and {max}");



                }

                catch

                {

                    DisplayErrorMessage($"ERROR: You must enter a number between {min} and {max}");

                }

        }




        
        static void OneDevice()

        {
            string deviceName; // this means the function DeviceName is a string function meaning it will return strings to the code which will turn into the name of the device
            int category, deviceCount; //This is a int function meaning it wil return a whole number to the code which will turn into which device and how many there are
            float deviceCost, deviceInsurance = 0; ; // this means that this will return numbers with decimals





            // enter the device name
            Console.WriteLine("Enter the Device's Name:");
            deviceName = Console.ReadLine();

            if (string.IsNullOrEmpty(deviceName))

            {

                DisplayErrorMessage("Error: You must enter a device name");

                OneDevice();

                return;

            }

            Console.WriteLine("Press <Enter> to continue...\n");
            Console.ReadLine();






            // choose category of device
            string menu = "Choose Device Category:\n";


            int categoryCount = 0;

            foreach (string cat in DEVICECATEGORY)
            {

                categoryCount++;
                menu += $"{categoryCount}.{cat}\n";


            }

            category = Checkint(menu, 1, 3);


            Console.WriteLine("Press <Enter> to continue...\n");
            Console.ReadLine();








            //Enter Device Cost
            deviceCost = Checkfloat("Enter Device Cost:", 1, 10000);

            Console.WriteLine("Press <Enter> to continue...\n");
            Console.ReadLine();





            //Enter number of devices
            deviceCount = Checkint("Enter number of Devices", 1, 100);

            Console.WriteLine("Press <Enter> to continue...\n");
            Console.ReadLine();



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
                depreciation = (float)Math.Round(depreciation, 2);
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
        // to check if user entered valid data when regarding at the end
        static string CheckProceed()

        {

            Console.WriteLine("Press <enter> to add another device or type x to exit...");

            string userInput = Console.ReadLine().ToLower();



            while (userInput != "" && userInput != "x")

            {

                DisplayErrorMessage("Please press <enter> or type 'x'");

                Console.WriteLine("Please enter again:");

                userInput = Console.ReadLine().ToLower();

            }



            return userInput;





        }


        // Main method
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
                proceed = CheckProceed();
            }

            // to display summary of number of devices in each category, total insurance, priciest device after user enters 'x'
            Console.WriteLine($"The number of laptops:{laptopCounter}");
            Console.WriteLine($"The number of Desktops:{desktopCounter}");
            Console.WriteLine($"The number of other Device:{otherCounter}");

            Console.WriteLine($"The total value for insurance:${totalInsuranceCost}");
            Console.WriteLine($"The most expensive device: {priciestDeviceName} costing ${PriciestDevice}");

        }


    }





}





