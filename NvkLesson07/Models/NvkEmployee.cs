namespace NvkLesson07.Models
{
    public class NvkEmployee
    {
        private static int _autoId = 1;
        public int NvkId { get; set; }
        public string NvkName { get; set; }
        public DateTime NvkBirthDay { get; set; }
        public string NvkEmail { get; set; }
        public string NvkPhone { get; set; }
        public string NvkSalary { get; set; }
        public int NvkStatus { get; set; }
        public NvkEmployee()
        {
            NvkId = _autoId++;
        }
    }
}
