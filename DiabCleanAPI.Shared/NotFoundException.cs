namespace DiabCleanAPI.DiabCleanAPI.Shared
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id) : base("No Entity with id=" + id + " exists") { }
    }
}
