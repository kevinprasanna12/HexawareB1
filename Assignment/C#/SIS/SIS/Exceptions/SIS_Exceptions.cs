using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Exceptions
{

    public class MY_Exception
    {
        public class DuplicateEnrollmentException : Exception
        {
            public DuplicateEnrollmentException() : base("Student is already enrolled in this course.") { }
            public DuplicateEnrollmentException(string message) : base(message) { }
        }
        public class CourseNotFoundException : Exception
        {
            public CourseNotFoundException() : base("Course not found in the system.") { }
            public CourseNotFoundException(string message) : base(message) { }
        }
        public class StudentNotFoundException : Exception
        {
            public StudentNotFoundException() : base("Student not found in the system.") { }
            public StudentNotFoundException(string message) : base(message) { }
        }
        public class TeacherNotFoundException : Exception
        {
            public TeacherNotFoundException() : base("Teacher not found in the system.") { }
            public TeacherNotFoundException(string message) : base(message) { }
        }
        public class PaymentValidationException : Exception
        {
            public PaymentValidationException() : base("Invalid payment details.") { }
            public PaymentValidationException(string message) : base(message) { }
        }
        public class InvalidStudentDataException : Exception
        {
            public InvalidStudentDataException() : base("Invalid student data provided.") { }
            public InvalidStudentDataException(string message) : base(message) { }
        }
        public class InvalidCourseDataException : Exception
        {
            public InvalidCourseDataException() : base("Invalid course data provided.") { }
            public InvalidCourseDataException(string message) : base(message) { }
        }
        public class InvalidEnrollmentDataException : Exception
        {
            public InvalidEnrollmentDataException() : base("Invalid enrollment data provided.") { }
            public InvalidEnrollmentDataException(string message) : base(message) { }
        }
        public class InvalidTeacherDataException : Exception
        {
            public InvalidTeacherDataException() : base("Invalid teacher data provided.") { }
            public InvalidTeacherDataException(string message) : base(message) { }
        }
        public class InsufficientFundsException : Exception
        {
            public InsufficientFundsException() : base("Insufficient funds to make the payment.") { }
            public InsufficientFundsException(string message) : base(message) { }
        }
    }
}
