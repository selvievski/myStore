using Store.Domain.DataModels;
using Store.Domain.Repositories;
using System.Collections.Generic;

namespace Store.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item Get(int Id)
        {
            return _itemRepository.Get(Id);
        }

        public int Add(Item entity)
        {
            return _itemRepository.Add(entity);
        }

        public void Delete(int id)
        {
            _itemRepository.Delete(id);
        }

        public void Update(int id, Item entity)
        {
            _itemRepository.Update(id, entity);
        }
    }
}
