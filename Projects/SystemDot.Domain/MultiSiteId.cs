namespace SystemDot.Domain
{
    using SystemDot.Core;

    public abstract class MultiSiteId : Equatable<MultiSiteId>
    {
        public string Id { get; private set; }
        public string SiteId { get; private set; }

        protected MultiSiteId(string id, string siteId)
        {
            Id = id;
            SiteId = siteId;
        }

        public override bool Equals(MultiSiteId other)
        {
            return other.Id == Id && other.SiteId == SiteId;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode().ShiftBitsUp(2) ^ Id.GetHashCode();
        }
    }
}