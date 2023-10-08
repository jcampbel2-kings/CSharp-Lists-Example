using System;
using MySqlConnector;

namespace ListsandLinkL
{
    class Student {
        //used to issue unique ids automatically
        //start from 1
        static int nextID = 1;
        //static method to print report header
        static public void PrintListHead(){
            Console.WriteLine($"{"ID".PadRight(8)} {"Name".PadRight(15)} {"Email".PadRight(20)} {"Date Birth".PadRight(12)}");    
            Console.WriteLine($"-".PadRight(60,'-'));    
            return;
        }

        int id;
        string name;
        string email;
        string dob;
        public int ID {get {return id;} }
        public string Name {get {return name;} set {name =value;}}
        public string Email {get {return email;} set{email = value;} }  
        public string Dob {get {return email;} set{dob=value;}}   
        
        //constructor
        public Student(string n="unknown", string e="unknown", string d="unknown") {
            //set the id based on the next avail id and then increment that nextID
            id=nextID;
            nextID++;
            name=n;
            email=e;
            dob=d;
        }

        //access next available id
        public int GetNextID(){
            return nextID;  
        }
        
        public void PrintList() {
            Console.WriteLine($"{id.ToString().PadRight(8)} {name.PadRight(15)} {email.PadRight(20)} {dob.PadRight(10)}");
            return;
        }

        public void PrintCard() {
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Date of Birth: {dob}");
        }
    }
    


    //class for static methods (subrout) and main pgm
    class Program
    {
        //test mysql
        static void tstSQL(){
            MySqlConnection conn;
            string myConnectionString;
            string sqlcmd="SELECT idSTudent, Name, Email FROM school.Student;";

            myConnectionString = "server=192.168.1.45;uid=root;pwd=53DixonAv;database=school";
            try{
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                Console.WriteLine("Connection Open");
                MySqlCommand cmd = new MySqlCommand(sqlcmd, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}" );
                }
                rdr.Close();
                cmd.Dispose();


                conn.Close();
                Console.WriteLine("Connection Closed");
            }
            catch (MySqlException ex){
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            string ch;
            do{
                Console.WriteLine("Which version do you want to run?");
                Console.WriteLine("1) Lists");
                Console.WriteLine("2) Linked  Lists");
                Console.WriteLine("3) Test Connect");
                Console.WriteLine("q) Quit");
                
                Console.Write(">");
                ch=Console.ReadLine();
                if (ch=="1"){
                    ListSR.MainLists();
                } else if (ch=="2"){
                    LinkedListSR.MainLists();
                } else if (ch=="3"){
                    tstSQL();
                }

            } while (ch !="q");
            
        }
    }
}
