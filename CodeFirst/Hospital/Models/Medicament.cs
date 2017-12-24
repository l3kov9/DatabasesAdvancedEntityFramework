using System.Collections.Generic;

namespace Hospital.Models
{
    public class Medicament
    {
        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public List<PatientMedicament> Patients { get; set; } = new List<PatientMedicament>();
    }
}
