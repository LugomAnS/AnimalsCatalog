namespace DataAccess
{
    internal interface IDataAccessFactory
    {
        public IDataAccess GetDataProvider(string provider);
    }
}
