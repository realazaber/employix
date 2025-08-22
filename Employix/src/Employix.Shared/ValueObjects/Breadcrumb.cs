namespace Employix.Shared.ValueObjects
{
    public class Breadcrumb
    {
        public Breadcrumb(string title)
        {
            Title = title;
            Url = "/" + title.ToLower().Replace(" ", "-");
        }
        public string Title { get; set; } = "";

        public string Url { get; set; } = "";
    }
}
