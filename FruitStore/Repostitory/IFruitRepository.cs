using FruitStore.Model;

namespace FruitStore.Repository
{
    public interface IFruitRepository
    {
        Fruit GetFruit(string fruit);
    }
}