using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.DataBase.Entities
{
    public class LiteratureReferenceEntity
    {
        [Column("pmid")] public int Id { get; set; }
        public string? Title { get; set; }
    }
}