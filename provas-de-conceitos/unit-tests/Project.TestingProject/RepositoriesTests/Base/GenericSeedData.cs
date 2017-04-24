using Project.Infrastructure.Context;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project.TestingProject.Base
{
    public abstract class GenericSeedData<TEntity> : ISeedData
        where TEntity : Entity
    {
        public List<TEntity> DataList { get; set; }

        public GenericSeedData()
        {
        }

        public void EmptyDatabase()
        {
            using (var unitOfWorkContextAware = new UnitOfWork(new InfraContext(), null))
            {
                var dataSet = unitOfWorkContextAware.GetDbSet<TEntity>();

                dataSet.ToList().ForEach(item => dataSet.Remove(item));
                unitOfWorkContextAware.Commit();
            }
        }

        public void SeedDatabase()
        {
            using (var unitOfWorkContextAware = new UnitOfWork(new InfraContext(), null))
            {
                foreach (var item in DataList)
                {
                    unitOfWorkContextAware.GetDbSet<TEntity>().Add(item);
                }

                unitOfWorkContextAware.Commit();
            }
        }
    }
}
