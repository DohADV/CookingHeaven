using System.ComponentModel;

namespace CookingHeaven.Models
{
    public class Retete
    {
        public int ID { get; set; }
        [DisplayName("Numele retetei")]
        public string RetetaNume { get; set; }
        [DisplayName("Descrierea retetei")]
        public string RetetaDescriere { get; set; }
        public Retete()
        {

        }
    }
}
