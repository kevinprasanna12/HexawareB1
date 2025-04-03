namespace sample_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-------Strings--------------
            //Strings str = new Strings();
            //str.Get_string();
            //str.String_length();
            //str.String_reverse(); 
            //str.String_check();


            //-------------Student--------------
            //Student stud = new Student(1221,"hari","12A",4,"ECE");
            //stud.GetMarks();
            //stud.Get_result();
            //stud.DisplayData();
            


            //-------------exception---------------
            //AccountDetails obj = new AccountDetails("Ram", 2100);
            //try
            //{
            //    Console.WriteLine("enter amount to transfer");
            //    int tamount = Convert.ToInt32(Console.ReadLine());
            //    obj.TransferAmount(tamount);
            //}
            //catch (InsufficeintFundsException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //obj.DisplayAcc();



            //-----------interface-----------------------

            IStudent day_obj = new Dayscholar(12,"Hari",3000);
            IStudent res_obj = new Resident(123, "logan", 4000, 2000);

            day_obj.ShowDetails();
            res_obj.ShowDetails();

            //Console.Read();
        }
    }
}
