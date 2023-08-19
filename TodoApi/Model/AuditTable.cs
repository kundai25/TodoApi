namespace TodoApi.Model
{
    public abstract class AuditTable
    {
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }

    }
}
