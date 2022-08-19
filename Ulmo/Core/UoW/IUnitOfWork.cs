using StudioReservationAPP.Core.Entities.Base;
using StudioReservationAPP.Core.Repositories.Base;

namespace StudioReservationAPP.Core.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        /// <returns>The number of objects in an Added, Modified, or Deleted state asynchronously</returns>
        Task<int> CommitAsync();
        /// <returns>Repository</returns>
        //IRepository<TEntity> GetRepository<TEntity, TPrimaryKey>() where TEntity : Entity<TPrimaryKey>;
        IMemberRepository Members { get; }
        IBranchRepository Branches { get; }
        IClassRepository Classes { get; }
        ILessonRepository Lessons { get; }
        ITrainerRepository Trainers { get; }
        ITrainerWorkPlaceRepository TrainerWorkPlaces { get; }
        IMemberLessonRepository MemberLessons { get; }
        IWaitingQueueRepository WaitingQueues { get; }

        //IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        //IRepository<TEntity, string> GetRepositoryWithString<TEntity>() where TEntity : Entity<string>;
    }
}
