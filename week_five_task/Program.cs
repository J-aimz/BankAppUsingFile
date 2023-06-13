using BizLogic;

namespace Bank_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new Controller();
            bool existProgram = false;


            do
            {
                int choice = controller.FirstView();

                Action(choice, controller);


            } while (!existProgram);

        }


        public static void Action(int choice, Controller controller)
        {
            switch (choice)
            {
                case 0:
                    controller.SetupAccount();
                    break;
                case 1:
                    controller.Login();
                    break;
                case 2:
                    controller.ExistApp();
                    break;
            }

        }

        public void Ref()
        {
            string path = "C:\\Users\\JAIMZ\\Desktop\\DECAGON_CODE\\WEEK_FIVE\\week_task\\BizLogic\\data\\customers.txt";

            //var id = new Guid().NewGuid();

            //var guid = new Guid().NewGuid().ToString("N");
            ////Guid.NewGuid().ToString();
            //Console.WriteLine(guid);

            Guid guid = Guid.NewGuid();
            string str = guid.ToString();

            Console.WriteLine(guid);

            List<Dictionary<string, string>> allData = new();

            //using (var sr = new StreamWriter(path))
            //{
            //    //sr.WriteLine("6554,John,#qqqqq,m@mail.com");

            //}

            //var file = new File(path);

            File.AppendAllText(path, "6554,John,#qqqqq,m@mail.com");

            //File.AppendText(path);

            using (var sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);

                    string[] lineArr = line.Split(',');

                    //Console.WriteLine(lineArr.Length);

                    Dictionary<string, string> data = new()
                    {
                        {"id",  lineArr[0]},
                        {"fullName",  lineArr[1]},
                        {"password",  lineArr[2]},
                        {"email", lineArr[3]}
                    };

                    allData.Add(data);
                }
            }


            foreach (var item in allData)
            {
                Console.WriteLine(item["password"]);
            }


        }
    }
}

