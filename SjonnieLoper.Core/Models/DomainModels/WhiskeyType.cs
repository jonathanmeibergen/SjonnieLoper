using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SjonnieLoper.Core.Models
{
    
    public class WhiskeyType
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Whiskey Type")]
        public string Name { get; set; }
    }

    /*
    public enum WhiskeyType
    {
        Irish,
        Scotch,
        Japanese,
        Canadian,
        Bourbon,
        Rye,
        Blended,
        SingleMalt
    }
    */
}
