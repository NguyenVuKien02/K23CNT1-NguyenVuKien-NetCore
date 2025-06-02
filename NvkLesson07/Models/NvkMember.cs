namespace NvkLesson07.Models
{
    public interface NvkMember
    {
        public int NvkId { get; set; }

        public string NvkName { get; set; }
        public string NvkUserName { get; set; }

        public string NvkPassword { get; set; }

        public string NvkEmail { get; set; }

        public bool NvkStatus { get; set; }
    }
}
