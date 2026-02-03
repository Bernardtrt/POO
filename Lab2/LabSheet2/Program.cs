using System;
using System.Linq;
using System.IO;   

namespace LabSheet2
{
    class Program
    {
        static void Main(string[] args)
        {
            //====================================
            //uncomment the function u wanna use
            //====================================
            //numberquery();
            //numberlanmbda();
            //GetFilesQuery();
            //anonymousfilequery();
            //anonymousfilelambda();
        
        
            /*int[] numbers = {1,5,3,6,10,12,8};
            //var query = from number in numbers
            //select DoubleIt(number);
            var query = numbers
                .Select(n => DoubleIt(n));
            //var query2 = from n in numbers
            //select (DoubleIt(n));
            Console.WriteLine("Before the foreach loop");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        */
            //exo8();
            //exo9();
            //exo10();
            //GetCustomers();
            //exo12();
        }


        //==========================================================================
        //EXERCICE 1
        //==========================================================================
        
        private static void numberquery(){
            Console.WriteLine("--- Exercice 1 ---");
            
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };

            var outputNumbers = from number in numbers
                                where number > 5
                                orderby number
                                select number;

            foreach (int number in outputNumbers)
            {
                Console.WriteLine(number.ToString());
            }
                Console.ReadLine();

        }
         //==========================================================================
        //EXERCECE 2
        //==========================================================================
        private static void numberlanmbda(){
                        
            Console.WriteLine("\n--- Exercice 2 ---");
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };
            var outputNumbers2 = numbers
                .Where(n => n > 5)
                .OrderByDescending(n => n); 

            foreach (int number in outputNumbers2)
            {
                Console.WriteLine(number);
            }
            
