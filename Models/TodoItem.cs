#region snippet

namespace TodoApi_backend.Models {
    public class TodoItem {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
#endregion