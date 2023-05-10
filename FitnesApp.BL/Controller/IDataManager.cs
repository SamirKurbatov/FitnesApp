namespace FitnesApp.BL.Controller
{
    public interface IDataManager
    {
        void Save<T>(List<T> item) where T : class;
        
        List<T>? Load<T>() where T : class;
    }
}
