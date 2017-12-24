using System;

namespace Hospital.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }

        public string Comments { get; set; }

        public DateTime Date { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
