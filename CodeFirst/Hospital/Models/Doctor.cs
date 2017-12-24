using System.Collections.Generic;

namespace Hospital.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
