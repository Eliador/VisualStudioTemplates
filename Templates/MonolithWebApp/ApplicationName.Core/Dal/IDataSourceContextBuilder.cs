namespace ApplicationName.Core.Dal
{
    public interface IDataSourceContextBuilder<DataSourceContextT>
    {
        DataSourceContextT Build();
    }
}
