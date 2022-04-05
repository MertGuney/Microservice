namespace FreeCourse.Services.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
    }
}
