using FruitStore.Model;

namespace FruitStore.Repository
{
    interface IFruitRepository
    {
        Fruit GetFruit(string fruit);
    }
}