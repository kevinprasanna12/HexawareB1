using System;


namespace sample_3
{
        internal interface IStudent
        {
            int StudentId { get; set; }
            string Name { get; set; }
            double Fees { get; set; }
            void ShowDetails();
        }
        class Dayscholar : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public double Fees { get; set; }

            public Dayscholar(int studentId, string name, double fees)
            {
                StudentId = studentId;
                Name = name;
                Fees = fees;
            }

            public void ShowDetails()
            {
                Console.WriteLine($"Dayscholar Student_ID: {StudentId},Name: {Name},Fees: {Fees}");
            }
        }
        class Resident : IStudent
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public double Fees { get; set; }
            public double AccommodationFees { get ; set; }

            public Resident(int studentId, string name, double fees, double accommodationFees)
            {
                StudentId = studentId;
                Name = name;
                Fees = fees;
                AccommodationFees = accommodationFees;
            }

            public void ShowDetails()
            {
                Console.WriteLine($"Resident Student_ID: {StudentId},Name: {Name},Total_Fees: {Fees + AccommodationFees}");
            }
        }
    
}