            Console.ReadLine();
        }

         //==========================================================================
        //EXERCICE 3
        //==========================================================================
        private static void GetFilesQuery()
        {
        
            var files = new DirectoryInfo(@"/home/mathieu/Documents/ATU/POO/Lab1").GetFiles(); 

            var query = from item in files
                        where item.Length > 1
                        orderby item.Length descending, item.Name
                        select new MyFileInfo
                        {
                            Name = item.Name,
                            Length = item.Length,   
                            CreationTime = item.CreationTime
                        };

            Console.WriteLine("{0,-40}{1,6} MB {2}", "Filenames", "Size", "Creation Date");

            foreach (MyFileInfo item in query)
            {
                
                Console.WriteLine(item); 
            }
            
            Console.WriteLine("Fin de la liste. Appuie sur Entrée.");
            Console.ReadLine();
        }

         //==========================================================================
        //EXO4
        //==========================================================================
        private static void anonymousfilequery(){
            //======================================================
            //Change the directory with wichever u want to check, mine's this one because im on linux
            //======================================================
            var files = new DirectoryInfo(@"/home/mathieu/Documents/ATU/POO/Lab1").GetFiles(); 

            var query = from item in files
                        where item.Length > 1
                        orderby item.Length, item.Name
                        select new 
                        {
                            Name = item.Name,
                            Length = item.Length,
                            CreationTime = item.CreationTime
                        };
            Console.WriteLine("Filename\tSize\t\tCreationTime");

            foreach(var item in query){
                Console.WriteLine(
                    "{0} \t{1} bytes,\t{2}",
                    item.Name, item.Length, item.CreationTime
                ); 
            }
            Console.ReadLine();
        }
        
         //==========================================================================
        //EXO 5
        //==========================================================================
        private static void anonymousfilelambda(){

        var files = new DirectoryInfo(@"/home/mathieu/Documents/ATU/POO/Lab1").GetFiles(); 

            var query = files
                .Where(f => f.Length > 1) 
                .OrderBy(f => f.Length).ThenBy(f => f.Name)
                .Select(f => new
                    {
                        Name = f.Name,
                        Length = f.Length,
                        CreationTime = f.CreationTime

                    });
            Console.WriteLine("Filename\tSize\t\tCreationTime");

            foreach(var item in query){
                Console.WriteLine(
                    "{0} \t{1} bytes,\t{2}",
                    item.Name, item.Length, item.CreationTime
                ); 
            Console.ReadLine();
        }
    }
        //==========================================================================
        //EXO 6 
        //==========================================================================
    private static int DoubleIt(int value)
        {
            Console.WriteLine("About to double the number" + value.ToString());
            return value * 2;
        }
        
         //==========================================================================
        //EXO 7
        //==========================================================================
    private static void exo8(){
        string[] names = {"Mary","Joseph","Michael","Sarah","Margaret","John" };
        var query = names
            .Where(n => n.Length > 4);
            foreach(string n in query){
                Console.WriteLine(n);
            }
            Console.ReadLine();
    } 
     //==========================================================================
    //EXO 9 
    //==========================================================================
    private static void exo9(){
        string[] names = {"Mary","Joseph","Michael","Sarah","Margaret","John" };
        var query = names
            .Where(n => n.Length > 4)
            .OrderBy(n => n);
            

            foreach(string n in query){
                Console.WriteLine(n);
            }
            Console.ReadLine();
    } 
    //==========================================================================
    //EXO 10 
    //==========================================================================
    private static void exo10(){
        string[] names = {"Mary","Joseph","Michael","Sarah","Margaret","John" };
        var query = names
            .Where(n => n.Length > 4)
            .OrderBy(n => n);
            
            

            foreach(string n in query){
                if(n[0] == 'M'){
                    Console.WriteLine(n);
                }
            }
            Console.ReadLine();
    } 

    
        //==========================================================================
        //EXO 11
        //==========================================================================
    private static List<Customer> GetCustomers()
    {
        Customer c1 = new Customer { Name = "Tom", City = "Dublin" };
        Customer c2 = new Customer { Name = "Sally", City = "Galway" };
        Customer c3 = new Customer { Name = "George", City = "Cork" };
        Customer c4 = new Customer { Name = "Molly", City = "Dublin" };
        Customer c5 = new Customer { Name = "Joe", City = "Galway" };
        List<Customer> customers = new List<Customer>();
        customers.Add(c1);
        customers.Add(c2);
        customers.Add(c3);
        customers.Add(c4);
        customers.Add(c5);
        var query = customers 
            .Where(n=> n.City == "Dublin")
            .Select(n => n.Name);

        foreach(var c in query){
            Console.WriteLine(c);
        }
        return customers;

    }

     //==========================================================================
    //EXO 12 
    //==========================================================================
    private static List<Customer> exo12()
    {
        Customer c1 = new Customer { Name = "Tom", City = "Dublin" };
        Customer c2 = new Customer { Name = "Sally", City = "Galway" };
        Customer c3 = new Customer { Name = "George", City = "Cork" };
        Customer c4 = new Customer { Name = "Molly", City = "Dublin" };
        Customer c5 = new Customer { Name = "Joe", City = "Galway" };
        List<Customer> customers = new List<Customer>();
        customers.Add(c1);
        customers.Add(c2);
        customers.Add(c3);
        customers.Add(c4);
        customers.Add(c5);
        var query = customers 
            .Where(n=> n.City == "Dublin" || n.City == "Galway")
            .OrderBy(n=> n.Name)
            .Select(n => n.Name);

        foreach(var c in query){
            Console.WriteLine(c);
        }
        return customers;

    }
    
    
    
    }
    
    


     //==========================================================================
    //CLASSES
    //==========================================================================
    
    public class Customer
    {
        public string Name;
        public string City;
    }


    

    
    
    public class MyFileInfo
    {
        public string Name { get; set; }
        public long Length { get; set; } 
        public DateTime CreationTime { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-40}{1,6:F0} MB {2}", Name, Length / 1000, CreationTime.ToShortDateString());
        }
    }

    
}
    

