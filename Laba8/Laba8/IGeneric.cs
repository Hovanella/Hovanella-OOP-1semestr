namespace Laba8
{
    public interface IGeneric<T>
    {
        /*1.Создайте обобщенный интерфейс  операциями  добавить, удалить,просмотреть.*/
        void Add(T item);
        void Delete(T item);
        void Show();
    }
    
}
