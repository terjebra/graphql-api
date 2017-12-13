using System;
using System.Collections.Generic;
using API.Domain;
using System.Linq;
using API.Infrastructure;

namespace API.Query
{
  public class RoomQueryService : IRoomQueryService
  {
    private readonly IRepository<Room> repository;

    public RoomQueryService(IRepository<Room>  repository)
    {
      this.repository = repository;

    }
    public System.Collections.Generic.IList<Room> GetAll()
    {
      return repository.GetAll();
    }

    public Room GetById(string id)
    {
      return repository.Get(id);
    }
  }
}