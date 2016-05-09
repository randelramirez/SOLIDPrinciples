using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.Infrastructure
{
    public class Repository<TEntity> where TEntity : class, new()
    {
        private IDbSet<TEntity> dbset;
        private DbContext context;

        public void Add(TEntity entity)
        {
            this.dbset.Add(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return this.dbset.AsEnumerable();
        }

        public void Delete(TEntity entity)
        {
            this.dbset.Remove(entity);
        }

        public void Delete(int id)
        {
            var entityToDelete = this.dbset.Find(id);
            if (entityToDelete != null)
                this.dbset.Remove(entityToDelete);
        }

        public TEntity Find(int id)
        {
            return this.dbset.Find(id);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return this.dbset.Single(filter);
        }

        public void Update(TEntity entity)
        {
            (this.context as DbContext).Entry(entity).State = EntityState.Modified;
            //this.context.SetEntityState<TEntity>(entity, EntityState.Modified);
        }

        public void Log(string logMessage)
        {
            string x = logMessage;
            System.Diagnostics.EventLog.WriteEntry(x);
        }

        public void FormatData()
        {
            var data = this.All();
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        public void FormatXMLData()
        {
            var stringwriter = new System.IO.StringWriter();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(this.GetType());
            xmlSerializer.Serialize(stringwriter, this.All().ToList());
            stringwriter.ToString();
        }
    }
}
