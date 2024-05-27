using ExamAppEntities.Interfaces;
using ExamAppWebUI.Models.Interfaces;

namespace ExamAppWebUI.Mappers.Interfaces
{
    public interface IBaseMapper<TEntity, TModel> where TEntity : IEntity
                                                  where TModel : IModel, new()
    {
        TModel Map(TEntity entity);
        TEntity Map(TModel model);
    }
}
