using System;


namespace Sample_pro
{
    
    class TimePeriod()
    {

        internal double Sec;

        public double Hours
        {
            get {return Sec / 3600;}
            set { Sec = value * 3600; }

        }
        public TimePeriod(double Input_Hours)
        {
            Hours = Input_Hours;
        }

        public void display_output() 
        {
            Console.WriteLine("The time is {0}",Sec);
        }


        static void Main(string[] args)
        {
            TimePeriod obj = new TimePeriod(2.5);
            Console.WriteLine(obj);
        }

    }
}
