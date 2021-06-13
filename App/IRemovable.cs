namespace Rootmap.Configurator
{
  public delegate void DeletedEventHandler(object deletedDataModel);

  public interface IRemovable
  {
    event DeletedEventHandler Deleted;
  }
}
