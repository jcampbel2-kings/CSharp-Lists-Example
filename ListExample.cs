using System;
namespace ListsandLinkL

{
    //class for static methods (subrout) and main pgm
    public static class ListSR
    {
        // initialise a list to hold student details
        static List<Student> students = new List<Student>();
        
        static void AddStudent(){
            Console.Write("Name :");
            string name = Console.ReadLine();
            Console.Write("Email :");
            string email = Console.ReadLine();
            Console.Write("Date of Birth :");
            string dob = Console.ReadLine();
            Student student= new Student(name, email, dob);
            students.Add(student);
            Console.WriteLine($"The new ID is {student.ID}");

            return;
        }

        static void FindStudent(){
            int findId;
            
            Console.Write("Enter student id to find: ");
            String sId=Console.ReadLine();
            if (!Int32.TryParse(sId, out findId)) {
                Console.WriteLine("Invalid ID, must be numeric");
            } else {
                int idx=0;
                bool found=false;
                while (!found && idx < students.Count){
                    if (students[idx].ID==findId) {
                        found=true;
                    } else {
                        idx++;
                    }
                }
                if (!found) {
                    Console.WriteLine($"ID {findId} not found");
                } else {
                    students[idx].PrintCard();
                }
            }
        }

        static void PrintStudentList() {
            Student.PrintListHead();
            foreach (Student student in students) {
                student.PrintList();
            }
        }

        static string DisplayMenu() {
            string ch;
            Console.WriteLine("");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1) Add Student");
            Console.WriteLine("2) Find Student");
            Console.WriteLine("3) Print all students");
            Console.WriteLine("Q) Exit");
            ch=Console.ReadLine();

            return ch;
        }
        
        static void ProcessMenu(string ch){
            switch (ch) {
                case "1": {
                    AddStudent();
                    break;
                }
                case "2": {
                    FindStudent();
                    break;
                }
                case "3": {
                    PrintStudentList();
                    break;
                }
                case "4": {
                    Console.WriteLine("Not is use");
                    break;
                }
                case "q": {
                    Console.WriteLine("Goodbye");
                    break;
                }
                default: {
                    Console.WriteLine("Invalid option");
                    break;
                }
            }

            return;
        }


        public static void MainLists()
        {
            string ch;
            do {
                ch=DisplayMenu();
                ProcessMenu(ch);
            } while (ch!="q");            
        }
    }
}