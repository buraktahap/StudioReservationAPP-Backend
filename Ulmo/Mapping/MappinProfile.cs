
using AutoMapper;
using StudioReservationAPP.Core.Entities;
using StudioReservationAPP.Models;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Member, MemberDto>();

            CreateMap<Class, ClassDto>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<Branch, BranchDto>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<Trainer, TrainerDto>();
            CreateMap<TrainerWorkPlace, TrainerWorkPlaceDto>();
            CreateMap<MemberLesson,MemberLessonDto>();
            CreateMap<MemberLesson,CreateMemberLessonDto>();
            CreateMap<WaitingQueue, WaitingQueueDto>();
            CreateMap<WaitingQueue, CreateWaitingQueueDto>();
            CreateMap<WaitingQueue, WaitingQueueIndexDto>();
            // Resource to Domain
            CreateMap<MemberDto, Member>();
            CreateMap<SaveMemberDto, Member>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<BranchDto, Branch>();
            CreateMap<ClassDto, Class>();
            CreateMap<LessonDto, Lesson>();
            CreateMap<TrainerDto, Trainer>();
            CreateMap<TrainerWorkPlaceDto, TrainerWorkPlace>();
            CreateMap<MemberLessonDto, MemberLesson>();
            CreateMap<CreateMemberLessonDto, MemberLesson>();
            CreateMap<CreateMemberLessonDto, MemberLessonDto>();
            CreateMap<WaitingQueueDto, WaitingQueue>();
            CreateMap<CreateWaitingQueueDto, WaitingQueue>();
            CreateMap<WaitingQueueIndexDto, WaitingQueue>();
        }
    }
}
