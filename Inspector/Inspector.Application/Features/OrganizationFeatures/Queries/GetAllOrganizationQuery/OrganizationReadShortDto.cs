namespace Inspector.Application.Features.OrganizationFeatures.Queries.GetAllOrganizationQuery
{
	public class OrganizationReadShortDto
    {
        public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public string Phone { get; set; }
	}
}
