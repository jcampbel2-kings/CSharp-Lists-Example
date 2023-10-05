using System;
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
        static void Main(string[] args)
        {
            Console.WriteLine("Which version do you want to run?");
            Console.WriteLine("1) Lists");
            Console.WriteLine("2)Linked  Lists");
            Console.Write(">");
            string ch=Console.ReadLine();
            if (ch=="1"){
                ListSR.MainLists();
            } else if (ch=="2"){
                LinkedListSR.MainLists();
            } else {
                Console.WriteLine("Invalid option");
            }
            
        }
    }
}
