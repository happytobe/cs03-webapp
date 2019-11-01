using System.ComponentModel.DataAnnotations;

namespace TC_CS03_Blazor.Data
{
    public class Review
    {
        public long REVIEW_ID { get; set; }
        [Required(ErrorMessage ="Rating required. Please select.")]
        public string REVIEW_RATING_TYPE_CD { get; set; }
        public string REVIEW_RATING_TYPE_ETXT { get; set; }
        [StringLength(250, ErrorMessage = "Comments are limited to 250 characters.")]
        public string COMMENTS_TXT { get; set; }
    }
}
