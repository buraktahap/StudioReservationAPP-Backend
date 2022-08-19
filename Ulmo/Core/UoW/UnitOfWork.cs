using StudioReservationAPP.Core.EFContext;
using StudioReservationAPP.Core.Entities.Base;
using StudioReservationAPP.Core.Factory;
using StudioReservationAPP.Core.Repositories.Base;

namespace StudioReservationAPP.Core.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private MemberRepository _memberRepository;
        private BranchRepository _branchRepository;
        private ClassRepository _classRepository;
        private LessonRepository _lessonRepository;
        private TrainerRepository _trainerRepository;
        private TrainerWorkPlaceRepository _trainerWorkPlaceRepository;
        private MemberLessonRepository _memberLessonRepository;
        private WaitingQueueRepository _waitingQueueRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IMemberRepository Members => _memberRepository ??= new MemberRepository(_context);
        public IBranchRepository Branches => _branchRepository ??= new BranchRepository(_context);
        public IClassRepository Classes => _classRepository ??= new ClassRepository(_context);
        public ILessonRepository Lessons => _lessonRepository ??= new LessonRepository(_context);
        public ITrainerRepository Trainers => _trainerRepository ??= new TrainerRepository(_context);
        public ITrainerWorkPlaceRepository TrainerWorkPlaces => _trainerWorkPlaceRepository ??= new TrainerWorkPlaceRepository(_context);
        public IMemberLessonRepository MemberLessons => _memberLessonRepository ??= new MemberLessonRepository(_context);
        public IWaitingQueueRepository WaitingQueues => _waitingQueueRepository ??= new WaitingQueueRepository(_context);

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
