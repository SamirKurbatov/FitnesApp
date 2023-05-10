

namespace FitnesApp.BL.Controller
{
    public abstract class BaseController
    {
        protected IDataManager _dataSaver = new SerializeDataManager();

        protected void Save<T>(List<T> item) where T : class
        {
            _dataSaver.Save(item);
        }

        protected List<T>? Load<T>() where T : class
        {
            return _dataSaver.Load<T>() ?? throw new ArgumentException("Не удалось задесериализовать данные");
        }
    }
}
