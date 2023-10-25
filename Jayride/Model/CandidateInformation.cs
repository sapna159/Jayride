using System.ComponentModel.DataAnnotations;

namespace Jayride
{
    public class CandidateInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}