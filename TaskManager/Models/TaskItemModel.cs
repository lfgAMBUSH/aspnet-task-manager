using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TaskManager.Models
{
    public class TaskItemModel
    {
        public int Id { get; set; }

        [ValidateNever]
        public string UserId { get; set; } = null!;

        [ValidateNever]
        public IdentityUser User { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        public DateTime TimeOfPublication { get; set; }

    }
}
