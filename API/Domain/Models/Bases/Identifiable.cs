namespace Domain.Models.Bases
{
    public class Identifiable
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public long Id { get; set; }

        public Identifiable()
        {
        }
        
        public Identifiable(long id)
        {
            Id = id;
        }
    }
}