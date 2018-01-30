using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF.DBO
{
    public class GenericUnitOfWork
    {
        private TechForumEntities _dbContext = new TechForumEntities(); 
        //public GenericUnitOfWork(TechForumEntities dbContext)
        //{
        //    _dbContext = new TechForumEntities();
        //}
        
        public GenericRepository<TEntity> GetRepoInstance<TEntity>() where TEntity:class
        {
            return new GenericRepository<TEntity>(_dbContext);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
